using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGet : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f); //캐릭터 생성까지 잠깐 대기
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        gameObject.GetComponent<CinemachineCamera>().Follow = player.transform;
        gameObject.GetComponent<CinemachineCamera>().LookAt = player.transform;
    }
}
