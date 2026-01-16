using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : SingletonCore<QuestManager>, ISubject
{
    //퀘스트를 발행하고 관리하는 클래스
    //아직은 퀘스트가 많을 때는 Monobehaviour로, 많아진다면 싱글톤에서 관리하는 편이 편함.

    private List<IObserver> observers = new List<IObserver>();

    [SerializeField] private Button[] questButtons;
    [SerializeField] private QuestData[] questDatas;

    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < questButtons.Length; i++) //각 버튼에 접근
        {
            int j = i;

            questButtons[i].onClick.AddListener(() => SetButton(j)); //각 버튼에 셋퀘스트를 할당
        }
    }

    private void SetButton(int index)
    {
        Quest newQuest = new Quest(questDatas[index]); //퀘스트[인덱스]에 해당하는 퀘스트를 뉴퀘스트에 할당.
        questButtons[index].gameObject.SetActive(false);
        //questButtons[index].interactable = false; //퀘스트를 받았으니 버튼 비활성화.
    }
    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
        Debug.Log($"{observer.QuestName} 퀘스트가 추가되었습니다.");
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
        Debug.Log($"{observer.QuestName} 퀘스트가 제거되었습니다.");
    }

    public void NotifyListeners(string questName)
    {
        //퀘스트가 많아지면 이렇게 쓰면 안됨. remove가 돌아가서 갯수가 줄어들고 리스트가 짧아지면 문제가 생김.
        // foreach (var observer in observers)
        // {
        //     observer.Notify(questName);
        // }

        for (int i = observers.Count - 1; i >= 0; i--) //역순으로 써야함.
            observers[i].Notify(questName);


    }
}
