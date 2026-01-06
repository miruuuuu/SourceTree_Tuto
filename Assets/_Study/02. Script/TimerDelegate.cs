using System.Collections;
using UnityEngine;

public class TimerDelegate : MonoBehaviour
{
    public delegate void TimerStart();
    public TimerStart onTimerStart;

    public delegate void TimerEnd();
    public TimerEnd onTimerEnd;

    public delegate void TimerStop();
    public TimerStop onTimerStop;

    public KeyCode keyCode = KeyCode.Space;

    public float timer = 10f;
    public bool isTicking = true;

    void Awake()
    {
        onTimerStart += StartEvent;
        onTimerEnd += EndEvent;
        onTimerStop += StopEvent;
    }

    void Start()
    {
        onTimerStart?.Invoke();

        StartCoroutine(TimerRoutine());
    }

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            onTimerStop?.Invoke();
            
        }
    }

    IEnumerator TimerRoutine()
    {
        while (isTicking)
        {
            Debug.Log($"남은 시간 : {timer}");
            yield return new WaitForSeconds(1f);
            timer -= 1f;

            if (timer <= 0f)
            {
                isTicking = false;
                onTimerEnd?.Invoke();
            }
        }
    }

    void StartEvent()
    {
        Debug.Log("타이머 시작!");
    }
    void EndEvent()
    {
        Debug.Log("타이머 종료!");
    }
    void StopEvent()
    {
        isTicking = false;
        StopAllCoroutines();
        Debug.Log("타이머 중지!");
    }


}
