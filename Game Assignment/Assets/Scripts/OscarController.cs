using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscarController : MonoBehaviour
{
    public float moveSpeed = 1;
    public Animator animator;
    public int experience = 0;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public Questing quest;

    public void RescueAnimal()
    {
       if(quest.isActive)
        {
            quest.goal.DefeatEnemy();
            if(quest.goal.isReached())
            {
                experience += quest.experienceReward;
                quest.Complete();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("Kick", Input.GetAxis("Kick"));
        animator.SetFloat("Punch", Input.GetAxis("Punch"));
        animator.SetFloat("Run", Input.GetAxis("Run"));
        animator.SetFloat("Attack", Input.GetAxis("Attack"));

        if (Input.GetAxis("Run") > 0.1f)
        {
            moveSpeed = 15;
        } else if (Input.GetAxis("Run") < 0.1f)
        {
            moveSpeed = 10;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
    }
}
