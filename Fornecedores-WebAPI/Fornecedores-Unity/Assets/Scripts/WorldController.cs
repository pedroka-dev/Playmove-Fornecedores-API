

using Fornecedores_Model.Features;
using Leguar.TotalJSON;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class WorldController : MonoBehaviour
{
    private List<Fornecedor> fornecedores;
    private TextMeshPro mensagemErro;

    public int defaultPort = 5274;
    public int maxSpawnXPosition = 0;
    public int maxSpawnYPosition = 0;
    public GameObject fornecedorNpcPrefab;

    private void Awake()
    {
        mensagemErro = GetComponentInChildren<TextMeshPro>();
    }

    void Start()
    {
        StartCoroutine(FetchFornecedores());
    }


    IEnumerator FetchFornecedores()
    {
        string url = $"http://localhost:{defaultPort}/fornecedor";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Accept", "application/json");
            

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string json = request.downloadHandler.text;
                fornecedores = DeserializeFornecedores(json);
                
                Debug.Log("Fornecedores loaded: " + fornecedores.Count);
                SpawnFornecedores();
            }
            else
            {
                mensagemErro.enabled = true;
                mensagemErro.text += $"{request.method} \n {request.url} \n {request.result} \n{request.error} "; 
                Debug.LogError("Failed to fetch fornecedores: " + request.error);
            }
        }
    }


    private void SpawnFornecedores()
    {
        foreach(Fornecedor fornecedor in fornecedores)
        {
            var npc = Instantiate(fornecedorNpcPrefab, GetRandomScreenPosition(), new Quaternion());
            npc.GetComponent<FornecedorNPC>().fornecedor = fornecedor;
        }
    }

    private Vector2 GetRandomScreenPosition()
    {
        float xPosition = Random.Range(-maxSpawnXPosition, maxSpawnXPosition);
        float yPosition = Random.Range(-maxSpawnYPosition, maxSpawnYPosition);
        return new Vector2(xPosition, yPosition);
    }


    //Unity tem um problema gigantesco em deserializar Listas em JSON.
    //Não era possível utilizar bibliotecas como Newtonsoft e outras soluções similares
    //Após horas, consegui solucionar com uma gambiarra utilizando código de terceiros
    private List<Fornecedor> DeserializeFornecedores(string jsonText)
    {
        jsonText = jsonText.Trim('[').Trim(']').Replace("},", "} ");
        JSON[] jsonObjects = JSON.ParseStringToMultiple(jsonText);
        List<Fornecedor> fornecedoresRetorno = new();
        foreach (JSON jsonObj in jsonObjects)
        {
            Fornecedor fornecedor = new(jsonObj.GetString("nome"), jsonObj.GetString("email"));
            fornecedoresRetorno.Add(fornecedor);
        }
        return fornecedoresRetorno;
    }
}
