using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSet : MonoBehaviour
{
    [SerializeField] TimeCountDown timer1;
    // Start is called before the first frame update
    private void Start()
    {
        timer1.SetDuration(70)
            .Onbegin(() => Debug.Log("Time start"))
            .Onchange(s => Debug.Log("Time change" + s))
            .Onend(() => Debug.Log("Time end"))
            .Onpause(isPaused => Debug.Log("Pause : " + isPaused))
            .Begin();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            PauseMenu.GameIsPaused = true;
        }
    }
}
