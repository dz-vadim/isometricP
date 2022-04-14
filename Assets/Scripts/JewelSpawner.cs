using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JewelSpawner : MonoBehaviour
{
    public GameObject jewel;
    public int jewelCount = 0;
    public Text jewelText;
    void Start()
    {
        StartCoroutine(nameof(spawn));
    }

    private void Update()
    {
        jewelText.text = "Coins: " + jewelCount.ToString();
    }

    IEnumerator spawn()
    {
        while (true)
        {
            Vector2 bottom_left = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
            Vector2 top_right = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            float x = Random.Range(bottom_left.x, top_right.x);
            float y = Random.Range(bottom_left.y, top_right.y);

            Instantiate(jewel, new Vector3(x,y,0), Quaternion.identity);
            yield return new WaitForSeconds(10f);
        }
    }
}
