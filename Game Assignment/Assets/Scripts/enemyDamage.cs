using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float damage;

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            if(other.GetComponent<Enemygethurt>() != null)
            {
                other.GetComponent<Enemygethurt>().DealDamage(damage);
            }
        }
    }
}
