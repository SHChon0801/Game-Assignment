using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class acceptQuest1 : MonoBehaviour
{
    public GameObject dialogue1;
    public GameObject acceptQuestMenu1;

    public void acceptquest()
    {
        SceneManager.LoadScene("Stage2");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogue1.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogue1.SetActive(false);
            acceptQuestMenu1.SetActive(false);
        }
    }
}
