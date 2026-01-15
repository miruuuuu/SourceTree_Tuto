using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : SingletonCore<PoolManager> //접근이 잦을 예정이기 때문에 싱글톤으로 작성됨.
{
    //public ObjectPool<GameObject> pool; pool할 대상이 하나 뿐이라면.
    //public List<ObjectPool<GameObject>> poolList = new List<ObjectPool<GameObject>>(); 좋은 접근!

    [Serializable] //using System; 필요
    public class PoolData
    {
        public string name;
        public GameObject prefab;


    }

    public List<PoolData> poolList = new List<PoolData>(); //여러가지 프리팹을 pool할 수 있다.

    //이름으로 pool에 접근이 가능하도록 하기 위함.
    private Dictionary<string, IObjectPool<GameObject>> poolDics = new Dictionary<string, IObjectPool<GameObject>>();


    public GameObject prefab; //풀링할 프리팹

    protected override void Awake() //싱글톤코어에서 이미 Awake를 쓰고 있음.
    {
        base.Awake(); //싱글톤코어의 Awake 실행

        //pool 생성 및 dictionary에 등록(초기화)
        foreach (var poolData in poolList)
        {
            poolDics[poolData.name] = new ObjectPool<GameObject>(
                createFunc: () => Instantiate(poolData.prefab), //생성
                actionOnGet: (obj) => obj.SetActive(true), //획득
                actionOnRelease: (obj) => obj.SetActive(false)); //반납
        }

        //pool = new ObjectPool<GameObject> (CreateObj, getObj, releaseObj); //+풀 생성
        /*
        pool = new ObjectPool<GameObject>(
            CreateObj,
            (obj) => obj.SetActive(true),
            (obj) => obj.SetActive(false)
        );
        이렇게 쓰기도.. 한다. 코드가 짧으면. 가능은 하다.
        */
    }

    public GameObject GetObject(string key)
    {
        if (poolDics.ContainsKey(key))
        {
            GameObject obj = poolDics[key].Get();
            return obj;
        }

        Debug.LogError($"{key}가 존재하지 않음.");
        return null;
    }

    public void ReleaseObject(string key, GameObject obj)
    {
        if (poolDics.ContainsKey(key))
        {
            poolDics[key].Release(obj);
        }
        else
        {
            Debug.LogError($"{key}가 존재하지 않음."); // <~ 게임을 일시정지한다.
        }
        return;
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
