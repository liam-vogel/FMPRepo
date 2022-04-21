using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    GameObject lootUI;
  // public PlayerScript PS;

    private void Start()
    {
        lootUI = GameObject.Find("lootUI");
        lootUI.SetActive(false);
    }

    private void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lootUI.SetActive(true);
            Time.timeScale = 0f;
            gameObject.SetActive(false);

        }

    }

}














