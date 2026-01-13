using UnityEngine;

public class externalClass : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SimpleSingleton.Instance.level = 10;
        SimpleSingleton.Instance.playerName = "Hero";
        // 앗! 싱글톤 너무 편하다! 쉽다! 간단하다! 딸깍으로 접근 가능! 함수도 접근 가능!
        // 물론 좋은 방법은 아니다! 외부에서 접근이 많고 사용량이 많은 특정 클래스에만 사용!
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
