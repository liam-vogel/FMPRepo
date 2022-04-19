using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class axe : MonoBehaviour
{
    public float speed = 1;
   
    public bool Thrown;
   // public axe AxePrefab;
   // public GameObject axeHolder;
     public Vector3 LaunchOffset;
     


   

    // Start is called before the first frame update
    void Start()
    {
        if(Thrown)
        {
            var direction = -transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
            
        }
        transform.Translate(LaunchOffset);
        // LaunchOffset = new Vector3(axeHolder.transform.position.x, axeHolder.transform.position.y, axeHolder.transform.position.z);
        
        
        Destroy(gameObject, 5);

       
    }

    
    // Update is called once per frame
    void Update()
    {
        if(!Thrown)
        transform.position += -transform.right * speed * Time.deltaTime;

     //   LaunchOffset = new Vector3(axeHolder.transform.position.x, axeHolder.transform.position.y, axeHolder.transform.position.z);


    }

}
