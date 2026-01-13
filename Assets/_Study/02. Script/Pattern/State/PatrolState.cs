using UnityEngine;

public class PatrolState : IState
{
    public void StateEnter()
    {
        Debug.Log("순찰 상태 시작");
    }

    public void StateUpdate()
    {
        Debug.Log("순찰 상태 중...");
    }

    public void StateExit()
    {
        Debug.Log("순찰 상태 종료");
    }
}
