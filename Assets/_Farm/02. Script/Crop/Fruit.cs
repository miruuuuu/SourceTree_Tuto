using System;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Fruit : MonoBehaviour, ITriggerEvent, IItem
// ITriggerEvent는 상호작용, IItem는 아이템기능. 뭔가 더 역할을 하는 아이템이 있다면 도 interface 만들고 상속시키기.
{
    public Inventory Inven { get; private set; }
    public GameObject Obj { get; private set; }
    public string ItemName { get; private set; }

    [field: SerializeField] public Sprite Icon { get; private set; }

    void Awake()
    {
        Inven = FindFirstObjectByType<Inventory>();
        Obj = gameObject;

        ItemName = gameObject.name.Replace("(Clone)", ""); //복제본 이름에서 (Clone) 제거.
    }

    public void Init(Sprite icon)
    {
        //Tile의 수확 기능에서 가져와야 함.
        Icon = icon;
    }

    public void Get()
    {
        Debug.Log($"{gameObject.name.Replace("(Clone)", "")} 획득");
        PoolManager.Instance.ReleaseObject(gameObject.name.Replace("(Clone)", ""), gameObject); //사라짐.
        //Destroy(gameObject);

        //Inventory에 아이템에 대한 정보를 전달.
        Inven.GetItem(this);


    }

    public void Use()
    {

    }

    public void InteractionEnter() //플레이어와의 충돌 상호작용
    {
        Get();
    }

    public void InteractionExit()
    {

    }

}
