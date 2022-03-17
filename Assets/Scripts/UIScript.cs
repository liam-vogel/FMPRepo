using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public PlayerScript PScript;
    public Canvas MenuUi;
    public Canvas PlayerUi;
    public Canvas SettingsUi;
    public Image SettingsMenu;
    public GameObject unpauseButton;
    public GameObject pauseButton;
    public GameObject UpgradesMenu;
    public GameObject CharactersMenu;
    public GameObject Scroll;
    public GameObject Player;
    public Sprite Char1;
    public Sprite Char2;
    public Canvas LevelUpUi;
    public GameObject Hwep;
    public GameObject Cwep;
    // Start is called before the first frame update

  

    void Start()
    {
        //MenuUi = GetComponent<Canvas>();
       // PlayerUi = GetComponent<Canvas>();
        Time.timeScale = 0;
        MenuUi.gameObject.SetActive(true);
        PlayerUi.gameObject.SetActive(false);
        SettingsMenu.gameObject.SetActive(false);
        unpauseButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        UpgradesMenu.gameObject.SetActive(false);
        CharactersMenu.gameObject.SetActive(false);
        Player.GetComponent<homingWeapon>();


    }
   public void StartButton()
   {
        Time.timeScale = 1;
        MenuUi.gameObject.SetActive(false);
        PlayerUi.gameObject.SetActive(true);
        CharactersMenu.gameObject.SetActive(false);
        UpgradesMenu.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);


   }

    public void unPauseButton()
    {
        Time.timeScale = 1; 
        PlayerUi.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        unpauseButton.gameObject.SetActive(false);
        SettingsMenu.gameObject.SetActive(false);
        SettingsUi.gameObject.SetActive(false);
        Debug.Log("notActive");
        
       
        
       
    }

    public void PauseButton()
    {


        unpauseButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        SettingsMenu.gameObject.SetActive(true);
        SettingsUi.gameObject.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("On");
    }

    public void UpgradesButton()
    {

        UpgradesMenu.gameObject.SetActive(true);
        CharactersMenu.gameObject.SetActive(false);
        Scroll.gameObject.SetActive(false);


    }
    public void OffCharectersButton()
    {
        CharactersMenu.gameObject.SetActive(false);
        Scroll.gameObject.SetActive(true);
    }
    public void OffUpgradesButton()
    {
        UpgradesMenu.gameObject.SetActive(false);
        Scroll.gameObject.SetActive(true);
    }

    public void CharectersButton()
    {
        CharactersMenu.gameObject.SetActive(true);
        UpgradesMenu.gameObject.SetActive(false);
        Scroll.gameObject.SetActive(false);
    }

    public void LevelUpButton()
    {
        LevelUpUi.gameObject.SetActive(false);
        Time.timeScale = 1;
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

       
    
    }


    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }
    public void CharecterSelect1()
    {
        PScript.rend.sprite = Char1;
    }

    public void CharecterSelect2()
    {
        PScript.rend.sprite = Char2;
    }

    public void StaffUpgrade()
    {
        //fix this bit xoxo
        //fixed your code liam xoxo
        Hwep.SetActive(false);
        Cwep.SetActive(true);
    }

    public void OffStaffUpgrade()
    {
        //fix this bit xoxo
        //fixed your code liam xoxo
        Hwep.SetActive(true);
        Cwep.SetActive(false);
    }

}
