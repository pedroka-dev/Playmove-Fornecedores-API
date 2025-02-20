

using Fornecedores_Model.Features;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class WorldController : MonoBehaviour
{
    List<Fornecedor> fornecedores;

    public int defaultPort = 5274;
    public int maxSpawnXPosition = 0;
    public int maxSpawnYPosition = 0;
    public GameObject fornecedorNpcPrefab;

    void Start()
    {
        StartCoroutine(FetchFornecedores(GetFornecedores()));
    }

    private List<Fornecedor> GetFornecedores()
    {
        return fornecedores;
    }

    IEnumerator FetchFornecedores(List<Fornecedor> fornecedores)
    {
        string url = $"http://localhost:{defaultPort}/fornecedor";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Accept", "application/json");
            

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string json = request.downloadHandler.text;
                Debug.Log("Fornecedores loaded: " + fornecedores.Count);
                SpawnFornecedores();
            }
            else
            {
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
}
