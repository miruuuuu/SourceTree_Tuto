using System;
using UnityEngine;

public class TraceState : IState //여긴 MonoBehaviour를 넣지 않음. 넣으면 컴포넌트로 붙여야 함. 그리고 StateController에서 new가 아니라 addcomponent로 붙여야 함. <~ what a hassle
{
    private CharacterController cc; //몬스터 자신
    private Animator anim; //몬스터 애니메이터
    private Transform target; //플레이어 대상
    private MonoBehaviour mono; //MonoBehaviour가 있어야 실행 가능한 기능을 쓰기 위함. 코루틴 등.

    private GameObject prefab; //

    public TraceState(MonoBehaviour mono, CharacterController cc, Animator anim, GameObject prefab)
    {
        this.mono = mono;
        this.cc = cc;
        this.anim = anim;
        this.prefab = prefab;
    }

    public void StateEnter()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
        
        

        Debug.Log("추적 상태 시작");
    }

    public void StateUpdate()
    {
        Vector3 moveDir = (target.position - cc.transform.position).normalized;
        cc.Move(moveDir * 5f * Time.deltaTime);

        Debug.Log("추적 상태 중...");
    }

    public void StateExit()
    {
        //target = null;
        Debug.Log("추적 상태 종료");
    }

}