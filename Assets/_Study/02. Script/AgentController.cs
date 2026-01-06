using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Transform[] points;
    public int index;

    private NavMeshAgent agent;
    public NavMeshSurface surface;

    //public Transform destination;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        surface.transform.position = transform.position;
        surface.BuildNavMesh();

    }

    void Update()
    {
        // 자동으로 포인트 순회
        // if (agent.remainingDistance <= agent.stoppingDistance + 1f)
        {
            Debug.Log("목적지 변경");
            index++;

            if (index >= points.Length) // 순회한다.
                index = 0;

        }
        // agent.SetDestination(points[index].position);

        // 마우스 클릭한 위치로 이동
        /*if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }

            float dist = Vector3.Distance(transform.position, surface.transform.position);
            if (dist > 10f)
            {
                surface.transform.position = transform.position;
                surface.BuildNavMesh();
            }
            //어느 정도 움직이면 다시 베이크.
        }*/

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        var dir = new Vector3(h, 0, v).normalized;
        agent.SetDestination(transform.position + dir);

        float dist = Vector3.Distance(transform.position, surface.transform.position);
        if (dist > 10f)
        {
            surface.transform.position = transform.position;
            surface.BuildNavMesh();
        }

    }
}
