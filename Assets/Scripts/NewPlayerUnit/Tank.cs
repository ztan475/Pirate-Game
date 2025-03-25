
using UnityEngine;
using Random = UnityEngine.Random;

public class Tank : NewPlayerUnit
{
    public void Start()
    {
        Role = "Tank";
    }

    public override void Attack(NewPlayerUnit target)
    {
        target.TakeDamage(Damage);
    }

    public override void TakeDamage(int damage)
    {
        // Check the block Chance
        bool blockChance = Block();
        // if blockChance is false(or cant block) then take damage else leave as it is.
        if (!blockChance)
        {
            Health -= damage;
        }
        if (0 > Health)
        {
            Die();
        }
    }

    public bool Block()
    {
        return Random.Range(0, 10) > 6;
    }
}