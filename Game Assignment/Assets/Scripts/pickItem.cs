using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<InventorySystem>().PickUp(gameObject);
            gameObject.SetActive(false);
        }
    }
}
