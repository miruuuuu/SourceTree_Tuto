using UnityEngine;
using UnityEngine.AI;

public class MazeMonster : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
        
    }
}
