using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat playerstat;
    public GameObject player;

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
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
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
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
