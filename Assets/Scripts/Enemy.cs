using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //!!!!!!!!!!!!!!!!!__________________new code 
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [SerializeField] Patrol patrol;
    [SerializeField] AIDestinationSetter destination;
    [SerializeField] GameObject target;
    [SerializeField] int enemyHealth = 5;
    [SerializeField] Slider hpSlider; //!!!!!!!!!!!!!!!!!__________________new code 

    private void Start()
    {
        hpSlider.maxValue = enemyHealth; //!!!!!!!!!!!!!!!!!__________________new code 
        hpSlider.value = enemyHealth; //!!!!!!!!!!!!!!!!!__________________new code        
    }

    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance < 3f)
        {
            patrol.enabled = false;
            destination.enabled = true;
        }
        else
        {
            patrol.enabled = true;
            destination.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerSettings>().Damage(transform.position);
        }
    }

    public void EnemyDamage()
    {
        enemyHealth--;
        hpSlider.value = enemyHealth; //!!!!!!!!!!!!!!!!!__________________new code        

        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        Invoke(nameof(SetColor), 0.2f);
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void SetColor()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
}
