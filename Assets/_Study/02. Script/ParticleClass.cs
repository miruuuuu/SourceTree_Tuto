using System.Threading;
using UnityEngine;

public class ParticleClass : MonoBehaviour
{
    public TimerDelegate timerDelegate;

    public ParticleSystem ps;

    void Awake()
    {
        timerDelegate.onTimerEnd += Explosion;
    }

    public void Explosion()
    {
        ps.Play();
    }
}
