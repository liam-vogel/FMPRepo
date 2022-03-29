using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPScript : MonoBehaviour
{
   
    PlayerScript PScript;
    public float Exp = 0;
    public Image ExpBar;
    public GameObject ExpItem;
    

    // Start is called before the first frame update
    void Start()
    {
 
      
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerScript>())
        {
          
            Exp++;
            Destroy(this);

        }
    }

  

    // Update is called once per frame
    void Update()
    {
         
         ExpBar.fillAmount = Exp / PScript.LevelUpAmount * 100;
         

    }



}
