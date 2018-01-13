using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FiringMode : MonoBehaviour
{
    protected abstract void Fire(Vector3 direction);
}
