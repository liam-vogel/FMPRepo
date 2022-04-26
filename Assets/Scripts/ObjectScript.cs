using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    private Collider2D coll;
    public GameObject HealthPot;
    private Transform CampfireTrans;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        CampfireTrans = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("attacks"))
        {
            GameObject Potion = Instantiate(HealthPot, CampfireTrans.transform.position ,Quaternion.identity);
            Debug.Log("instance");
            Destroy(this.gameObject,0.01f);
        }
    }   // Update is called once per frame
    void Update()
    {
        
    }
}
