using System;
using System.Collections.Generic;
using UnityEngine;

public class JSONParser : MonoBehaviour
{
    [Serializable]
    public class CharacterListWrapper
    {
        public CharacterData[] characters;
    }

    [Serializable]
    public class CharacterData //캐릭터 데이터 클래스
    {
        public string CharID;
        public string name;
        public int hp;
        public int Attack;

        public CharacterData(string CharID, string name, int hp, int Attack) //생성자. 객체 생성 시 값 초기화.
        {
            this.CharID = CharID;
            this.name = name;
            this.hp = hp;
            this.Attack = Attack;
        }
    }

    [SerializeField] private List<CharacterData> characterDatas = new List<CharacterData>();

    void Start()
    {
        TextAsset dataFile = Resources.Load<TextAsset>("JSONData");

        string data = dataFile.text;
        ParsingData(data);
    }

    private void ParsingData(string data)
    {
        CharacterListWrapper characterListWrapper = JsonUtility.FromJson<CharacterListWrapper>(data);

        foreach (CharacterData characterData in characterListWrapper.characters)
        {
            characterDatas.Add(characterData);
        }
    }

}
