using UnityEngine;

public class PoolController : MonoBehaviour
{
    public UnityPoolManager poolManager;
    public Transform shootPoint;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = poolManager.pool.Get(); //오브젝트 풀에서 오브젝트 획득

            bullet.transform.position = shootPoint.position;

            //총알 발사 기능.
        }
    }
}
