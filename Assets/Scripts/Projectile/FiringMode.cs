using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FiringMode
{
    public abstract void Fire(Vector3 direction, GameObject projectile);
    public abstract float GetRepeatTimeSeconds();
    public abstract string GetProjectileName();
}
