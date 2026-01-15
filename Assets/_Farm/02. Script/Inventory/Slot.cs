using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    private IItem item;

    [SerializeField] private Button slotButton;
    [SerializeField] private Image slotImage;

    [SerializeField] private Image dragItem; //드래그 중인 아이템. 이미지만 있으면 되긴 함.
    private static Slot dragSlot;


    public bool IsEmpty { get; private set; } = true;

    void Awake()
    {
        slotButton.onClick.AddListener(UseItem);
    }

    void OnEnable()
    {
        slotImage.gameObject.SetActive(!IsEmpty); //아이템이 없으면 이미지 비활성화
        slotButton.interactable = !IsEmpty; //아이템이 없으면 버튼 상호작용 불가능.
    }

    public void AddItem(IItem item) //fruit를 매개변수로 쓰지 않는 이유. 작물이 아니라 장비일 수도 있고 다른 걸수도 있고.
    {
        IsEmpty = false;
        this.item = item;
        slotImage.sprite = item.Icon;

        slotImage.gameObject.SetActive(true);
        slotButton.interactable = true; //슬롯은 아이템이 있을 때만 누를 수 있다.
    }

    public void UseItem()
    {
        if (item == null) //비어있으면
            return; //돌아가고
        item.Use(); //사용하면
        item = null; //없어지고
        IsEmpty = true; //비우고
        slotImage.sprite = null; //지우고
        slotImage.gameObject.SetActive(false); //없애고
        slotButton.interactable = false; //비활성화.
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsEmpty)
            return;

        dragSlot = this;
        dragItem.sprite = item.Icon;
        dragItem.gameObject.SetActive(true);
        dragItem.raycastTarget = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        dragItem.transform.position = eventData.position; //드래그 중에는 아이템 이미지가 마우스의 드래그 위치를 따라다님.
    }

    public void OnDrop(PointerEventData eventData) //UI 위에서 놓은 것.
    {
        //아이템 정보 스왑.

        IItem tempItem = this.item; //드래그 중이던 아이템을 잠깐 담고
        SetItem(dragSlot.item); //드래그 대상 슬롯에 드래그 중이던 아이템 설정
        dragSlot.SetItem(tempItem); //

        Debug.Log("아이템 이동 완료");

        dragItem.sprite = null;
        dragItem.gameObject.SetActive(false);
        dragSlot = null;
    }

    public void OnEndDrag(PointerEventData eventData) //아무것도 없는 곳에서 놓은 것.
    {
        // 없어도 무방하나 안전하게 하기 위함.
        dragItem.sprite = null;
        dragItem.gameObject.SetActive(false);
        dragSlot = null;

        dragItem.raycastTarget = true;
    }

    public void SetItem(IItem newItem)
    {
        this.item = newItem;
        if(newItem == null)
        {
            IsEmpty = true;
            slotImage.sprite = null;
            slotImage.gameObject.SetActive(false);
            slotButton.interactable = false;
        }
        else
        {
            IsEmpty = false;
            slotImage.sprite = newItem.Icon;
            slotImage.gameObject.SetActive(true);
            slotButton.interactable = true;
        }

    }

}
