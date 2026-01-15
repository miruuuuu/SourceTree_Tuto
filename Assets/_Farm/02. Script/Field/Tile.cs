using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tile : MonoBehaviour
{
    //클릭으로 통해 농작물을 심고, 수확할 수 있는 타일
    // Field(농경지) 안에서만 작동. FieldArea에 의해서.

    public Vector2Int arrayPos; //타일배열의 위치.

    private GameObject cropObj;
    private GameObject fruitPrefab;
    private int maxFruitCount;

    private bool isCreate = false; //이미 농작물이 심어져 있는지 여부.

    #region 작물 심기
    public void CreateCrop(GameObject cropPrefab)
    {
        if (isCreate)
            return;

        cropObj = PoolManager.Instance.GetObject(cropPrefab.name);
        //cropObj = Instantiate (cropPrefab);

        //GameObject cropObj = PoolManager.Instance.pool.Get(); //풀에서 농작물 오브젝트를 가져옴.
        cropObj.transform.SetParent(this.transform); //타일의 자식으로 설정
        cropObj.transform.localPosition = Vector3.zero; //타일의 중심에 위치.

        float randomY = Random.Range(0f, 360f); //0~360도 사이의 랜덤한 y축 회전값
        Vector3 randomRot = new Vector3(0f, randomY, 0f);
        cropObj.transform.localRotation = Quaternion.Euler(randomRot); //랜덤한 y축 회전 적용

        isCreate = true; //농작물이 심어졌음을 표시.

        cropObj.GetComponent<Crop>().SetCropData(out fruitPrefab, out maxFruitCount);
    }
    #endregion


    #region 작물 수확
    public void HarvestCrop()
    {
        if (isCreate)
        {
            Crop crop = cropObj.GetComponent<Crop>();
            if (crop.cropState == Crop.CropState.Level3)
            {
                isCreate = false; //수확 가능 상태일 때만 수확 가능.

                string cropName = cropObj.name.Replace("(Clone)", ""); //<~ (Clone)을 제거하겠다.
                PoolManager.Instance.ReleaseObject(cropName, cropObj); //pool을 사용할 때.

                StartCoroutine(HarvestRoutine());
            }

        }
    }

    IEnumerator HarvestRoutine()
    {
        int randomAmount = Random.Range(1, maxFruitCount);

        for (int i = 0; i < randomAmount; i++)
        {
            //GameObject fruitObj = Instantiate(fruitPrefab); pool을 이용하도록 변경.
            GameObject fruitObj = PoolManager.Instance.GetObject(fruitPrefab.name);

            fruitObj.transform.position = this.transform.position + Vector3.up * 0.5f;
            Rigidbody fruitRb = fruitObj.GetComponent<Rigidbody>();

            float randomX = Random.Range(-1f, 1f);
            float randomZ = Random.Range(-1f, 1f);

            Vector3 forceDir = new Vector3(randomX, 3f, randomZ).normalized;
            fruitRb.AddForce(forceDir * 5f, ForceMode.Impulse);

            yield return new WaitForSeconds(0.25f);

            //수확하면 작물이 사라지고, 수확물이 푱 튀어나옴.
        }
    }
    #endregion
}
