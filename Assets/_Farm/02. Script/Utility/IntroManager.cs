using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    // 버튼 입력받고 씬 로드하는 정도의 기능만 담당.

    [SerializeField] private TMP_InputField ID;
    [SerializeField] private TMP_InputField PW;

    [SerializeField] private Button createBtn;
    [SerializeField] private Button loginBtn;

    void Start()
    {
        createBtn.onClick.AddListener(() =>
        {
            //회원가입
        });
        loginBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("01. Charactor Select");
        });
    }
}
