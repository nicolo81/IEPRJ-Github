using UnityEngine;

public class Stats : MonoBehaviour
{
    [HideInInspector] public int hp;
    [HideInInspector] public int atk;
    [HideInInspector] public int def;
    [HideInInspector] public float moveSpeed;

    // Constructor to initialize stats directly
    public void InitStats(int hp, int atk, int def, float moveSpeed)
    {
        this.hp = hp;
        this.atk = atk;
        this.def = def;
        this.moveSpeed = moveSpeed;
    }

    // Method to update stats during gameplay
    public void UpdateStats(int newHp, int newAtk, int newDef, float newMoveSpeed)
    {
        hp = newHp;
        atk = newAtk;
        def = newDef;
        moveSpeed = newMoveSpeed;
    }
}
