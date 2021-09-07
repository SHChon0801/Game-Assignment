using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerReceiveDamage : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PlayerStat>() != null)
            {
                other.GetComponent<PlayerStat>().DealDamage(damage);
            }
        }
    }
}
