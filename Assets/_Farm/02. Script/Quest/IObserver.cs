using UnityEngine;

public interface IObserver
{
    string QuestName { get; }
    int CurrentCount { get; }
    bool IsCompleted { get; }

    void Notify(string questName);

    //짧고 명확하고, 당연히 같이 다닐만한 인터페이스들이라면... 한 곳에 둬도 됨.
    //클래스처럼 파일명과 같이 맞춰야 할 필요는 없기 때문에.
    //ISubject 인터페이스도 여기에 넣을 수 있음.
    //파일 이름을 고칠 필요는 있다. ex) QuestInterfaces.cs 처럼.

}
