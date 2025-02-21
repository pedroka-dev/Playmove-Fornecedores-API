
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

        Color randomColor = new Color(
            Random.Range(0f, 1f), // Red
            Random.Range(0f, 1f), // Green
            Random.Range(0f, 1f), // Blue
            1f // Alpha (fully opaque)
        );

        nameLabel.color = emailLabel.color = randomColor;
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
