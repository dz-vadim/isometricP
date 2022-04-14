using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private GameObject gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<JewelSpawner>().gameObject;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.GetComponent<JewelSpawner>().jewelCount++;
            Destroy(gameObject);
        }
    }
}
