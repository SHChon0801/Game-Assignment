using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : MonoBehaviour
{
    public Transform hunter;
    public LayerMask hunterMask;
    public float hunterLength;
    public float attackDistance;
    public float moveSpeed;
    public float cooldown;

    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float cooldownTime;

    void Awake()
    {
        cooldownTime = cooldown;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(inRange)
        {
            hit = Physics2D.Raycast(hunter.position, Vector2.left, hunterLength, hunterMask);
            RaycastDebugger();
        }

        if(hit.collider != null)
        {
            EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }
        if(inRange == false)
        {
            anim.SetBool("canWalk", false);
            StopAttack();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Oscar")
        {
            target = other.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if(distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        if(cooling)
        {
            Cooldown();
            anim.SetBool("isAttack",false);
        }
    }

   void Move()
    {
        anim.SetBool("canWalk", true);
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("hunter"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position,targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        cooldown = cooldownTime;
        attackMode = true;
        anim.SetBool("canWalk", false);
        anim.SetBool("isAttack", true);
    }

    void Cooldown()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0 && cooling && attackMode)
        {
            cooling = false;
            cooldown = cooldownTime;
        }
    }
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("isAttack", false);
    }

    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(hunter.position, Vector2.left * hunterLength, Color.red);
        }    
        else
        {
            Debug.DrawRay(hunter.position, Vector2.left * hunterLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    [SerializeField] Dialogue dialog;
    public void Interact()
    {
        DialogueManager.Instance.ShowDialog(dialog);
    }
}
