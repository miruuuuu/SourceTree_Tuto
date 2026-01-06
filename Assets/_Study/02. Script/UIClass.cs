using UnityEngine;

public class UIClass : MonoBehaviour
{
    public TimerDelegate timerDelegate;

    public GameObject startUI;
    public GameObject endUI;
    public GameObject stopUI;

    void Awake()
    {
        timerDelegate.onTimerStart += ShowStartUI;
        timerDelegate.onTimerEnd += ShowEndUI;
        timerDelegate.onTimerStop += ShowStopUI;
    }

    public void ShowStartUI()
    {
        startUI.SetActive(true);
        endUI.SetActive(false);
        stopUI.SetActive(false);
    }

    public void ShowEndUI()
    {
        startUI.SetActive(false);
        endUI.SetActive(true);
        stopUI.SetActive(false);
    }

    public void ShowStopUI()
    {
        startUI.SetActive(false);
        endUI.SetActive(false);
        stopUI.SetActive(true);
    }
}
