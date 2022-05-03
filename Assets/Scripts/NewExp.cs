using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewExp : MonoBehaviour
{
    /*
    public int level;
    public float currentXp;
    public float RequiredXp;
    private float lerpTimer;
    private float delayTimer;

    [Header("UI")]
    public Image frontXpBar;
    public Image backXpBar;
   // [Header["Multiplier"]]
    public float additionMultiplier = 300;
    public float powerMultiplier = 2;
    public float divisionMultiplier = 7;

    // Start is called before the first frame update
    void Start()
    {
        frontXpBar.fillAmount = currentXp / RequiredXp;
        backXpBar.fillAmount = currentXp / RequiredXp;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXpUi();
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        GainExperienceFlatRate(1f);
    }
    public void UpdateXpUi()
    {
        float xpFraction = currentXp / RequiredXp;
        float FXP = frontXpBar.fillAmount;
        if(FXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;
            if(delayTimer > 3)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 4;
             frontXpBar.fillAmount = Mathf.Lerp(FXP, backXpBar.fillAmount, percentComplete);
            }
        }

        
            
    }
    public void GainExperienceFlatRate(float xpGained)
    {
        currentXp += xpGained;
        lerpTimer = 0f;
    }
    private int CalculateRequiredXp()
    {
        int solveForRequiredXp = 0;
        for(int levelCycle = 1; levelCycle <=; levelCycle++)
        {

        }

    }*/

}

