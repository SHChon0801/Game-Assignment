using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerStat : MonoBehaviour
{
    public GameObject gameOver;
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
    public AudioClip hurtSound;
    public AudioClip gameOverSound;
    public AudioSource audioSrc;

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
        audioSrc.PlayOneShot(hurtSound);
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
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        Time.timeScale = 0f;
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            health = 0;
            audioSrc.PlayOneShot(gameOverSound);
            gameOver.SetActive(true);
            Wait();
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
