using UnityEngine;

public class FastEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        // Example stats: hp, atk, def, moveSpeed
        InitStats(10, 2, 1, 4f);
    }

    public override void Attack() { } // does nothing cuz basic enemy lol fkn loser
}
