using UnityEngine;

public class AttackState : IState
{
    public void StateEnter()
    {
        Debug.Log("공격 상태 시작");
    }

    public void StateUpdate()
    {
        Debug.Log("공격 상태 중...");
    }

    public void StateExit()
    {
        Debug.Log("공격 상태 종료");
    }
}
