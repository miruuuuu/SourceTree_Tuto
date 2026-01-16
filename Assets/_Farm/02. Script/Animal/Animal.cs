using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour, ITriggerEvent
{
    private NavMeshAgent agent;
    private Animator anim;

    private float minWaitTime = 1f, maxWaitTime = 5f; //움직이다 기다리다 하는 시간 범위

    [SerializeField] private float wanderRadius = 15f; //움직이는 반경


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            SetRandomDestination();
            anim.SetBool("IsWalk", true);

            //목적지에 도착할 때까지 대기...        !길찾는중     &&        남은거리    가 멈추는 거리보다 작을 때 (도착)
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

            anim.SetBool("IsWalk", false);
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void SetRandomDestination()
    {
        //이동 반경 내 랜덤한 위치를 찍어서 목적지로 설정 후 이동.
        var randomDir = Random.insideUnitSphere * wanderRadius;
        randomDir += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDir, out hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    public void InteractionEnter()
    {
        AnimalArea.failAction?.Invoke();

    }

    public void InteractionExit()
    {

    }


}
