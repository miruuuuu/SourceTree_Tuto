using UnityEngine;

public class StateController : MonoBehaviour
{
    private IState currentState;

    private IState idle, attack, patrol, trace;

    private CharacterController cc;
    private Animator anim;
    [SerializeField] public GameObject prefab;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }


    void Start()
    {
        idle = new IdleState();
        patrol = new PatrolState();
        attack = new AttackState();
        //attack = gameObject.AddComponent<AttackState>(); //만약 MonoBehaviour를 상속받은 상태라면 이렇게 컴포넌트로 붙여야 함.
        //MonoBehaviour 쓴다고 이렇게까지 할 필요는 음..

        trace = new TraceState(this, cc, anim, prefab);

        currentState = idle;
    }

    void Update()
    {
        currentState?.StateUpdate();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetState(idle);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SetState(patrol);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SetState(trace);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SetState(attack);
        }

    }

    public void SetState(IState newState)
    {
        if (currentState != newState)
        {
            currentState?.StateExit();
            currentState = newState;
            currentState?.StateEnter();
        }

    }
}
