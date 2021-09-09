using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickItem : MonoBehaviour
{
    public Animator animator;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("pickup", true);
            FindObjectOfType<InventorySystem>().PickUp(gameObject);
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Food"))
        {
            FindObjectOfType<PlayerStat>();
        }
    }
}
