using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable1 : MonoBehaviour
{
    OscarController Oc;
    int animalCount = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Oc = other.GetComponent<OscarController>();
            Oc.changeScore1(animalCount);
        }
    }
}
