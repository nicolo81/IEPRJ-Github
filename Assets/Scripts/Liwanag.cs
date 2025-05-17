using UnityEngine;

public class Liwanag : Player
{
    protected override void Start()
    {
        base.Start();
        InitStats(80, 10, 7, 7f); 
    }

    public override void UseUltimate()
    {
        Debug.Log("Liwanag used their ultimate!");
    }
}
