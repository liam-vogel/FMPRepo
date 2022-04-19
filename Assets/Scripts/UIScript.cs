using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
   [Header("ui objects")] 
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
  
    public GameObject Hbut;
    public GameObject Cbut;
    public GameObject lootui;

    public bool shield = false;
    public float ShieldDur = 5;

    //weapon stats
    public Text HStat;
    public Text SStat;
    public Text AStat;
    public Text DStat;
    public Text MHStat;
    public Text MSStat;
    public Text MAStat;
    public Text MDStat;
    

    //stats
    private float health;
    private float speed;
    private float damage;
    private float armor;
    public int gold = 100;
    public Text goldAm;
    public Text goldAmUp;

    //Referances
    public Collider2D coll;
    public GameObject chest;
    

    //attacks
    public GameObject Hwep;
    public GameObject Cwep;
    public GameObject attack;


    void Start()
    {
        //MenuUi = GetComponent<Canvas>();
       // PlayerUi = GetComponent<Canvas>();
        Time.timeScale = 0;
        MenuUi.gameObject.SetActive(true);
        PlayerUi.gameObject.SetActive(false);
        lootui.gameObject.SetActive(false);
        SettingsMenu.gameObject.SetActive(false);
        unpauseButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        UpgradesMenu.gameObject.SetActive(false);
        CharactersMenu.gameObject.SetActive(false);
        Player.GetComponent<homingWeapon>();
       
        Hbut.SetActive(true);
        Cbut.SetActive(false);
        coll = PScript.GetComponent<BoxCollider2D>();
       // chest = 
       
       // PScript.health = health;
       // PScript.speed = speed;
       // PScript.speed = damage;
       // PScript.speed = armor;


    }

    IEnumerator Shield()
    {
        
        
         shield = true;
            yield return new WaitForSeconds(5f);
         shield = false;
        
    }

    public void ShieldlootButton()
    {
        Time.timeScale = 1;
        lootui.SetActive(false);
        StartCoroutine("Shield");
        Destroy(chest);

    }

    public void EXPLootButton()
    {
        Time.timeScale = 1;
        lootui.SetActive(false);
        PScript.Exp += 100;
        Destroy(chest);

    }

    public void HealthLootButton()
    {
        Time.timeScale = 1;
        lootui.SetActive(false);
        PScript.health += 100;
        Destroy(chest);

    }
    public void WeaponLootButton()
    {
        Time.timeScale = 1;
        lootui.SetActive(false);
      //  Hwep.SetActive(false);
       // Cwep.SetActive(false);
        attack.SetActive(true);
        Destroy(chest);
        
    }


    public void AxeWeaponButton()
    {
        
        if (gold >= 100)
        {
           
            
            gold -= 100;
            PScript.axeActive = true;
            



        }
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

    public void SMArmorUpgrade()
    {
        if(gold >= 20)
        {
            gold -= 20;
            PScript.armor++;
            LevelUpUi.gameObject.SetActive(false);
          
        }
        
        

    }
    public void SMSpeedUpgrade()
    {
        if (gold >= 20)
        {
            gold -= 20;
            PScript.speed += 0.05f;
            LevelUpUi.gameObject.SetActive(false);
            
        }
    }

    public void SMHealthUpgrade()
    {
        if (gold >= 15)
        {
            gold -= 15;
            PScript.health += 30;
            LevelUpUi.gameObject.SetActive(false);
            


        }
    }
    public void SMDamageUpgrade()
    {
        if (gold >= 30)
        {
            gold -= 30;
            PScript.damage += 2;
            LevelUpUi.gameObject.SetActive(false);
            
        }
    }


    public void ArmorUpgrade()
    {
        


        PScript.armor++;
            LevelUpUi.gameObject.SetActive(false);
          
        StartCoroutine(PlayGame());
        



    }
    public void SpeedUpgrade()
    {
        
        StartCoroutine(PlayGame());


        PScript.speed += 0.05f;
            LevelUpUi.gameObject.SetActive(false);
           
        
    }

    public void HealthUpgrade()
    {
        
        StartCoroutine(PlayGame());

        PScript.health += 30;
            LevelUpUi.gameObject.SetActive(false);
            


        
    }
    public void DamageUpgrade()
    {

        
        StartCoroutine(PlayGame());

        PScript.damage += 2;
            LevelUpUi.gameObject.SetActive(false);
            
        
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
      //  MHStat.text = PScript.health.ToString();
      //  MDStat.text = PScript.damage.ToString();
      //  MSStat.text = PScript.speed.ToString();
      //  MAStat.text = PScript.armor.ToString();
        goldAm.text = "Gold:" + gold.ToString();
        goldAmUp.text = "Gold:" + gold.ToString();


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
        
      //  Hwep.SetActive(false);
        Cbut.SetActive(false);
       // Hbut.SetActive(true);
        Cwep.SetActive(true);
    }

    public void OffStaffUpgrade()
    {
      if(gold >= 100)
        {
            gold -= 100;
            Hwep.SetActive(true);
            // Cbut.SetActive(true);
            Hbut.SetActive(false);
            //Cwep.SetActive(false);
        }


    }

 

    public IEnumerator PlayGame()
    {
        Time.timeScale = 0.75f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1;
        Debug.Log("STAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAART" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "Gaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaame");
        
    }
}
