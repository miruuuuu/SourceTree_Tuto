using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Slot[] slots;

    public void GetItem(IItem item) //아이템 획득
    {
        foreach (var slot in slots) //모든 슬롯을 검사
        {
            if (slot.IsEmpty) //비어있다면
            {
                slot.AddItem(item); //아이템을 슬롯에 추가.
                return;
            }
        }
    } 
}
