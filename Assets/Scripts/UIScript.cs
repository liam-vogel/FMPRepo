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
    public Sprite Char3;
    public Sprite Char4;
    public Canvas LevelUpUi;
    public GameObject ShieldUI;
  
    public GameObject Hbut;
    public GameObject Cbut;
    public GameObject lootui;
    public AudioSource source;
    public bool KnifeOn = false;

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

   

    //Referances
    public Collider2D coll;
    public GameObject chest;
    

    //attacks
    public GameObject Hwep;
    public GameObject Cwep;
    public GameObject attack;

    public Scrollbar scrollbar;
    public AudioClip buttonSound;

    public GameObject deathUI;
    

void Start()
    {
        //MenuUi = GetComponent<Canvas>();
       // PlayerUi = GetComponent<Canvas>();
        Time.timeScale = 0;
        MenuUi.gameObject.SetActive(true);
        PlayerUi.gameObject.SetActive(false);
       // lootui.gameObject.SetActive(false);
        SettingsMenu.gameObject.SetActive(false);
        unpauseButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        UpgradesMenu.gameObject.SetActive(false);
        CharactersMenu.gameObject.SetActive(false);
        Player.GetComponent<homingWeapon>();
        source = GetComponent<AudioSource>();
        Hbut.SetActive(true);
        Cbut.SetActive(true);
        coll = PScript.GetComponent<BoxCollider2D>();
        deathUI = GameObject.Find("DeathUI");
      //  deathUI.SetActive(false);
        scrollbar.value = 0.5f;


       // PScript.health = health;
       // PScript.speed = speed;
       // PScript.speed = damage;
       // PScript.speed = armor;

  
    }


    
    public void Volume()
    {
        PScript.ambientS.volume = scrollbar.value;
    }
    public IEnumerator Shield()
    {
        
   
         shield = true;
        
            yield return new WaitForSeconds(5f);
         shield = false;
        ShieldUI.SetActive(false);


    }

   

    public void ShieldlootButton()
    {
        Time.timeScale = 1;
        lootui.SetActive(false);
        ShieldUI.SetActive(true);
        StartCoroutine("Shield");
        // Destroy(chest);
        source.Play();

    }
    public void KnifeButton()
    {
        Time.timeScale = 1;
        lootui.SetActive(false);
        KnifeOn = true;
        source.Play();
    }

    public void EXPLootButton()
    {
        Time.timeScale = 1;
        lootui.SetActive(false);
        PScript.Exp += 100;
        //  Destroy(chest);
        source.Play();
    }
    public void GoldLootButton()
    {
        Time.timeScale = 1;
        lootui.SetActive(false);
        PScript.gold += 100;
        PlayerPrefs.SetInt("Gold", PScript.gold);
        //  Destroy(chest);
        source.Play();
    }

    public void HealthLootButton()
    {
        Time.timeScale = 1;
        lootui.SetActive(false);
        PScript.health += 100;
        // Destroy(chest);
        source.Play();
    }
    public void WeaponLootButton()
    {
        Time.timeScale = 1;
        lootui.SetActive(false);
      //  Hwep.SetActive(false);
       // Cwep.SetActive(false);
        attack.SetActive(true);
        // Destroy(chest);
        source.Play();
    }


    public void AxeWeaponButton()
    {
        
        if (PScript.gold >= 100)
        {
           
            
            PScript.gold -= 100;
            PScript.axeActive = true;
            PlayerPrefs.SetInt("Gold", PScript.gold);



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

        source.Play();
    }

    public void SMArmorUpgrade()
    {
        if(PScript.gold >= 20)
        {
            PScript.gold -= 20;
            PScript.armor++;
            LevelUpUi.gameObject.SetActive(false);
            PlayerPrefs.SetInt("Gold", PScript.gold);
        }
        
        

    }
    public void SMSpeedUpgrade()
    {
        if (PScript.gold >= 20)
        {
            PScript.gold -= 20;
            PScript.speed += 0.05f;
            LevelUpUi.gameObject.SetActive(false);
            source.Play();
            PlayerPrefs.SetInt("Gold", PScript.gold);
        }
    }

    public void SMHealthUpgrade()
    {
        if (PScript.gold >= 15)
        {
            PScript.gold -= 15;
            PScript.health += 30;
            LevelUpUi.gameObject.SetActive(false);
            PlayerPrefs.SetInt("Gold", PScript.gold);
            source.Play();

        }
    }
    public void SMDamageUpgrade()
    {
        if (PScript.gold >= 30)
        {
            PScript.gold -= 30;
            PScript.damage += 2;
            LevelUpUi.gameObject.SetActive(false);
            source.Play();
            PlayerPrefs.SetInt("Gold", PScript.gold);
        }
    }


    public void ArmorUpgrade()
    {
        


        PScript.armor++;
            LevelUpUi.gameObject.SetActive(false);
          
        StartCoroutine(PlayGame());

        source.Play();


    }
    public void SpeedUpgrade()
    {
        
        StartCoroutine(PlayGame());


        PScript.speed += 0.05f;
            LevelUpUi.gameObject.SetActive(false);
        source.Play();

    }

    public void HealthUpgrade()
    {
        
        StartCoroutine(PlayGame());

        PScript.health += 30;
            LevelUpUi.gameObject.SetActive(false);



        source.Play();
    }
    public void DamageUpgrade()
    {

        
        StartCoroutine(PlayGame());

        PScript.damage += 2;
            LevelUpUi.gameObject.SetActive(false);

        source.Play();
    }



    public void unPauseButton()
    {
        Time.timeScale = 1; 
        PlayerUi.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        unpauseButton.gameObject.SetActive(false);
        SettingsMenu.gameObject.SetActive(false);
        SettingsUi.gameObject.SetActive(false);
       


        source.Play();

    }

    public void PauseButton()
    {

        source.Play();
        unpauseButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        SettingsMenu.gameObject.SetActive(true);
        SettingsUi.gameObject.SetActive(true);
        Time.timeScale = 0;
       

    }

    public void UpgradesButton()
    {

        UpgradesMenu.gameObject.SetActive(true);
        CharactersMenu.gameObject.SetActive(false);
        Scroll.gameObject.SetActive(false);

        source.Play();
    }
    public void OffCharectersButton()
    {
        CharactersMenu.gameObject.SetActive(false);
        Scroll.gameObject.SetActive(true);
        source.Play();
    }
    public void OffUpgradesButton()
    {
        UpgradesMenu.gameObject.SetActive(false);
        Scroll.gameObject.SetActive(true);
        source.Play();
    }

    public void CharectersButton()
    {
        CharactersMenu.gameObject.SetActive(true);
        UpgradesMenu.gameObject.SetActive(false);
        Scroll.gameObject.SetActive(false);
        source.Play();
    }

    public void LevelUpButton()
    {
        LevelUpUi.gameObject.SetActive(false);
        Time.timeScale = 1;
        source.Play();

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
       


    }


    public void QuitButton()
    {
        source.Play();
        SceneManager.LoadScene(0);
    }
    public void CharecterSelect1()
    {
        PScript.rend.sprite = Char1;
        PScript.health = 100;
        PScript.speed = 1.4f;
        PScript.armor = 1;
        PScript.damage = 3;
        source.Play();
    }

    public void CharecterSelect2()
    {
        source.Play();
        PScript.rend.sprite = Char2;
        PScript.health = 60;
        PScript.speed = 1.5f;
        PScript.armor = 0;
        PScript.damage = 3;
        
   }

    public void CharecterSelect3()
    {
        source.Play();
        PScript.rend.sprite = Char3;
        PScript.health = 100;
        PScript.speed = 1.6f;
        PScript.armor = 1;
        PScript.damage = 3;
    }

     public void CharecterSelect4()
    {
        source.Play();
        PScript.rend.sprite = Char4;
        PScript.health = 150;
        PScript.speed = 1.5f;
        PScript.armor = 1;
        PScript.damage = 3;
    }
    public void StaffUpgrade()
    {
        if (PScript.gold >= 100)
        {
            PScript.gold -= 100;
            //  Hwep.SetActive(false);
            Cbut.SetActive(false);
            // Hbut.SetActive(true);
            Cwep.SetActive(true);
            source.Play();

            //deathUI.SetActive(false);
            lootui.SetActive(false);

            Time.timeScale = 1;
        }
    }

    public void StaffLoot()
    {
       
            //  Hwep.SetActive(false);
            Cbut.SetActive(false);
            // Hbut.SetActive(true);
            Cwep.SetActive(true);
            source.Play();

            //deathUI.SetActive(false);
            lootui.SetActive(false);

            Time.timeScale = 1;
        
    }

    public void OffStaffUpgrade()
    {
      if(PScript.gold >= 100)
        {
            PScript.gold -= 100;
            Hwep.SetActive(true);
            // Cbut.SetActive(true);
            Hbut.SetActive(false);
            //Cwep.SetActive(false);
            source.Play();
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
