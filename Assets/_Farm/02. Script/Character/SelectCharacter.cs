using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

namespace Farm
{
    public class SelectCharacter : MonoBehaviour
    {

        public FadeEvent fadeEvent;

        [SerializeField] private Transform centerPivot;

        [SerializeField] private Animator[] characterAnims;

        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;
        [SerializeField] private Button selectButton;

        private int characterIndex;
        private bool isTurn; //캐릭터 회전 중에는 회전 버튼을 못 누르게 막는 용도.

        void Start()
        {
            leftButton.onClick.AddListener(TurnLeft); //델리게이트가 사용되고 있다.
            rightButton.onClick.AddListener(TurnRight);
            selectButton.onClick.AddListener(Select);

        }

        private void TurnLeft() //왼쪽으로 회전
        {
            if (isTurn)
                return;

            characterIndex--;
            if (characterIndex < 0)
                characterIndex = 3;

            var targetRot = centerPivot.rotation * Quaternion.Euler(0f, -90, 0f);
            StartCoroutine(TurnRoutine(targetRot));

        }

        private void TurnRight() //오른쪽으로 회전
        {
            if (isTurn)
                return;

            characterIndex++;
            if (characterIndex > 3)
                characterIndex = 0;

            var targetRot = centerPivot.rotation * Quaternion.Euler(0f, 90, 0f);
            StartCoroutine(TurnRoutine(targetRot));

        }

        IEnumerator TurnRoutine(Quaternion tartgetRot) //매개변수 = 회전 방향
        {
            isTurn = true;

            while (isTurn)
            {
                centerPivot.rotation = Quaternion.Slerp(centerPivot.rotation, tartgetRot, Time.deltaTime * 10f); //돌리기
                yield return null; //기다리기

                var angle = Quaternion.Angle(centerPivot.rotation, tartgetRot); //두 쿼터니언의 각도 차이
                if (angle < 0.1f) //충분히 가까워졌다면
                {
                    isTurn = false; //회전 끝
                    centerPivot.rotation = tartgetRot; //정확히 맞추기
                    Debug.Log("회전 완료");
                }
            }

            centerPivot.rotation = tartgetRot;
            isTurn = false;

        }

        private void Select() //현재 캐릭터를 선택
        {
            DataManager.Instance.SelectCharacterIndex = characterIndex; //현재 선택한 캐릭터 인덱스를 저장.
            StartCoroutine(SelectRoutine());
        }

        IEnumerator SelectRoutine()
        {
            characterAnims[characterIndex].SetTrigger("Select"); //춤추기
            yield return new WaitForSeconds(5f); //5초 대기

            FadeEvent.fadeAction?.Invoke(3f, Color.black, false); //페이드 아웃
            yield return new WaitForSeconds(3f); //3초 대기
            
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}
