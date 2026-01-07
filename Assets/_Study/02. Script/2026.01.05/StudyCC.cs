using UnityEngine;

public class StudyCC : MonoBehaviour
{
    private CharacterController cc;

    private float moveSpeed = 5f;
    private float rotSpeed = 10f;

    private Vector3 verticalVelocity;
    public float gravity = -30f;
    public float jumpPower = 10f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3(h, 0, v).normalized; // 입력 방향.
        Vector3 moveVector = Vector3.zero;

        if (inputDir.magnitude > 0.1f) //DeadZone. 일정 이하의 입력을 무시함. 실수입력방지 등.
        {
            moveVector = inputDir * moveSpeed;
            Quaternion targetRot = Quaternion.LookRotation(inputDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
        }

        Jump();

        Vector3 finaleVector = (moveVector + verticalVelocity) * Time.deltaTime;
        cc.Move(finaleVector);

        // CollisionFlags flags = cc.Move(finaleVector);
        // if (flags == CollisionFlags.Above)
        //     Debug.Log("머리충돌");
        // else if (flags == CollisionFlags.Below)
        //     Debug.Log("발밑충돌");
        // else if (flags == CollisionFlags.Sides)
        //     Debug.Log("옆면충돌");
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("충돌 이벤트");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거 이벤트");
    }

    private void Jump()
    {

        if (cc.isGrounded && verticalVelocity.y < 0f)
            verticalVelocity.y = -1f; // 중력 누적방지.

        if (cc.isGrounded && Input.GetButtonDown("Jump"))
            verticalVelocity.y = jumpPower;


        verticalVelocity.y += gravity * Time.deltaTime;
    }
}
