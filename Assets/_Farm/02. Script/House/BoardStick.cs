using System.Collections.Generic;
using UnityEngine;

public class BoardStick : MonoBehaviour
{
    public enum StickType { Left, Center, Right }
    public StickType stickType;

    [SerializeField] private HanoiTower hanoiTower;

    public Stack<GameObject> stack = new Stack<GameObject>();

    void OnMouseDown()
    {
        if (!HanoiTower.isSelected) // 링 선택
            PopRing();
        else // 링 옮기기
            PushRing(HanoiTower.selectedRing);
    }

    public void PopRing()
    {
        if (stack.Count > 0)
        {
            HanoiTower.isSelected = true;
            HanoiTower.selectedRing = stack.Pop();
        }
    }

    public void PushRing(GameObject ring)
    {
        if (!CheckRing(ring))
            return;

        ring.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        ring.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        ring.transform.position = transform.GetChild(0).position; //new Vector3(transform.GetChild(0).position.x, 1f, transform.GetChild(0).position.z);
        // 여기 주석 부분... z 값을 제대로 못 읽어오다가 지웠다가 되돌리니까 제대로 작동한다... 대체 왜?? 아무튼, y는 역순으로 쌓이니까 코드를 고쳤다.

        HanoiTower.isSelected = false;
        HanoiTower.selectedRing = null;

        stack.Push(ring);
    }

    public bool CheckRing(GameObject ring)
    {
        if (stack.Count > 0)
        {
            GameObject peekRing = stack.Peek();
            int peekNumber = peekRing.GetComponent<Ring>().ringNumber;

            if (ring.GetComponent<Ring>().ringNumber > peekNumber)
            {
                Debug.Log("<color=yellow>작은 링 위에 큰 링을 올릴 수 없습니다.</color>");
                return false;
            }
        }

        return true;
    }
}