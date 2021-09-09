using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscarDefend : MonoBehaviour
{
    public float moveSpeed = 1;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("Run", Input.GetAxis("Run"));
        animator.SetFloat("Defend", Input.GetAxis("Defend"));

        if (Input.GetAxis("Run") > 0.1f)
        {
            moveSpeed = 15;
        }
        else if (Input.GetAxis("Run") < 0.1f)
        {
            moveSpeed = 10;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float defendInput = Input.GetAxis("Defend");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
    }
}
