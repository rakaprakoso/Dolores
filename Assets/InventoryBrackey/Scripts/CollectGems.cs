using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGems : MonoBehaviour
{
    private PlayerController player;
    public GameObject collectEffect;
    private int count = 1;
    private SpriteRenderer spriteRenderer;
    public Sprite gemsColor;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = gemsColor;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            // spawn the sun button at the first available inventory slot ! 
            Instantiate(collectEffect, player.transform.position, Quaternion.identity);
            player.gems += count;
            Destroy(gameObject);
        }
        
    }

}
