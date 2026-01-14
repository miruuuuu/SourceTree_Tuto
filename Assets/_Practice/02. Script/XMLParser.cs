using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

[System.Serializable]
public class XMLData
{
    public string CharID;
    public string Name;
    public int HP;
    public int Attack;

    public XMLData() { }

    public XMLData(string charID, string name, int hp, int attack)
    {
        this.CharID = charID;
        this.Name = name;
        this.HP = hp;
        this.Attack = attack;
    }
}

[System.Serializable]
[XmlRoot("Characters")]
public class CharacterList
{
    [XmlElement("Character")]
    public List<XMLData> characters;
}

public class XMLParser : MonoBehaviour
{
    public List<XMLData> datas = new List<XMLData>();

    void Start()
    {
        var dataFile = Resources.Load<TextAsset>("XMLData");
        string data = dataFile.text;

        ParsingData(data);
    }

    private void ParsingData(string data)
    {
        Debug.Log(data);

        XmlSerializer serializer = new XmlSerializer(typeof(CharacterList));

        using (StringReader reader = new StringReader(data))
        {
            CharacterList loadedData = (CharacterList)serializer.Deserialize(reader);
            datas = loadedData.characters;
        }

        foreach (XMLData d in datas)
        {
            Debug.Log($"{d.CharID} / {d.Name} / {d.HP} / {d.Attack}");
        }
    }
}