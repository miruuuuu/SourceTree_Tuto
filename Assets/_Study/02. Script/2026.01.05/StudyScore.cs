using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class StudyScore : MonoBehaviour
{
    /// <summary>
    /// 싱글톤은 적게 사용하는 편이 좋으니 좀 더 중추적인 기능에 사용하고 (게임매니저 이런거)
    /// 이런건 액션을 사용하는 편이 좋음.
    /// </summary>
    
    //static <~ 다른 곳에서 가져가서 쓸 때 하나하나 할당하지 않아도 됨.
    //event <~ 아무나 막 실행하는 걸 막을 수 있음. 실행이 아니라 기능 추가를 시킴.
    
    //public static event Action onScoreUp;
    //public static event Action onScoreDown;

    public static Action<int, bool> onScore;

    private int score;

    void Start()
    {
        //onScoreUp += ScoreUp;
        //onScoreDown += ScoreDown;

        onScore += ScoreUpDown;
    }

    private void ScoreUpDown(int score, bool isUp)
    {
        if(isUp)
            this.score += score;
        else
            this.score -= score;
    }

    private void ScoreUp()
    {
        score++;
    }

    private void ScoreDown()
    {
        score--;
    }

    public static void TriggerScore()
    {
        //onScoreUp?.Invoke();
    }
}
