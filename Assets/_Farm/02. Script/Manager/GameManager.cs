using Farm;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabs;
    [SerializeField] private Transform spawnPoint;

    void Start()
    {
        int index = DataManager.Instance.SelectCharacterIndex;

        GameObject character = Instantiate(characterPrefabs[index], spawnPoint.position, Quaternion.identity);

        CameraManager.onSetProperty?.Invoke(character.transform); //카메라 매니저에 플레이어 캐릭터 정보를 넘겨줌.
    }
}