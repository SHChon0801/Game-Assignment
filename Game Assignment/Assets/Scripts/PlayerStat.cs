using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerStat : MonoBehaviour
{
    public static PlayerStat playerstat;
    public GameObject player;
    public TextMeshPro healthText;
    public Slider healthSlider;
    public TextMeshPro apText;
    public Slider apSlider;
    public float health;
    public float maxHealth;

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
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
        apText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
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

}
