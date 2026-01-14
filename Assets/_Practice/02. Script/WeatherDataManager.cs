using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class WeatherDataManager : MonoBehaviour
{
    #region JSON 데이터 클래스
    [Serializable] //JSON 데이터 클래스를 정의합니다.
    public class WeatherDataResponse //최상위 클래스
    {
        public Response response; //응답 데이터를 포함하는 Response 객체
    }

    [Serializable]
    public class Response //Response 클래스
    {
        public Header header; //응답 헤더 정보
        public Body body; //응답 본문 정보
    }

    [Serializable]
    public class Header //Header 클래스
    {
        public string resultCode; //결과 코드
        public string resultMsg; //결과 메시지
    }

    [Serializable]
    public class Body //Body 클래스
    {
        public Items items;//날씨 예보 항목들
        public int pageNo;//페이지 번호
        public int numOfRows;//한 페이지 결과 수
        public int totalCount;//전체 결과 수
    }

    [Serializable]
    public class Items //Items 클래스
    {
        public List<WeatherItem> item; //날씨 예보 항목들의 리스트
    }

    [Serializable]
    public class WeatherItem
    {
        public string baseDate;//예보 발표 일자
        public string baseTime;//예보 발표 시각
        public string category;//예보 항목 코드
        public string fcstDate;//예보 일자
        public string fcstTime;//예보 시각
        public int fcstValue;//예보 값
        public int nx;//예보지점 X 좌표
        public int ny;//예보지점 Y 좌표
    }

    #endregion

    private string URL = "https://apis.data.go.kr/1360000/VilageFcstInfoService_2.0/getVilageFcst";

    public string key;
    public string pageNo;
    public string numOfRows;
    public string dataType;
    public string baseDate;
    public string baseTime;
    public string AxisX, AxisY;

    IEnumerator Start()
    {
        URL += $"?serviceKey={key}&pageNo={pageNo}&numOfRows={numOfRows}&dataType={dataType}&base_date={baseDate}&base_time={baseTime}&nx={AxisX}&ny={AxisY}";

        UnityWebRequest www = UnityWebRequest.Get(URL);
        Debug.Log($"URL: {URL}");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"www error : {www.error}");
        }
        else
        {
            string data = www.downloadHandler.text;
            Debug.Log(data);
        }
    }
}
