using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static Action<int, int> cameraAction;

    [SerializeField] private CinemachineClearShot claerShot;
    [SerializeField] private CinemachineCamera[] cameras;

    void OnEnable()
    {
        cameraAction += SetCamera;
    }

    void Start()
    {
        cameras = claerShot.GetComponentsInChildren<CinemachineCamera>();
    }

    void OnDisable()
    {
        cameraAction -= SetCamera;
    }

    public void SetCamera(int index, int priority)
    {
        //우선순위를 증감시켜 현재 카메라가 비추는 곳을 바꾼다.
        //기본 카메라 (플레이어 추적)의 우선순위는 10.

        cameras[index].Priority = priority;
    }
}
