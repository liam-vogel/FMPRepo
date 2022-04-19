using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float health = 60;
    public float damage = 20;
    public GameObject enemy;
    private SpriteRenderer rend;
    private Color damageColor = Color.red;
    private Color normalColor = Color.white;
    private Transform ETrans;
    public GameObject EXPItem;

    // Start is called before the first frame update
    void Start()
    {
       // rend = GetComponent<SpriteRenderer>();
        ETrans = GetComponent<Transform>();


    }

   public void TakeDamage()
    {
        health -= damage;
    }
                     

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("attacks"))
        {
            TakeDamage();
          //  rend.material.color = damageColor;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(EXPItem, ETrans.position, ETrans.rotation);
            Debug.Log("EnemyDied");
           

        }
        

    
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       // rend.material.color = normalColor;

    }
}
