using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    //public static event Action action1;
    //public static event Action action2;

    public static event Action<int> ScoreChanged;

    public static void OnScorChange(int newScore)
    {
        ScoreChanged?.Invoke(newScore);
    }
}
