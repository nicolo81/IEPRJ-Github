using UnityEngine;

public class TankEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        // Example stats: hp, atk, def, moveSpeed
        InitStats(50, 2, 1, 1f);
    }

    public override void Attack() { } // does nothing cuz basic enemy lol fkn loser
}
