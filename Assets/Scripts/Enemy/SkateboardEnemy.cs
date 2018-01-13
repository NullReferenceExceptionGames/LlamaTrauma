using UnityEngine;

public class SkateboardEnemy : Enemy
{
    Vector3 minScale;
    Vector3 interpolatedScale;

    protected override byte GetMaxHealth()
    {
        return 50;
    }

    protected override int GetBounty()
    {
        return 1;
    }

    protected override void OnSpawn()
    {
        minScale = transform.localScale / 5;
        interpolatedScale = transform.localScale - minScale;
    }

    protected override void OnTakeDamage(byte health)
    {
        var healthProportion = (float)health / (float)GetMaxHealth();
        transform.localScale = (interpolatedScale * healthProportion) + minScale;
    }

    protected override void OnDie()
    {
        Destroy(gameObject);
    }
}
