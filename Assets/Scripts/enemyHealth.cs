using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float health;
    public float damage;
    public GameObject enemy;
    private SpriteRenderer rend;
    private Color damageColor = Color.red;
    private Color normalColor = Color.white;
    public Transform ETrans;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        ETrans = GetComponent<Transform>();
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("attacks"))
        {
            health -= damage;
            rend.material.color = damageColor;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            enemy.SetActive(false);
            Debug.Log("EnemyDied");
           

        }
        

    
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rend.material.color = normalColor;

    }
}
