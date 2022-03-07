using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float health;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("attacks"))
        {
            health -= damage;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {

            Debug.Log("EnemyDied");
        }
    }
}
