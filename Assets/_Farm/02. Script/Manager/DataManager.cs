using System;
using UnityEngine;

namespace Farm
{
    public class DataManager : SingletonCore<DataManager> //씬이 전환되어도 사라지지 않아야 하기 때문에.
    {
        private int selectCharacterIndex;
        public int SelectCharacterIndex
        {
            get
            {
                return selectCharacterIndex;
            }
            set
            {
                Debug.Log($"선택한 캐릭터는 {value}번 캐릭터입니다.");
                selectCharacterIndex = value;
            }
        }

        public GameObject Player { get; set; }
        public string UserID { get; set; }


    }
}