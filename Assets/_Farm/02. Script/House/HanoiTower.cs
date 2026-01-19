using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HanoiTower : MonoBehaviour, ITriggerEvent
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel;

    [SerializeField] private GameObject[] ringPrefabs;

    [SerializeField] private BoardStick[] sticks;

    public static GameObject selectedRing;
    public static bool isSelected;

    IEnumerator Start()
    {

        for (int i = (int)hanoiLevel - 1; i >= 0; i--)
        {
            GameObject ring = Instantiate(ringPrefabs[i]);

            ring.transform.position = new Vector3(sticks[0].transform.position.x, 5f, sticks[0].transform.position.z); // Left Stick 위에 생성

            sticks[0].PushRing(ring);

            yield return new WaitForSeconds(1f);
        }
    }

    public void InteractionEnter()
    {
        CameraManager.OnChangedCamera("House", "Hanoi");

        Camera.main.cullingMask = ~(1 << 2); // '~'은 '이것만 빼고' 임. 이러면 Ignore Laycast 레이어에 있는 플레이어 캐릭터를 표시하지 않음.


    }

    public void InteractionExit()
    {
        CameraManager.OnChangedCamera("Hanoi", "House");

        Camera.main.cullingMask = -1; //모든 레이어 표시. 1 << 0 | 1 << 1 | 1 << 2 | ... 모든 비트가 켜진 상태가 됨.
    }
}