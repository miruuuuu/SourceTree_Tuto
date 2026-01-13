using UnityEngine;

public class BasicFSM : MonoBehaviour
{
    public enum MonsterState {Idle, Patrol, Trace, Attack}
    public MonsterState monsterState;

    void Update()
    {
        switch (monsterState)
        {
            case MonsterState.Idle:
                Debug.Log("Monster is Idling");
                break;
            case MonsterState.Patrol:
                Debug.Log("Monster is Patrolling");
                break;
            case MonsterState.Trace:
                Debug.Log("Monster is Tracing");
                break;
            case MonsterState.Attack:
                Debug.Log("Monster is Attacking");
                break;
        }
    }

    public void SetState(MonsterState newState)
    {
        if(monsterState != newState)
            monsterState = newState;
    }
}
