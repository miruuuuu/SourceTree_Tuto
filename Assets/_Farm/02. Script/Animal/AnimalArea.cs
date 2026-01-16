using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalArea : MonoBehaviour, ITriggerEvent
{
    /// 1. 플레이어가 동물 우리로 입장 시,
    /// 2. 깃발이 랜덤 위치에 배치됨 + 타이머가 시작됨.
    /// 3. 동물과 부딪히면 깃발 위치가 랜덤 위치에 재배치됨.
    /// 4. 플레이어가 동물 우리를 나갈 때 타이머가 종료되며, 걸린 시간이 출력됨.

    public static Action failAction;

    [SerializeField] private GameObject flag;
    [SerializeField] private TextMeshProUGUI timerUI;

    private BoxCollider coll;

    private float timer;
    private bool isInteract;

    private void Awake()
    {
        coll = GetComponent<BoxCollider>();
        //SetFlag(Vector3.zero, false);
    }

    void OnEnable()
    {
        failAction += () => SetRandomPosition();
    }

    void OnDisable()
    {
        failAction -= () => SetRandomPosition();
    }

    public void InteractionEnter()
    {
        isInteract = true;
        timerUI.gameObject.SetActive(true);
        CameraManager.OnChangedCamera("Player", "Animal");
        SetRandomPosition();
        StartCoroutine(AnimalRoutine());
    }

    public void InteractionExit()
    {
        isInteract = false;
        timerUI.gameObject.SetActive(false);
        CameraManager.OnChangedCamera("Animal", "Player");

        Debug.Log($"깃발을 가지고 나오는데 걸린 시간 : {(int)timer}초");
        timer = 0f;
    }

    IEnumerator AnimalRoutine()
    {
        while (isInteract)
        {
            timer += Time.deltaTime;

            int min = Mathf.FloorToInt(timer / 60f);
            int sec = Mathf.FloorToInt(timer % 60f);
            timerUI.text = $"{min:D2}:{sec:D2}";
            yield return null;
        }
    }

    private void SetRandomPosition()
    {
        float randomX = Random.Range(coll.bounds.min.x, coll.bounds.max.x);
        float randomZ = Random.Range(coll.bounds.min.z, coll.bounds.max.z);

        Vector3 randomPos = new Vector3(randomX, 0f, randomZ);

        SetFlag(randomPos, true);
    }

    private void SetFlag(Vector3 pos, bool isActive)
    {
        flag.transform.SetParent(transform);
        flag.transform.position = pos;
        flag.SetActive(isActive);
    }
}
