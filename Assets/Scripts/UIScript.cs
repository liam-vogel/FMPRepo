using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    private Canvas MenuUi;
    public Canvas PlayerUi;
    
    // Start is called before the first frame update
    void Start()
    {
        MenuUi = GetComponent<Canvas>();
        PlayerUi = GetComponent<Canvas>();
        Time.timeScale = 0;
        MenuUi.gameObject.SetActive(false);
        PlayerUi.gameObject.SetActive(true);
        

    }
   public void StartButton()
   {
        Time.timeScale = 1;
        MenuUi.gameObject.SetActive(true);
        PlayerUi.gameObject.SetActive(false);
   }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
