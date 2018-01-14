using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    const float unitsPerSecond = 0.2f;
    Vector3[] pathPoints;
    float[] pathPointTimings;
    public float lastIterStart;
    public int i = 0;
    byte health = 50;

    protected abstract byte GetMaxHealth();
    protected abstract int GetBounty();
    protected abstract void OnSpawn();
    protected abstract void OnTakeDamage(byte health);
    protected abstract void OnDie();

    // Use this for initialization
    void Start()
    {
        var parent = GameObject.FindGameObjectWithTag("EnemyPath");
        var pathPointTransforms = parent.GetComponentsInChildren<Transform>().ToList();
        pathPointTransforms.Remove(parent.transform);
        pathPointTransforms = pathPointTransforms.OrderBy(
            point => GetNumberBetweenBrackets(point.name)
        ).ToList();
        var points = new List<Vector3>();
        var timings = new List<float>();
        for (var j = 0; j < pathPointTransforms.Count - 1; j++)
        {
            var currentPosition = pathPointTransforms[j].position;
            points.Add(currentPosition);
            var timing = (pathPointTransforms[j + 1].position - currentPosition).magnitude / unitsPerSecond;
            timings.Add(timing);
        }
        points.Add(pathPointTransforms[pathPointTransforms.Count - 1].position);
        pathPoints = points.ToArray();
        pathPointTimings = timings.ToArray();
        OnSpawn();
        StartCoroutine(FollowPath());
    }

    int GetNumberBetweenBrackets(string name)
    {
        var startIndex = name.IndexOf("(") + 1;
        var endIndex = name.IndexOf(")");
        var substring = name.Substring(startIndex, endIndex - startIndex);
        return int.Parse(substring);
    }

    IEnumerator FollowPath()
    {
        for (; i < pathPoints.Length - 1; i++)
        {
            lastIterStart = Time.timeSinceLevelLoad;
            var endTime = lastIterStart + pathPointTimings[i];
            var nextI = (i + 1);
            var delta = pathPoints[nextI] - pathPoints[i];
            transform.rotation = Quaternion.LookRotation(delta);
            var timeDelta = endTime - lastIterStart;
            while (Time.timeSinceLevelLoad < endTime)
            {
                var interpolationCoefficient = (Time.timeSinceLevelLoad - lastIterStart) / timeDelta;
                var newPosition = pathPoints[i] + (delta * interpolationCoefficient);
                transform.position = newPosition;
                yield return new WaitForFixedUpdate();
            }
            if (nextI == pathPoints.Length - 1)
            {
                Camera.main.GetComponent<CreateTower>().TakeDamage(GetBounty());
                Destroy(gameObject);
                yield break;
            }
        }
    }

    public void TakeDamage(byte damage)
    {
        if (damage < health)
        {
            health -= damage;
            OnTakeDamage(health);
        }
        else
        {
            Camera.main.GetComponent<CreateTower>().money += GetBounty();
            OnDie();
        }
    }
}
