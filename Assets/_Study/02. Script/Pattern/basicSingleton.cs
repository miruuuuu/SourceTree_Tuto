using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class basicSingleton : MonoBehaviour
{
    private static basicSingleton instance;
    public static basicSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<basicSingleton>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject("basicSingleton");
                    newObj.AddComponent<basicSingleton>();
                    instance = newObj.GetComponent<basicSingleton>();
                }
            }
            return instance;
        } //없으면 스스로 검사하고, 만들어서, 부여한다.
        private set => instance = value;
    }

    //오브젝트 여러개에 여러개가 붙어있으면 유일성이 보장이 안된다.

    public int level;
    public string playerName;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //씬이 전환되도 파괴되지 않음.

        } //11번줄의 유일성 보장 불가 문제를 해결하기 위한 조건문. 제일 먼저 실행된 하나만 유일하게 존재하게 된다.
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
