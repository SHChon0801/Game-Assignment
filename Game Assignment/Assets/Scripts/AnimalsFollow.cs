using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsFollow : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 1;
    public Animator animator;
    // Start is called before the first frame update
    private void animalFollow()
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

        if (moveSpeed == 0)
        {
            animator.SetInteger("moveDir", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        animalFollow();
    }
}
