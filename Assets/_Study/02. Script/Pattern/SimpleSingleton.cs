using UnityEngine;

public class SimpleSingleton : MonoBehaviour
{
    public static SimpleSingleton Instance { get; private set; }

    public int level;
    public string playerName;

    //SimpleSingleton.Instance.level = 10; <~ 이런식으로 접근 가능
    // 앗! 싱글톤 너무 편하다! 쉽다! 간단하다! 딸깍으로 접근 가능! 함수도 접근 가능!
    // 물론 좋은 방법은 아니다! 외부에서 접근이 많고 사용량이 많은 특정 클래스에만 사용!
    //포폴에 싱글톤 너무 많으면 갈군다고 한다!

    void Awake()
    {
        Instance = this;
    }

    public void LevelUp()
    {
        level++;
    }
}
