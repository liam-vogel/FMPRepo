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


    


    //EXPScript Exps;
    homingWeapon HWep;
    public float Exp = 0f;
    public float LevelUpAmount = 50f;
    public Image ExpBar;
    public Canvas LevelUpUi;
    public GameObject lootUI;

    //references
    public BoxCollider2D coll;
    private Rigidbody2D myRB;
    private Animator anim;
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
    public Sprite left;
    public Sprite right;
    public Sprite idle;
    //  public Transform LaunchOffset;

    //public axe LaunchOffset;

    public MovementState state;
    public enum MovementState { idle, left, right,up }

    public GameObject AxePrefab;
    public GameObject axeHolder;

    public float dirX;
    public float dirY;
   

IEnumerator AxeAttack()
{
    //Instantiate(AxePrefab, LaunchOffset.transform, axeHolder.transform.rotation);
    yield return new WaitForSeconds(3);
}
    private enum FSM { Idle, walking };


    public void TakeDamage()
    {
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("EXP"))
        {
            Exp++;
            coll.gameObject.SetActive(false);
        }

        
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
        



    }

    

    private void Update()
    {
        //      if (Input.GetKeyDown(KeyCode.Q));
        //     Instantiate(AxePrefab, axeHolder, axeHolder.transform.rotation);

        /*  while (axeActive)
          {
              AxeAttack();
          }*/

        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");


        Animate();

        myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * 3f * speed;

        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }

        HealthBar.fillAmount = health / 100;
        ExpBar.fillAmount = Exp / 100;


        if (Exp >= LevelUpAmount)
        {
            LevelUp();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            
        }

    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Enemy"))
        {
            TakeDamage();
            rend.material.color = damageColor;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        rend.material.color = normalColor;

    }

    private void Animate()
    {
        anim.SetInteger("state", (int)state);

        if (dirX > 0f)
        {
            state = MovementState.right;

            // rend.sprite = right;
            Debug.Log("right");

        }
        else if (dirX < 0f)
        {
            state = MovementState.left;
            Debug.Log("left");
            //  rend.sprite = left;
        }
        else if (dirY > 0f)
        {
            state = MovementState.idle;
            //  rend.sprite = idle;  
        }
        else
            state = MovementState.up;
    
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