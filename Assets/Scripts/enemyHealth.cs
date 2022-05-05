using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float health = 60;
    public float damage = 20;
    public GameObject enemy;
    private SpriteRenderer rend;
    private Color damageColor = Color.black;
    private Color normalColor = Color.white;
    private Transform ETrans;
    public GameObject EXPItem;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
        ETrans = GetComponent<Transform>();
        //enemy.tag = "Enemy";

    }
    IEnumerator DamageFlash()
    {
        rend.material.color = damageColor;
        yield return new WaitForSeconds(0.2f);
        rend.material.color = normalColor;
    }

   public void TakeDamage()
    {
        health -= damage;
        StartCoroutine(DamageFlash());
    }
                     

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("attacks"))
        {
            TakeDamage();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(EXPItem, ETrans.position, ETrans.rotation);

           
           

        }

        ETrans = GetComponent<Transform>();

    
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       // rend.material.color = normalColor;

    }
}
