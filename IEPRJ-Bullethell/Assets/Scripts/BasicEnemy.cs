using UnityEngine;

public class BasicEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        // Example stats: hp, atk, def, moveSpeed
        InitStats(100, 2, 1, 2f);
    }

    public override void Attack() { } // does nothing cuz basic enemy lol fkn loser
}
