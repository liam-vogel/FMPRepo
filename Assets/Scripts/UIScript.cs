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
    public GameObject Hbut;
    public GameObject Cbut;
    public Text HStat;
    public Text SStat;
    public Text AStat;
    public Text DStat;
    public Text MHStat;
    public Text MSStat;
    public Text MAStat;
    public Text MDStat;
    private float health;
    private float speed;
    private float damage;
    private float armor;
    public int gold = 100;
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
        Hbut.SetActive(false);
       // PScript.health = health;
       // PScript.speed = speed;
       // PScript.speed = damage;
       // PScript.speed = armor;


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

    public void ArmorUpgrade()
    {
        if(gold >= 20)
        {
            gold -= 20;
            PScript.armor++;
            LevelUpUi.gameObject.SetActive(false);
            if (!UpgradesMenu)
                StartCoroutine(PlayGame());
        }
        
        

    }
    public void SpeedUpgrade()
    {
        if (gold >= 20)
        {
            gold -= 20;
            PScript.speed += 0.05f;
            LevelUpUi.gameObject.SetActive(false);
            if (!UpgradesMenu)
                StartCoroutine(PlayGame());
        }
    }

    public void HealthUpgrade()
    {
        if (gold >= 20)
        {
            gold -= 20;
            PScript.health += 30;
            LevelUpUi.gameObject.SetActive(false);
            if (!UpgradesMenu)
                StartCoroutine(PlayGame());


        }
    }
    public void DamageUpgrade()
    {
        if (gold >= 20)
        {
            gold -= 20;
            PScript.damage += 2;
            LevelUpUi.gameObject.SetActive(false);
            if (!UpgradesMenu)
                StartCoroutine(PlayGame());
        }
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

        HStat.text = PScript.health.ToString();
        DStat.text = PScript.damage.ToString();
        SStat.text = PScript.speed.ToString();
        AStat.text = PScript.armor.ToString();
        MHStat.text = PScript.health.ToString();
        MDStat.text = PScript.damage.ToString();
        MSStat.text = PScript.speed.ToString();
        MAStat.text = PScript.armor.ToString();


    }


    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }
    public void CharecterSelect1()
    {
        PScript.rend.sprite = Char1;
        PScript.health = 100;
        PScript.speed = 1.4f;
        PScript.armor = 1;
        PScript.damage = 3;
    }

    public void CharecterSelect2()
    {
        PScript.rend.sprite = Char2;
        PScript.health = 60;
        PScript.speed = 1.5f;
        PScript.armor = 0;
        PScript.damage = 3;
    }

    public void StaffUpgrade()
    {
        
        Hwep.SetActive(false);
        Cbut.SetActive(false);
        Hbut.SetActive(true);
        Cwep.SetActive(true);
    }

    public void OffStaffUpgrade()
    {
      
        
        Hwep.SetActive(true);
        Cbut.SetActive(true);
        Hbut.SetActive(false);
        Cwep.SetActive(false);
    }


   public IEnumerator PlayGame()
    {
        Time.timeScale = 0.75f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1;
        
    }
}
