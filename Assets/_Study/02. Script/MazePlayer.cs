using UnityEngine;

public class MazePlayer : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 moveDir;

    public float moveSpeed = 5f;
    public float rotSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveDir = new Vector3(h, v, 0f); // XY 평면에서 이동
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDir * moveSpeed;

        if (moveDir != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(Vector3.forward, moveDir);
            rb.MoveRotation(Quaternion.Lerp(transform.rotation, targetRot, rotSpeed));
        }
    }
}
