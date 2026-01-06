using System;
using UnityEngine;

public class StudyAction : MonoBehaviour
{
    void Start()
    {
        //몬스터를 잡았을 때.. 점수 변동 시.
        StudyScore.TriggerScore();

        StudyScore.onScore(10, true); //10점 증가

        StudyScore.onScore(5, false); //5점 감소
    }
}
