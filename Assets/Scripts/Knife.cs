using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform trans;
  //  public PlayerScript PS;
    public bool isFired = false;
    //  public Transform playerT;
    // [SerializeField] private Transform pfKnife;
    // Start is called before the first frame update
    public float KnifeDur = 5;
    public bool up;
    public PlayerScript PS;
    public Transform Player;
    public float distance;
    void Start()
    {
        StartCoroutine(KnifeTimer());
        rb = GetComponent<Rigidbody2D>();   
        trans = GetComponent<Transform>();
        // PS = GetComponent<PlayerScript>();
        //playerT = GetComponent<GameObject>();
        PS = GameObject.Find("Player").GetComponent<PlayerScript>();
        Player = GameObject.Find("Player").GetComponent<Transform>();
        

        if (Input.GetKey(KeyCode.D))
        {
            up = true;
            // trans.position = playerT.transform.position;
          

            Debug.Log(trans);
            return;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // trans.position = playerT.transform.position;
           
            rb.AddForce(rb.velocity = new Vector2(-10f, trans.forward.x));
            return;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // trans = playerT.transform;
            rb.AddForce(rb.velocity = new Vector2(trans.forward.y, -10f));
            return;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            // trans.position = playerT.transform.position; ;
            rb.AddForce(rb.velocity = new Vector2(trans.forward.y, 10f));
            return;
        }
          else 
         {

            rb.gravityScale = 1;

         }

        if (PS.dirX > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        else if (PS.dirX < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1f);
        }
    }

     public IEnumerator KnifeTimer()
      {
         isFired = false;
           yield return new WaitForSeconds(KnifeDur);
         isFired = true;
      }

    // Update is called once per frame
    void Update()
    {
      if(up)
        {
            rb.AddForce(rb.velocity = new Vector2(10f, trans.forward.x));
        }



        Destroy(gameObject,5f);

        Vector3 distToPlayer = trans.position - Player.position;
        Debug.Log(distToPlayer.magnitude);

        
        if (PS.dirX > 0 && distToPlayer.magnitude < 0.5f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        else if (PS.dirX < 0 && distToPlayer.magnitude < 0.5f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1f);
        }


    }

}
