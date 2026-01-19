using System.Threading;
using UnityEngine;

public class Async : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Thread t = new Thread(SubThread);
        t.Start();

    }

    private void SubThread()
    {
        Debug.Log("서브 스레드 시작");
        Thread.Sleep(3000); //3초 대기
        Debug.Log("서브 스레드 종료");
    }
}
