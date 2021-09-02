using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    private ChaseOscar parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<ChaseOscar>();
        parent.target = null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            parent.target = other.transform;
            Debug.Log("Player enter range");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            parent.target = null;
            Debug.Log("Player exits range");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
