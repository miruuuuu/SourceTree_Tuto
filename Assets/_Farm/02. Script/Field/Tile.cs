using System;
using UnityEngine;

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
        cropObj.transform.SetParent(this.transform); //타일의 자식으로 설정
        cropObj.transform.localPosition = Vector3.zero; //타일의 중심에 위치.
        
        isCreate = true; //농작물이 심어졌음을 표시.
    }

}
