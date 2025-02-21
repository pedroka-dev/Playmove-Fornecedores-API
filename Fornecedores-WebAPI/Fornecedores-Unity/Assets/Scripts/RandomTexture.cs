using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public List<Sprite> spriteList;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int randomIndex = Random.Range(0, spriteList.Count);
        spriteRenderer.sprite = spriteList[randomIndex];
    }

}
