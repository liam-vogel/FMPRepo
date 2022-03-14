using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Canvas MenuUi;
    public Canvas PlayerUi;
    public Canvas SettingsUi;
    public Image SettingsMenu;
    public GameObject unpauseButton;
    public GameObject pauseButton;
    public GameObject UpgradesMenu;
    public GameObject CharactersMenu;
    public Canvas LevelUpUi;
    // Start is called before the first frame update
    void Start()
    {
        //MenuUi = GetComponent<Canvas>();
       // PlayerUi = GetComponent<Canvas>();
        Time.timeScale = 1;
        MenuUi.gameObject.SetActive(true);
        PlayerUi.gameObject.SetActive(false);
        SettingsMenu.gameObject.SetActive(false);
        unpauseButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        UpgradesMenu.gameObject.SetActive(false);
        CharactersMenu.gameObject.SetActive(false);


    }
   public void StartButton()
   {
        Time.timeScale = 1;
        MenuUi.gameObject.SetActive(false);
        PlayerUi.gameObject.SetActive(true);
        CharactersMenu.gameObject.SetActive(false);
        UpgradesMenu.gameObject.SetActive(false);


   }

    public void unPauseButton()
    {
        Time.timeScale = 1; 
        PlayerUi.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        unpauseButton.gameObject.SetActive(false);
        SettingsMenu.gameObject.SetActive(false);
        Debug.Log("notActive");
        
       
        
       
    }

    public void PauseButton()
    {


        unpauseButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        SettingsMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("On");
    }

    public void UpgradesButton()
    {
        UpgradesMenu.gameObject.SetActive(true);
    }
    public void OffCharectersButton()
    {
        CharactersMenu.gameObject.SetActive(false);
    }
    public void OffUpgradesButton()
    {
        UpgradesMenu.gameObject.SetActive(false);
    }

    public void CharectersButton()
    {
        CharactersMenu.gameObject.SetActive(true);
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
}
