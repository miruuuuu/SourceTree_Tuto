using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    private Animator anim;

    private Vector3 moveInput;
    private Vector3 moveVector;
    private Vector3 verticalVelocity;

    private float currSpeed; //쉬프트 입력에 따라 walkSpeed 또는 runSpeed 할당
    private float walkSpeed = 3f;
    private float runSpeed = 6f;

    [SerializeField] private float rotSpeed = 10f;
    [SerializeField] private float gravity = -30f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Turn();
        SetAnimation();
    }

    private void OnTriggerEnter(Collider other)
    {
        var interactable = other.GetComponent<ITriggerEvent>();
        if (interactable != null)
            interactable.InteractionEnter();
    
    }

    private void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponent<ITriggerEvent>();
        if (interactable != null)
            interactable.InteractionExit();

    }

    void Move()
    {
        if (moveInput.magnitude >= 0.1f)
        {
            //  변수  =              조건               ? 참일 때 값 : 거짓일 때 값. <~~ 삼항연산자
            currSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed; //쉬프트 누르면 달리기, 아니면 걷기.

            if (cc.isGrounded && verticalVelocity.y < 0) //땅에 있고, 중력이 작용 중일 때
                verticalVelocity.y = -1f; //바닥에 잘 붙어있게 함.

            // 떠 있을 때는 gravity만큼의 중력이 적용.
            verticalVelocity.y += gravity * Time.deltaTime; //중력 적용

            moveVector = moveInput.normalized * currSpeed;

            Vector3 finalMovement = (moveVector + verticalVelocity) * Time.deltaTime;

            cc.Move(finalMovement);
        }
        else
        {
            currSpeed = 0f;
            cc.Move(verticalVelocity * Time.deltaTime); //가만히 있을 때도 중력 적용
        }
    }

    void Turn()
    {
        if (moveInput.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
        }
    }

    void SetAnimation()
    {
        // 블렌드 트리에 의해서 이동 속도에 따라 애니메이션 전환
        // 입력이 없을 땐 속도 0 = Idle
        // WASD 입력시 속도 3 = Walk
        // Shift 입력시 속도 6 = Run

        anim.SetFloat("Speed", currSpeed);

    }

    private void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveInput = new Vector3(inputDir.x, 0, inputDir.y);
        //moveVector = Vector3.zero; //점프는 없지만 가상 중력이 필요함.

    }
}
