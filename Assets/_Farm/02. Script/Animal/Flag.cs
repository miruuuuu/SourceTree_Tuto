using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private Vector3 offsetPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //깃발에 플레이어가 닿으면 깃발은 플레이어를 따라감.
            transform.SetParent(other.transform);
            transform.localPosition = offsetPos;
            transform.localRotation = Quaternion.identity;
        }
    }
}
