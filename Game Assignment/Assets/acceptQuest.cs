using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class acceptQuest : MonoBehaviour
{

    public GameObject acceptQuestMenu;

    public void acceptquest()
    {
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        SceneManager.LoadScene("Stage1");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            acceptQuestMenu.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.GameIsPaused = true;
            Debug.Log("Success");
        }
    }
}
