using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimeCountDown : MonoBehaviour
{
    [SerializeField]private Text timerText;

    public int Duration { get; private set; }
    public bool isPaused { get; private set; }
    private int remainingDuration;
    private UnityAction onTimerBegin;
    private UnityAction<int> onTimerChange;
    private UnityAction onTimerEnd;
    private UnityAction<bool> onTimerPause;

    private void Awake()
    {
        ResetTimer();        
    }

    private void ResetTimer()
    {
        timerText.text = "00:00";

        Duration = remainingDuration = 0;

        onTimerBegin = null;
        onTimerChange = null;
        onTimerEnd = null;

        isPaused = false;
    }

    public void SetPaused(bool paused)
    {
        isPaused = paused;

        if(onTimerPause != null)
        {
            onTimerPause.Invoke(isPaused);
        }
    }
    public TimeCountDown SetDuration (int seconds)
    {
        Duration = remainingDuration = seconds;
        return this;
    }

    public TimeCountDown Onbegin(UnityAction action)
    {
        onTimerBegin = action;
        return this;
    }

    public TimeCountDown Onchange(UnityAction<int> action)
    {
        onTimerChange = action;
        return this;
    }

    public TimeCountDown Onend(UnityAction action)
    {
        onTimerEnd = action;
        return this;
    }

    public TimeCountDown Onpause(UnityAction<bool> action)
    {
        onTimerPause = action;
        return this;
    }

    public void Begin()
    {
        if(onTimerBegin != null)
        {
            onTimerBegin.Invoke();
        }
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration > 0)
        {
            if(!isPaused)
            {
                if (onTimerChange != null)
                {
                    onTimerChange.Invoke(remainingDuration);
                }
                UpdateUI(remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1);
            }
        }
        End();
    }

    private void UpdateUI(int seconds)
    {
        timerText.text = string.Format("Time Left - {0:D2}:{1:D2}", seconds / 60, seconds % 60);
    }

    public void End()
    {
        if (onTimerEnd != null)
        {
            onTimerEnd.Invoke();
        }
        ResetTimer();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
