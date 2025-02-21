
using Fornecedores_Model.Features;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class NPCController : MonoBehaviour
{
    List<SpriteRenderer> bodyAndHairRenderer;

    TextMeshPro nameLabel;
    TextMeshPro emailLabel;

    public Fornecedor fornecedor;


    private void Awake()
    {
        bodyAndHairRenderer = GetComponentsInChildren<SpriteRenderer>().ToList();
        nameLabel = transform.Find("NameLabel")?.GetComponent<TextMeshPro>();
        emailLabel = transform.Find("EmailLabel")?.GetComponent<TextMeshPro>();

        bool spriteflipX = Random.Range(0, 2) == 1;
        foreach (SpriteRenderer sprite in bodyAndHairRenderer)
        {
            sprite.flipX = spriteflipX;
        }

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
}
