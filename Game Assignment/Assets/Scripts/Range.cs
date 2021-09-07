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
            parent.animator.SetBool("isMoveRight", false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            parent.target = null;
            parent.animator.SetInteger("moveDir", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
