using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OscarController : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score = 0;
    public GameObject levelComplete;
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

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Game");
    }

    public void changeScore(int animalCount)
    {
        score += animalCount;
        text.text = score.ToString();
        Debug.Log(score);
        if (score == 2)
        {
            levelComplete.SetActive(true);
            StartCoroutine(Wait());
        }
    }

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
    void FixedUpdate()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("Kick", Input.GetAxis("Kick"));
        animator.SetFloat("Punch", Input.GetAxis("Punch"));
        animator.SetFloat("Run", Input.GetAxis("Run"));
        animator.SetFloat("Attack", Input.GetAxis("Attack"));
        animator.SetFloat("Defend", Input.GetAxis("Defend"));

        if (Input.GetAxis("Run") > 0.1f)
        {
            moveSpeed = 8;
        } else if (Input.GetAxis("Run") < 0.1f)
        {
            moveSpeed = 5;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
        //transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            ChaseOscar enemyChase = other.GetComponent<ChaseOscar>();
            enemyChase.moveSpeed = 1;
        }else if (other.gameObject.CompareTag("Animal"))
        {
            AnimalsFollow animalFollow = other.gameObject.GetComponent<AnimalsFollow>();
            animalFollow.moveSpeed = 0;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            ChaseOscar enemyChase = other.GetComponent<ChaseOscar>();
            enemyChase.moveSpeed = 0;
        }
        else if (other.gameObject.CompareTag("Animal"))
        {
            AnimalsFollow animalFollow = other.gameObject.GetComponent<AnimalsFollow>();
            animalFollow.moveSpeed = 1;
        }
    }
}
