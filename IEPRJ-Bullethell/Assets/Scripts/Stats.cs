using UnityEngine;

public class Stats : MonoBehaviour
{
    public int hp;
    public int atk;
    public int def;
    public float moveSpeed;

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
