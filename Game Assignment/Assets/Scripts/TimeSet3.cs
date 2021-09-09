using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSet3 : MonoBehaviour
{
    [SerializeField] TimeCountDown timer3;
    public GameObject gameOver;
    public AudioClip gameOverSound;
    public AudioSource audioSrc;
    // Start is called before the first frame update
    private void Start()
    {
        timer3.SetDuration(90)
             .Onbegin(() => Debug.Log("Time start"))
             .Onchange(s => Debug.Log("Time change" + s))
             .Onend(() => gameOverS())
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