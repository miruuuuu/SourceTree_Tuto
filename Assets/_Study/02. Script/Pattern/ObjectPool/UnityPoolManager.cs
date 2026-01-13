using UnityEngine;
using UnityEngine.Pool;

public class UnityPoolManager : MonoBehaviour
{
    //stack으로 만들어진, 유니티에서 제공하는 pool 시스템.

    public ObjectPool<GameObject> pool;
    public GameObject prefab;

    void Awake()
    {
        pool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject);
    }

    private GameObject CreateObject() //생성
    {
        GameObject obj = Instantiate(prefab, transform);
        return obj;
    }

    private void GetObject(GameObject obj) //획득
    {
        obj.SetActive(true);
    }

    private void ReleaseObject(GameObject obj) //반납
    {
        obj.SetActive(false);
    }

    //사용할 곳에서 public PoolManager poolManager; 이런식으로 참조한 다음
    //GameObject obj = poolManager.pool.Get(); //획득
    //poolManager.pool.Release(obj); //반납
}
