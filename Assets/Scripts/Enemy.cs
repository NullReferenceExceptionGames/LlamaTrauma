using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    const float unitsPerSecond = 0.2f;
    Vector3[] pathPoints;
    float[] pathPointTimings;
    float lastIterStart;

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
        for (var i = 0; i < pathPointTransforms.Count - 1; i++)
        {
            var currentPosition = pathPointTransforms[i].position;
            points.Add(currentPosition);
            var timing = (pathPointTransforms[i + 1].position - currentPosition).magnitude / unitsPerSecond;
            timings.Add(timing);
        }
        points.Add(pathPointTransforms[pathPointTransforms.Count - 1].position);
        pathPoints = points.ToArray();
        pathPointTimings = timings.ToArray();
        StartCoroutine(FollowPath());
    }

    int GetNumberBetweenBrackets(string name)
    {
        var startIndex = name.IndexOf("(") + 1;
        var endIndex = name.IndexOf(")");
        var substring = name.Substring(startIndex, endIndex - startIndex);
        return int.Parse(substring);
    }

    // Update is called once per frame
    IEnumerator FollowPath()
    {
        for (var i = 0; i < pathPoints.Length - 1; i++)
        {
            lastIterStart = Time.timeSinceLevelLoad;
            var endTime = lastIterStart + pathPointTimings[i];
            var nextI = (i + 1);
            var delta = pathPoints[nextI] - pathPoints[i];
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
                Destroy(gameObject);
                yield break;
            }
        }
    }
}
