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
    public float damage = 2f;
    public float speed = 1f;
    public float attackRate;
    public float attackLength;
    



    //EXPScript Exps;
    homingWeapon HWep;
    public float Exp = 0f;
    public float LevelUpAmount = 50f;
    public Image ExpBar;
    public Canvas LevelUpUi;
   
    private Rigidbody2D myRB;
    private Animator myAnim;
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

    

    private enum FSM { Idle, walking };

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("chest"))
        {
            lootui.SetActive(true);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EXP"))
        {
            Exp++;
            collision.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        // Exps = GetComponent<EXPScript>();
        damage -= armor;
        StartCoroutine("Stopwatch");
        
        
    }

    

    private void Update()
    {
        

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


    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Enemy"))
        {
            health -= damage;
            rend.material.color = damageColor;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        rend.material.color = normalColor;

    }

    private void Animate()
    {

        if (Mathf.Abs(myRB.velocity.x) > 0.1f)
        {

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