using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{



    //Stats
    public float armor = 2;
    public float health = 100;
    public float damage = 3f;
    public float speed = 1f;
    public float attackRate;
    public float attackLength;
    private UIScript UI;
    public GameObject deathUI;

    public GameObject goldobj;


    //EXPScript Exps;
    homingWeapon HWep;
    public float Exp = 0f;
    public float LevelUpAmount = 50f;
    public Image ExpBar;
    public Canvas LevelUpUi;
    public GameObject lootUI;
    public GameObject KnifePf;
    public float maxHealth;

    //references
    public BoxCollider2D coll;
    private Rigidbody2D myRB;
    public Animator anim;
    public Image HealthBar;
    public Text timer;
    private float time;
    private float milliseconds;
    private float minutes;
    private float seconds;
    public SpriteRenderer rend;
    private Color damageColor = Color.red;
    private Color normalColor = Color.white;
    public GameObject lootui;
    public AudioSource ambientS;
    // public AudioClip ambientSound;
    public bool axeActive = false;
    // public GameObject lootUI;
    //  public Sprite left;
    //   public Sprite right;
    //  public Sprite idle;
    //  public Transform LaunchOffset;
    public ParticleSystem bloodEffect;

    //public axe LaunchOffset;

    public MovementState state;
    public enum MovementState { idle, left, right, up, down }

    public GameObject AxePrefab;
    public GameObject axeHolder;

    public float dirX;
    public float dirY;
    public GameObject player;
    public float Kfirerate = 1f;
    public float Knextfire = 0f;

    public int gold = 100;
    public Text goldAm;
    public Text goldAmUp;

    public GameObject WS1;
    public GameObject WS2;

    public PlayerScript PS;
    public GameObject[] enemys;
    public GameObject[] exps;


    IEnumerator AxeAttack()
    {
        //Instantiate(AxePrefab, LaunchOffset.transform, axeHolder.transform.rotation);
        yield return new WaitForSeconds(3);
    }
    private enum FSM { Idle, walking };


    public void TakeDamage()
    {

        health -= damage;
        bloodEffect.Play();


    }
 


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("EXP"))
        {
            Exp++;
            Destroy(coll.gameObject);
        }


        if (coll.CompareTag("HealthUp"))
        {
            health += 30;
            Destroy(coll.gameObject);
        }

        if (coll.CompareTag("Gold"))
        {
            gold = gold += 2;
            PlayerPrefs.SetInt("Gold", gold);
            Destroy(coll.gameObject);
            Debug.Log(gold);
            Debug.Log("hi");
        }


    }
    public IEnumerator WaveSswitch()
    {
        WS2.SetActive(false);
        WS1.SetActive(true);
        yield return new WaitForSeconds(240f);
        WS2.SetActive(true);
        WS1.SetActive(false);

    }
        

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       // rend = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        // Exps = GetComponent<EXPScript>();
        damage -= armor;
        StartCoroutine("Stopwatch");
        ambientS = GetComponent<AudioSource>();
        lootUI = GameObject.Find("lootUI");
        lootUI.SetActive(false);
        Knextfire = Time.time + Kfirerate;
        ambientS.volume = 0.2f;
        gold = 100;
        Debug.Log(gold);
        StartCoroutine(("WaveSswitch"));
        deathUI = GameObject.Find("DeathUI");
        deathUI.SetActive(false);
    }

    public void IncreaseHealth(int level)
    {
        maxHealth += (health * 0.01f) * ((100 - level) * 0.01f);
        health = maxHealth;
    }

    private void Update()
    {
        // knifetim = Time.deltaTime;
        //      if (Input.GetKeyDown(KeyCode.Q));
        //     Instantiate(AxePrefab, axeHolder, axeHolder.transform.rotation);

        /*  while (axeActive)
          {
              AxeAttack();
          }*/

        goldAm.text = "Gold:" + gold.ToString();
        goldAmUp.text = "Gold:" + gold.ToString();

        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");


        Animate();

        myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * 3f * speed;

        if (health <= 0)
        {
            // SceneManager.LoadScene(0);
            deathUI.SetActive(true);
            Time.timeScale = 0;

            enemys = GameObject.FindGameObjectsWithTag("Enemy");
            exps = GameObject.FindGameObjectsWithTag("EXP");

            foreach (GameObject enemy in enemys)
            {
                Destroy(enemy);

            }

            foreach (GameObject exp in exps)
            {
                Destroy(exp);

            }


        }

        HealthBar.fillAmount = health / 100;
        ExpBar.fillAmount = Exp / 100;


        if (Exp >= LevelUpAmount)
        {
            LevelUp();
        }

        if ( Time.time > Knextfire)
        {
            Knextfire = Time.time + Kfirerate;
            Instantiate(KnifePf,player.transform.position, Quaternion.identity);
            
        }

    }

    public void DeathUI()
    {

        deathUI.SetActive(false);
        Time.timeScale = 1;
        health = 100;
        WS1.SetActive(true);
        WS2.SetActive(false);
        armor = 1;
        speed = 1.5f;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Enemy"))
        {
          //  if(!UI.shield)
          //  {
                TakeDamage();
                rend.material.color = damageColor;
           // }
            

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        rend.material.color = normalColor;

    }

    public void Animate()
    {
        anim.SetInteger("state", (int)state);

        if (dirX > 0f)
        {
            state = MovementState.right;

            // rend.sprite = right;
         

        }
        else if (dirX < 0f)
        {
            state = MovementState.left;
         
            //  rend.sprite = left;
        }
        else if (dirY > 0f)
        {
            state = MovementState.up;
            //  rend.sprite = idle;  
        }
        else if (dirY < 0f)
        {
            state = MovementState.down;

        }
        else
        {
            state = MovementState.idle;
        }
          
    
    }





    public void LevelUp()
    {
        LevelUpUi.gameObject.SetActive(true);
        Time.timeScale = 0;
        Exp = 0;
        LevelUpAmount += 20;
        //health += 30;
        //speed += 0.05f;
        //armor++;
       // HWep.speed++;
       // HWep.rotateSpeed++;
      

    }
  

   

    IEnumerator Stopwatch()
    {
        while (true)
        {
            time += Time.deltaTime;
            milliseconds = (int)((time - (int)time) * 100);
            seconds = (int)(time % 60);
            minutes = (int)(time / 60 % 60);

            timer.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);

            yield return null;
        }
    }


}