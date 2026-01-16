using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Slot[] slots;

    public void GetItem(IItem item) //아이템 획득
    {
        //획득한 아이템을 퀘스트 매니저가 인식할 수 있는 이름으로 가공
        string questName = item.ItemName.Replace("_Fruit", "");
        QuestManager.Instance.NotifyListeners(questName); //아이템 획득 시 퀘스트 매니저에 알림.

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
