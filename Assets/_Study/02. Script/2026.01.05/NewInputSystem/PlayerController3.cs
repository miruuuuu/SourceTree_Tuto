using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3 : MonoBehaviour
{
    private CharacterController cc;

    private Vector2 moveInput;
    public float moveSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc= GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);
        cc.Move(moveDir * moveSpeed * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnAttack(InputValue value)
    {
        Debug.Log($"Attack! : {value.isPressed}");
    }
    
    private void OnJump(InputValue value)
    {
        bool isJump = value.isPressed;

        if (isJump)
        {
            Debug.Log("Jump!");
        }
    }

    private void OnInteraction(InputValue value)
    {
        Debug.Log($"Interact! : {value.isPressed}");
    }
}
