using UnityEngine;

public class Dalisay : Player
{
    protected override void Start()
    {
        base.Start();
        InitStats(100, 10, 5, 5f); 
    }

    public override void UseUltimate()
    {
        Debug.Log("Dalisay used their ultimate!");
    }
}
