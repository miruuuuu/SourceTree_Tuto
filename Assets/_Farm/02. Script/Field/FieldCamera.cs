using UnityEngine;

public class FieldCamera : MonoBehaviour
{
    private Transform target;

    [SerializeField] private Vector3 offset, minBound, maxBound;
    [SerializeField] private float smoothSpeed = 5f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        //타겟이 없으면 리턴
        if(target == null)
            return;
        
        //타겟 추적 + 부드럽게 이동
        Vector3 destination = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.localPosition, destination, smoothSpeed * Time.deltaTime);

        //범위 제한
        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBound.x, maxBound.x);
        smoothedPosition.z = Mathf.Clamp(smoothedPosition.z, minBound.z, maxBound.z); //y는 어차피 고정

        transform.localPosition = smoothedPosition;
    }
}
