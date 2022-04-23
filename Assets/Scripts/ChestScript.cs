using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
  //  GameObject lootUI;
   public PlayerScript PS;
    public GameObject player;

    private void Start()
    {
       // lootUI = GameObject.Find("lootUI");
        player = GameObject.Find("Player");
        PS = player.GetComponent<PlayerScript>();
        //lootUI.SetActive(false);
    }

    private void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PS.lootUI.SetActive(true);
            Time.timeScale = 0f;
            gameObject.SetActive(false);

        }

    }

}














