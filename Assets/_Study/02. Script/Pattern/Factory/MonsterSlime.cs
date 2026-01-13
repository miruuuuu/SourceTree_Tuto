using UnityEngine;

public class MonsterSlime : MonsterCore
{
    public override string Name => "슬라임";

    public override void Attack()
    {
        Debug.Log("슬라임이 공격");
    }
    
}