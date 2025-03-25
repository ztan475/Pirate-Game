public class Melee : NewPlayerUnit
{
    public void Start()
    {
        Role = "Melee";
    }

    public override void Attack(NewPlayerUnit target)
    {
        target.TakeDamage(Damage);
    }

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        if (0 > Health)
        {
            Die();
        }
    }
}