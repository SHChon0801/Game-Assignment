using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class acceptQuest : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject acceptQuestMenu;

    public void acceptquest()
    {
        SceneManager.LoadScene("Stage1");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogue.SetActive(true);
            Debug.Log("Success");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogue.SetActive(false);
            acceptQuestMenu.SetActive(false);
            Debug.Log("Success");
        }
    }
}
