using UnityEngine;

public class StudyDelegate : MonoBehaviour
{
    public delegate void MyDelegate();
    public MyDelegate onKeyDown;

    public KeyCode keyCode;

    void Start()
    {
        onKeyDown += Respond;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            //string keyString = keyCode.ToString();
            onKeyDown?.Invoke();
        }
    }

    private void Respond()
    {
        Debug.Log("키 입력됨.");
    }
}
