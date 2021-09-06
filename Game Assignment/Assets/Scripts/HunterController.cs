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
    private Transform target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float cooldownTime;


    [SerializeField] Dialogue dialog;
    public void Interact()
    {
        DialogueManager.Instance.ShowDialog(dialog);
    }
}
