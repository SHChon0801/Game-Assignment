using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSet2 : MonoBehaviour
{
    [SerializeField] TimeCountDown timer2;
    // Start is called before the first frame update
    private void Start()
    {
        timer2.SetDuration(60)
             .Onbegin(() => Debug.Log("Time start"))
             .Onchange(s => Debug.Log("Time change" + s))
             .Onend(() => Debug.Log("Time end"))
             .Onpause(isPaused => Debug.Log("Pause : " + isPaused))
             .Begin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
