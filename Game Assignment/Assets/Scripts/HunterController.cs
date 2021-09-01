using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : MonoBehaviour
{
    [SerializeField] Dialogue dialog;
    public void Interact()
    {
        DialogueManager.Instance.ShowDialog(dialog);
    }
}
