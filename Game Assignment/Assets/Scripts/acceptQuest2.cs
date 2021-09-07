using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class acceptQuest2 : MonoBehaviour
{
    public GameObject dialogue2;
    public GameObject acceptQuestMenu2;

    public void acceptquest()
    {
        SceneManager.LoadScene("Stage3");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogue2.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogue2.SetActive(false);
            acceptQuestMenu2.SetActive(false);
        }
    }
}
