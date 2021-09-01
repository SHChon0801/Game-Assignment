using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialoguebox;
    [SerializeField] Text dialogueText;
    [SerializeField] int lettersPerSecond;

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void ShowDialog(Dialogue dialog)
    {
        dialoguebox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogueText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }
}
