using System;
using UnityEngine;

public class SingletonCore<T> : MonoBehaviour where T : MonoBehaviour
{
    //싱글톤 코어 <~ ?

    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindFirstObjectByType<T>(); //찾고

                if(instance == null) //그래도 없으면
                {
                    var newObj = new GameObject(typeof(T).ToString()); //새로 만들고
                    instance = newObj.AddComponent<T>(); //붙이고
                }
            }
            return instance; //반환한다.
        }
    }

    protected virtual void Awake() //상속받는 애들이 오버라이드 가능하게
    {
        if(instance == null)
        {
            instance = this as T; //형변환
            DontDestroyOnLoad(gameObject); //씬이 전환되도 파괴되지 않음.
        }
        else
            Destroy(gameObject); //이미 있으면 새 거는 파괴
        
    }
}
