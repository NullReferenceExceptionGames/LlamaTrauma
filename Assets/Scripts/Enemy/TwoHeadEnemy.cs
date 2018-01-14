using UnityEngine;

public class TwoHeadEnemy : Enemy
{
    [SerializeField] GameObject deathEnemy;

    protected override byte GetMaxHealth()
    {
        return 150;
    }

    protected override int GetBounty()
    {
        return 15;
    }

    protected override void OnSpawn()
    {
    }

    protected override void OnTakeDamage(byte health)
    {
    }

    protected override void OnDie()
    {
        var newEnemy = Instantiate(deathEnemy);
        var e = newEnemy.GetComponent<Enemy>();
        e.lastIterStart = lastIterStart;
        e.i = i;
        Destroy(gameObject);
    }
}
