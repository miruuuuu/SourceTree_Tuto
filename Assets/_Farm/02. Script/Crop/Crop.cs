using System.Collections;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public enum CropState { Level1, Level2, Level3 }
    public CropState cropState;

    [SerializeField] private CropData cropData;

    private float growthTime;
    public bool isHarvset;

    void Awake()
    {
        growthTime = cropData.growthTime;
    }

    void OnEnable()
    {
        isHarvset = false; //최초에는 수확이 불가능
        SetState(CropState.Level1); //초기상태는 레벨1

        StartCoroutine(GrowthRoutine()); //성장 시작
    }

    void OnDisable()
    {
        WeatherSystem.weatherChanged -= SetGrowth; //구독 해제
    }

    IEnumerator GrowthRoutine()
    {
        yield return new WaitForSeconds(growthTime); //성장 대기 시간
        SetState(CropState.Level2); //이후 레벨 2

        yield return new WaitForSeconds(growthTime); //성장 대기 시간
        SetState(CropState.Level3); //이후 레벨 3

        isHarvset = true; //레벨 3일 때는 수확 가능한 상태가 됨.

    }

    private void SetState(CropState newState) //상태변환
    {
        for (int i = 0; i < transform.childCount; i++) //모든 자식 오브젝트에 반복 접근해 전부 비활성화
            transform.GetChild(i).gameObject.SetActive(i == (int)newState);
        //반복 접근 중, 현재 호출에 맞지 않는 상태의 작물 접근 시, false를 반환해 비활성화
        //현재 호출에 맞는 상태의 작물 접근 시, true를 반환하며 활성화. 한줄로 줄이는데 의의가 있음.
        //transform.GetChild(i).gameObject.SetActive(false);

        //transform.GetChild((int)newState).gameObject.SetActive(true); //해당 상태에 맞는 자식 오브젝트만 활성화
    }

    //날씨의 영향을 받는 작물의 성장 속도
    private void SetGrowth(WeahterType weahterType)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            switch (weahterType)
            {
                case WeahterType.Sunny:
                    growthTime = 1f; //맑은 날 : 기본 성장 속도
                    break;
                case WeahterType.Rainy:
                    growthTime *= 0.7f; //비 오는 날 : 성장 속도 30% 증가.
                    break;
                case WeahterType.Snowy:
                    growthTime *= 0.5f; //눈 오는 날 : 성장 속도 50% 증가.
                    break;
            }
        }
    }


}
