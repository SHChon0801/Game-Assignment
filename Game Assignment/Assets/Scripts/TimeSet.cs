using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSet : MonoBehaviour
{
    [SerializeField] TimeCountDown timer1;
    // Start is called before the first frame update
    private void Start()
    {
        timer1.SetDuration(6)
            .Onbegin(() => Debug.Log("Time start"))
            .Onchange(s => Debug.Log("Time change" + s))
            .Onend(() => Debug.Log("Time end"))
            .Onpause(p => Debug.Log("Pause : " + p))
            .Begin();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            timer1.SetPaused(!timer1.isPaused);
        }
    }
}
