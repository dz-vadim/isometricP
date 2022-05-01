using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JewelSpawner : MonoBehaviour
{
    public GameObject jewel;
    public GameObject victoryUI;
    public int jewelCount = 0;
    public int jewelOnlevel = 0;
    public Text jewelText;

    void Start()
    {
        victoryUI.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(nameof(spawn));
    }

    private void Update()
    {
        jewelText.text = jewelCount.ToString() + "/" + jewelOnlevel.ToString();
        if (jewelCount >= jewelOnlevel)
        {
            Time.timeScale = 0;
            victoryUI.SetActive(true);
        }
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
