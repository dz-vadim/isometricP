using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim1 : MonoBehaviour
{
    Vector2 screenPosition;
    Vector2 worldPosition;
    public GameObject gun;
    public GameObject player;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = gun.GetComponent<SpriteRenderer>();
        sprite.sortingOrder = 1;
    }

    void Update()
    {
        screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.right = new Vector3(worldPosition.x, worldPosition.y, 0) - transform.position;

        if (transform.rotation.z > -0.7f && transform.rotation.z < 0.7f)
        {
            sprite.flipY = false;
        }
        else
        {
            sprite.flipY = true;
        }
        if(player.GetComponent<PlayerMovement>().moveV > 0)
        {
            sprite.sortingOrder = 1;
        }
        if(player.GetComponent<PlayerMovement>().moveV < 0 ||               //or == ||     and == &&
            player.GetComponent<PlayerMovement>().moveH != 0)
        {
            sprite.sortingOrder = 3;
        }
    }
}
