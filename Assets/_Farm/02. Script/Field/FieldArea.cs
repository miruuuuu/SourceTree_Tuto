using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.HighDefinition;

public class FieldArea : MonoBehaviour, ITriggerEvent
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] Vector2Int fieldSize = new Vector2Int(10, 10);
    private float tileSize = 2f;

    private GameObject[,] tileArray;

    private IField field;
    private FieldSeed seed;
    private FieldHarvest harvest;

    [SerializeField] private GameObject fieldUI;
    [SerializeField] private GameObject actionUI; //현재 행동을 선택
    [SerializeField] private GameObject cropUI; //심을 작물을 선택

    [SerializeField] private Button seedButton; //심기
    [SerializeField] private Button harvestButton; //수확하기
    [SerializeField] private Button[] selectCropButtons; //작물 선택
    [SerializeField] private Button backButton; //뒤로가기

    [SerializeField] private GameObject[] cropPrefabs; //심을 수 있는 작물들


    private bool isInteraction;


    void Start()
    {
        Init();
        CreatField();
    }

    private void Init()
    {
        tileArray = new GameObject[fieldSize.x, fieldSize.y];

        seed = new FieldSeed();
        harvest = new FieldHarvest();

        seedButton.onClick.AddListener(() => //기능이 간단하므로 람다식으로 작성됨.
        {
            field = seed; //현재 행동 = 심기
            actionUI.SetActive(false); //행동 ui 끄고
            cropUI.SetActive(true); //작물 선택 ui 켜기

        });

        harvestButton.onClick.AddListener(() =>
        {
            field = harvest;
            //기능이 아직 구현되지 않았으므로 일단 비워둠.
        });

        for (int i = 0; i < selectCropButtons.Length; i++) //작물 종류수만큼 반복
        {
            int j = i; //람다식 내부에서 작동할 수 있도록 (클로저 이슈) 할당.
            selectCropButtons[i].onClick.AddListener(() => seed.selectCrop = cropPrefabs[j]); //'선택된 작물'에 작물 프리팹을 할당하는 기능... 을 버튼에 할당.
        }

        backButton.onClick.AddListener(() =>
        {
            actionUI.SetActive(true);
            cropUI.SetActive(false);
            seed.selectCrop = null; //선택된 작물 초기화
        });
    }

    void Update()
    {
        //Seed();
        //Harvast();
    }

    public void InteractionEnter()
    {
        isInteraction = true;
        CameraManager.OnChangedCamera("Player", "Field");
        fieldUI.SetActive(true);

        StartCoroutine(FieldRoutine());
    }

    public void InteractionExit()
    {
        isInteraction = false;
        CameraManager.OnChangedCamera("Field", "Player");
        fieldUI.SetActive(false);
    }

    #region 타일생성
    void CreatField()
    {
        float offsetX = (fieldSize.x - 1) * tileSize / 2f;
        float offsetY = (fieldSize.y - 1) * tileSize / 2f;

        for (int i = 0; i < fieldSize.x; i++)
        {
            for (int j = 0; j < fieldSize.y; j++)
            {
                float posX = transform.position.x + i * tileSize - offsetX;
                float posZ = transform.position.z + j * tileSize - offsetY;

                GameObject tileObj = Instantiate(tilePrefab, transform); //transform의 스케일 1이어야함

                tileObj.layer = 15;

                tileObj.name = $"Tile_{i}_{j}";
                tileObj.transform.position = new Vector3(posX, 0f, posZ);
                tileArray[i, j] = tileObj;

                tileObj.GetComponent<Tile>().arrayPos = new Vector2Int(i, j);
            }

        }

    }
    #endregion

    IEnumerator FieldRoutine()
    {
        while (isInteraction)
        {
            field?.FieldAction();
            yield return null;
        }
    }
}
