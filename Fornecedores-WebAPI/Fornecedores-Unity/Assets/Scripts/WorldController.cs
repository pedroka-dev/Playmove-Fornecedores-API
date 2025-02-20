using Fornecedores_Model.Features;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldController : MonoBehaviour
{
    List<Fornecedor> fornecedors;

    public int maxSpawnXPosition = 0;
    public int maxSpawnYPosition = 0;
    public GameObject fornecedorNpcPrefab;

    void Start()
    {
        fornecedors = GetFornecedoresByApi();
        SpawnFornecedores();
    }

    private List<Fornecedor> GetFornecedoresByApi()
    {
        return new List<Fornecedor>(){
            new("João Silva","joao.silva@email.com"),
            new("Maria Oliveira","maria.oliveira@email.com"),
            new("Carlos Santos","carlos.santos@email.com"),
         new("Ana Souza","ana.souza@email.com"),
        };
    }

    private void SpawnFornecedores()
    {
        foreach(Fornecedor fornecedor in fornecedors)
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
