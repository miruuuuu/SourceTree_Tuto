using UnityEngine;
using UnityEngine.EventSystems;

public class FieldSeed : IField
{

    private Camera mainCamera;
    public GameObject selectCrop;

    void Start()
    {
        mainCamera = Camera.main; // 이거 실행안된다. MonoBehaviour가 아니라서. 때문에...
    }

    public FieldSeed()
    {
        mainCamera = Camera.main; //생성자에 있어야 한다.
    }

    public void FieldAction() //selectCrop이 없을 땐 작동하면 안된다.
    {
        if (Input.GetMouseButtonDown(0) && selectCrop != null) //마우스 왼쪽 클릭
        {

            if (EventSystem.current.IsPointerOverGameObject()) //오입력 방지. UI 위에 마우스가 있을 땐 작동하지 않음.
                return;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, 1 << 15)) //1 << 15 : 1번에서 15칸 시프트 = 레이어 15번
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                int tileX = tile.arrayPos.x;
                int tileY = tile.arrayPos.y;

                //생성은 불가능함... Instantiate는 MonoBehaviour에서만 가능하기 때문.
                // tile이라는 클래스에게 씨앗 심기 기능을 주고, 그 안에서 Instantiate를 실행하도록 해야함.
                tile.CreateCrop(selectCrop);
            }
        }
    }
}
