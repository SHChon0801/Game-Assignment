using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodforHeal : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerStat>().HealCharacter(20);
            Destroy(gameObject);
        }
    }
}
