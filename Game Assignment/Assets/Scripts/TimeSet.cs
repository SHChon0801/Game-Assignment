using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeSet : MonoBehaviour
{
    [SerializeField] TimeCountDown timer1;
    public GameObject gameOver;
    public AudioClip gameOverSound;
    public AudioSource audioSrc;

    // Start is called before the first frame update
    private void Start()
    {
        timer1.SetDuration(30)
             .Onbegin(() => Debug.Log("Time start"))
             .Onchange(s => Debug.Log("Time change" + s))
             .Onend(() => gameOverS() )
             .Onpause(isPaused => Debug.Log("Pause : " + isPaused))
             .Begin();
    }

    public void gameOverS()
    {
        audioSrc.PlayOneShot(gameOverSound);
        gameOver.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
