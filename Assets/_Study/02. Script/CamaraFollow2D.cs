using UnityEngine;

public class CamaraFollow2D : MonoBehaviour
{
    private Transform target;
    public Vector3 offset;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
    }
}
