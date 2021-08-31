using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemygethurt : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBar;
    public Slider healthBarSlider;

    void Start()
    {
        health = maxHealth;  
    }

    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        health -= damage;
        checkDeath();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        checkOverheal();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    private void checkOverheal()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void checkDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
}
