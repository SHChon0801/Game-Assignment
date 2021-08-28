using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscarController : MonoBehaviour
{
    public float moveSpeed = 1;
    public Animator animator;
    public int experience = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
    }
}
