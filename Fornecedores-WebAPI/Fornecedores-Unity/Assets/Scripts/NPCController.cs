
using Fornecedores_Model.Features;
using TMPro;
using UnityEngine;

public class FornecedorNPC : MonoBehaviour
{
    public Fornecedor fornecedor;
    private TextMeshPro nameLabel;
    private TextMeshPro emailLabel;

    private void Awake()
    {
        nameLabel = transform.Find("NameLabel")?.GetComponent<TextMeshPro>();
        emailLabel = transform.Find("EmailLabel")?.GetComponent<TextMeshPro>();
    }

    void Start()
    {
        nameLabel.text = fornecedor.nome;
        emailLabel.text = fornecedor.email;
    }

    void Update()
    {
        
    }
}
