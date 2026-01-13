using System.Collections;
using System.Collections.Generic;  //이거 필요.
using UnityEngine;


public class StudyObjectPool : MonoBehaviour
{
    //보통 뭐 스택과 큐를 활용하게 됨.

    public Queue<GameObject> objQueue = new Queue<GameObject>();

    public GameObject objPrefab; //풀링할 오브젝트의 프리팹.
    public Transform parent;

    void Start()
    {

    }

    private void CreateObject(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(objPrefab, parent);
            EnqueueObject(obj);
        }
    }

    public void EnqueueObject(GameObject newObj)
    {
        Rigidbody rb = newObj.GetComponent<Rigidbody>(); //리지드 바디를 취득해서
        rb.linearVelocity = Vector3.zero; //속도 초기화
        rb.angularVelocity = Vector3.zero; //각속도 초기화
        newObj.SetActive(false); //끄고
        objQueue.Enqueue(newObj); //큐에 넣기
    }

    public GameObject DequeueObject()
    {
        if(objQueue.Count == 0)
        {
            CreateObject(1); //큐가 비어있으면 오브젝트 하나 더 생성. 풀링할 오브젝트가 없으면 기능이 작동하지 않으니까.
        }

        GameObject obj = objQueue.Dequeue(); //1개 디큐로 꺼내기
        obj.SetActive(true); //활성화시키기
        return obj;
        //이게 총알이면, shot()에 총소리랑 총구섬광, 총알위치 지정, DequeueObject() 이렇게 들어가 있을거고
        //총알 스크립트에는 앞으로 슝 날아가는 스크립트랑 + 맞았을 때 비활성화 + EnqueueObject() 이런게 들어가 있을듯.
        //발사 스크립트, 총알 스크립트는 public StudyObjectPool objectPool; 이런식으로 오브젝트풀 기능을 참조해야 함.
    }
}
