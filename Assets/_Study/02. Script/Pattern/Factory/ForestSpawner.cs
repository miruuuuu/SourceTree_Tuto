using System.Collections;
using UnityEngine;

public class ForestSpawner : MonsterFactory
{
    protected override MonsterCore CreateMonster(string type)
    {
        MonsterCore monster = null;
        switch (type)
        {
            case "슬라임":
                monster = new MonsterSlime();
                break;
            //case "오크":
            //    monster = new MonsterOrc();
            //    break;
        }

        return monster;

        //CaveSpawner.cs는 다른 type의 몬스터를 생성하도록 오버라이드.. 스테이지 별 차이를 줄 수 있겠다.

        IEnumerator Start()
        {
            while (true)
            {
                int ranMonster = Random.Range(0, 1); //0~0

                string monsterType = ranMonster == 0 ? "슬라임" : "오크";
                Spawn(monsterType);

                yield return new WaitForSeconds(1f);
            }
        }
        
    }
}
