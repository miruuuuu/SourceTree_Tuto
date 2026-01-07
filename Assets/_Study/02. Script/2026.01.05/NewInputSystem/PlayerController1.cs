using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D.IK;

public class PlayerController1 : MonoBehaviour
{
    private CharacterController cc;

    private Vector2 moveInput;
    public float moveSpeed = 5f;
    public float rotSpeed = 10f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (moveInput.magnitude >= 0.1f)
        {
            Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y).normalized;
            cc.Move(moveDir * moveSpeed * Time.deltaTime);

            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
    }
}
