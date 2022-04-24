using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform trans;
    public PlayerScript PS;
    public bool isFired = true;
    public Transform playerT;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        trans = GetComponent<Transform>();
       // PS = GetComponent<PlayerScript>();
        //playerT = GetComponent<GameObject>();
        
    }

    public IEnumerator KnifeTimer()
    {
        isFired = true;
        yield return new WaitForSeconds(3);
        isFired = false;
    }

    // Update is called once per frame
    void Update()
    {
       // if(KnifeEquipped)
        //StartCoroutine(KnifeTimer());
        
       // if (isFired)
        {
            // StartCoroutine(KnifeTimer());

            if (Input.GetKey(KeyCode.D))
            {
                trans.position = playerT.transform.position;
                rb.AddForce(rb.velocity = new Vector2(10f, trans.forward.x));
                Debug.Log(trans);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                trans.position = playerT.transform.position;
                rb.AddForce(rb.velocity = new Vector2(-10f, trans.forward.x));
            }
            else if (Input.GetKey(KeyCode.W))
            {
                trans = playerT.transform;
                rb.AddForce(rb.velocity = new Vector2(trans.forward.y , -10f));
            }
            else if(PS.state == PlayerScript.MovementState.down)
            {
                trans.position = playerT.transform.position; ;
                rb.AddForce(rb.velocity = new Vector2(trans.forward.y, 10f));
            }
            else if(Input.GetKey(KeyCode.S))
            {
              //  trans.position = playerT.transform.position;
               // rb.velocity = Vector2.zero;

            }

        }

    }

}
