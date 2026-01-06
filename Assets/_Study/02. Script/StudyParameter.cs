using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class StudyParameter : MonoBehaviour
{
    public int number = 10;

    void Start()
    {
        ///NormalParameter(number);
        //RefParameter(ref number);
        //OutParameter(out number); //
        //int value = ReturnMethod(number);

        //SetActiveGameObject(true, Door, Window, Floor);

    }

    private void NormalParameter(int num)
    {
        Debug.Log($"호출 전 : {num}");
        num = 100;
        Debug.Log($"호출 후 : {num}");
    }

    private void RefParameter(ref int num)
    {
        Debug.Log($"호출 전 : {num}");
        num = 200;
        Debug.Log($"호출 후 : {num}");
    }

    private void OutParameter(out int num)
    {
        //여러개 반환 가능.
        num = 300; // out 매개변수는 메서드 내에서 반드시 초기화 해야 한다.
        Debug.Log($"호출 후 : {num}");

    }

    private int ReturnMethod(int number)
    {
        number = 100;
        return number;
        // 하나만 리턴할 수 있다.
    }

    private void SetActiveGameObject(bool isActive, params GameObject[] gameObjects)
    {
        //매개 변수 갯수가 매번 달라도 작동함.
        //유연하긴 한데 가독성엔 좋지 않음.
        foreach (var obj in gameObjects)
        {
            obj.SetActive(isActive);
        }
    }


}
