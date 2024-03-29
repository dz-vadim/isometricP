﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private int health; 
    [SerializeField] private Image healthBar;
    [SerializeField] private Sprite[] healthImages;
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBar.sprite = healthImages[health];
    }

    void Update()
    {

    }

    public void Damage(Vector3 enemyPosition)
    {
        health--;
        Vector3 impulse = enemyPosition - transform.position;
        transform.Translate(-impulse * 3f);
        //rb.AddForce(-impulse * 30f, ForceMode2D.Impulse);
        if (health <= 0 )
        {
            Destroy(gameObject);
        }
        healthBar.sprite = healthImages[health];
    }
}
