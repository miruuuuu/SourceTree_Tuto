using Farm;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabs;
    [SerializeField] private Transform spawnPoint;
    
    void Start()
    {
        int index = DataManager.Instance.SelectCharacterIndex;

        Instantiate(characterPrefabs[index], spawnPoint.position, Quaternion.identity);
    }
}