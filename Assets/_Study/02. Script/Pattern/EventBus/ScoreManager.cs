using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    void OnEnable()
    {
        EventBus.ScoreChanged += PrintScore;
    }

    void OnDisable()
    {
        EventBus.ScoreChanged -= PrintScore;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            score += 10;
            EventBus.OnScorChange(score);
        }
    }

    private void PrintScore(int newScore)
    {
        Debug.Log($"Current Score: {newScore}");
    }
}
