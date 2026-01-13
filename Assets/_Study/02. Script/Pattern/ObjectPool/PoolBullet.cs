using UnityEngine;

public class PoolBullet : MonoBehaviour
{
    private UnityPoolManager poolManager;

    void Awake()
    {
        poolManager = FindFirstObjectByType<UnityPoolManager>();
    }

    void OnEnable()
    {
        //총알의 기능 구현
        //...

        //3초 후에 자동으로 풀에 반납
        Invoke("ReturnToPool", 3f);
    }

    private void ReturnToPool()
    {
        poolManager.pool.Release(this.gameObject);
    }


}
