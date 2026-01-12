using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform clearShot;
    //그냥 부모 오브젝트일 뿐이라 trasnform이면 된다. chnemachineClearShot일 필요 없음.

    private static event Action<string, string> onChangeCamera; //외부에서 접근 불가

    private Dictionary<string, CinemachineCamera> cameraDics = new Dictionary<string, CinemachineCamera>();
    //이름으로 호출하면 카메라가 잡히도록

    void Awake()
    {
        if (clearShot == null)
            return;

        for(int i=0; i < clearShot.childCount; i++)
        {
            Transform child = clearShot.GetChild(i);
            CinemachineCamera cam = child.GetComponent<CinemachineCamera>();

            if (!cameraDics.ContainsKey(child.name)) //중복 방지. ContainsKey : 해당 키가 딕셔너리에 있는지 확인
            {
                cameraDics.Add(child.name, cam); //<~ 와우! 이제 이름으로 카메라를 찾을 수 있다!
            }
        }
    }

    void OnEnable()
    {
        onChangeCamera += SetCamera;
    }

    void OnDisable()
    {
        onChangeCamera -= SetCamera;
    }

    private void SetCamera(string from, string to)
    {
        cameraDics[from].Priority = 0; //현재 카메라의 우선순위가 낮아진다.
        cameraDics[to].Priority = 10; //목표 카메라의 우선순위가 높아져 활성화된다.
    }

    public static void OnChangedCamera(string from, string to)
    {
        onChangeCamera?.Invoke(from, to);
    }
    
}
