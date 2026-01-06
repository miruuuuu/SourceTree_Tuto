using System;
using UnityEngine;

public class SoundClass : MonoBehaviour
{
    public TimerDelegate timerDelegate;

    void Awake()
    {
        timerDelegate.onTimerStart += StartSound;
        timerDelegate.onTimerEnd += EndSound;
        timerDelegate.onTimerStop += StopSound;
    }
    
    public void StartSound()
    {

    }

    public void EndSound()
    {

    }

    public void StopSound()
    {

    }
}
