using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float damage;

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Enemy")
        {
            if(other.tag == "Oscar")
            {
                PlayerStat.playerstat.DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
