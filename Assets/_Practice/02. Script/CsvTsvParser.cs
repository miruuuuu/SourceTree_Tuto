using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CsvTsvParser : MonoBehaviour
{
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
        //TextAsset dataFile = Resources.Load<TextAsset>("CSVData");
        TextAsset dataFile = Resources.Load<TextAsset>("TSVData");

        string data = dataFile.text;
        ParsingData(data);
    }

    private void ParsingData(string data)
    {
        string[] rows = data.Split('\n');

        foreach (string row in rows)
        {
            Debug.Log(row);
        }

        for (int i = 1; i < rows.Length; i++) //첫 번째 행은 헤더이므로 1부터 시작
        {
            string row = rows[i].Trim(); //앞뒤 공백 제거

            //string[] col = row.Split(','); //쉼표로 구분
            string[] col = row.Split('\t'); //탭으로 구분

            CharacterData characterData = new CharacterData(
                col[0],
                col[1],
                int.Parse(col[2]),
                int.Parse(col[3])
            );
            characterDatas.Add(characterData);
        }
    }

}