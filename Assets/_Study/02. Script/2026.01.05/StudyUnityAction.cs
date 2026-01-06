using UnityEngine;
using UnityEngine.UI;

public class StudyUnityAction : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button.onClick.AddListener(MethodA);
        button.onClick.AddListener(ClearScore);
        button.onClick.AddListener(ResetPlayerPosition);
    }

    void MethodA()
    {
        Debug.Log("버튼 클릭됨");
    }

    private void ClearScore()
    {
        Debug.Log("점수 초기화");
        
    }

    private void ResetPlayerPosition()
    {
        Debug.Log("플레이어 위치 초기화");
    }


}
