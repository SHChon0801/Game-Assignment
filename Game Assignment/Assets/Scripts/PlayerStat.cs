using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerStat : MonoBehaviour
{
    public static PlayerStat playerstat;
    public GameObject player;
    public GameObject shield;
    public Text healthText;
    public Slider healthSlider;
    public Text apText;
    public Slider apSlider;
    public float health;
    public float maxHealth;
    public float aphealth;
    public float maxAP;


     void Awake()
    {
        if(playerstat != null)
        {
            Destroy(playerstat);
        }
        else
        {
            playerstat = this;
        }
    }

    void Start()
    {
        health = maxHealth;
        aphealth = maxAP;
        setHealUI();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        setHealUI();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
        setHealUI();
    }


    private void setHealUI()
    {
        healthSlider.value = healthPercentage();
        apSlider.value = apPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
        apText.text = Mathf.Ceil(aphealth).ToString() + " / " + Mathf.Ceil(maxAP).ToString();
    }

    private void CheckOverheal()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        Debug.Log("outside");
        if(health <= 0)
        {
            Debug.Log("inside");
            health = 0;
            Destroy(player);
        }
    }

    float healthPercentage()
    {
        return health / maxHealth;
    }

    float apPercentage()
    {
        return aphealth / maxAP;
    }
}
