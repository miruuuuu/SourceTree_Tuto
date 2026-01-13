using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tile : MonoBehaviour
{
    //클릭으로 통해 농작물을 심고, 수확할 수 있는 타일
    // Field(농경지) 안에서만 작동. FieldArea에 의해서.

    public Vector2Int arrayPos; //타일배열의 위치.

    private bool isCreate = false; //이미 농작물이 심어져 있는지 여부.

    public void CreateCrop(GameObject cropPrefab)
    {
        if (isCreate)
            return;

        GameObject cropObj = Instantiate (cropPrefab);
        //GameObject cropObj = PoolManager.Instance.pool.Get(); //풀에서 농작물 오브젝트를 가져옴.
        cropObj.transform.SetParent(this.transform); //타일의 자식으로 설정
        cropObj.transform.localPosition = Vector3.zero; //타일의 중심에 위치.
        
        float randomY = Random.Range(0f, 360f); //0~360도 사이의 랜덤한 y축 회전값
        Vector3 randomRot = new Vector3(0f, randomY, 0f);
        cropObj.transform.localRotation = Quaternion.Euler(randomRot); //랜덤한 y축 회전 적용
        
        isCreate = true; //농작물이 심어졌음을 표시.
    }

}
