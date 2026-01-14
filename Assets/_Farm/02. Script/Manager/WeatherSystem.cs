using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public enum WeahterType
{
    Sunny,
    Rainy,
    Snowy
}


public class WeatherSystem : MonoBehaviour
{
    public WeahterType weatherType;

    [SerializeField] private GameObject[] weatherParticles;

    public static event Action<WeahterType> weatherChanged;

    IEnumerator Start()
    {
        while (true)
        {
            int weahterCount = weatherParticles.Length;
            int ranIndex = Random.Range(0, weahterCount);

            for (int i = 0; i < weahterCount; i++)
                weatherParticles[i].SetActive(i == ranIndex);
            
            weatherType = (WeahterType)ranIndex;
            weatherChanged?.Invoke(weatherType); //날씨가 바뀔 때마다 구독자에게 알림.
            Debug.Log($"Current Weather: {weatherType}");

            yield return new WaitForSeconds(7f);
        }
    }
}
