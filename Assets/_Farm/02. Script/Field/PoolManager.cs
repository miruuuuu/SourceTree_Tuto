using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : SingletonCore<PoolManager> //접근이 잦을 예정이기 때문에 싱글톤으로 작성됨.
{
    public ObjectPool<GameObject> pool;
    public GameObject prefab; //풀링할 프리팹

    protected override void Awake() //싱글톤코어에서 이미 Awake를 쓰고 있음.
    {
        base.Awake(); //싱글톤코어의 Awake 실행
        pool = new ObjectPool<GameObject> (CreateObj, getObj, releaseObj); //+풀 생성
        /*
        pool = new ObjectPool<GameObject>(
            CreateObj,
            (obj) => obj.SetActive(true),
            (obj) => obj.SetActive(false)
        );
        이렇게 쓰기도.. 한다. 코드가 짧으면. 가능은 하다.
        */ 
    }

    private GameObject CreateObj()
    {
        GameObject obj = Instantiate(prefab);
        return obj;
    }

    private void getObj(GameObject obj)
    {
        obj.SetActive(true);
    }
    
    private void releaseObj(GameObject obj)
    {
        obj.SetActive(false);
    }
    
}
