using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChaseOscar : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 1;
    public Animator animator;
    private void followTarget()
    {
        if (target != null)
        {
            Vector3 distance = target.position - transform.position;
            if ((distance.x < 0.1) && (distance.x > -0.1))
            {
                transform.Translate(new Vector3(0, distance.y, 0) * moveSpeed * Time.deltaTime);
                if (distance.y > 0)
                    animator.SetInteger("moveDir", 4);
                else
                    animator.SetInteger("moveDir", 3);
            }
            else
            {
                transform.Translate(new Vector3(distance.x, 0, 0) * moveSpeed * Time.deltaTime);
                if (distance.x > 0)
                    animator.SetInteger("moveDir", 1);
                else
                    animator.SetInteger("moveDir", 2);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        followTarget();
    }
}
