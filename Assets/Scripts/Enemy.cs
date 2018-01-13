using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    const float unitsPerSecond = 2f;

    Vector3[] pathPoints;
    float[] pathPointTimings;
    float lastIterStart;

    // Use this for initialization
    void Start()
    {
        var parent = GameObject.FindGameObjectWithTag("EnemyPath");
        var pathPointTransforms = parent.GetComponentsInChildren<Transform>();
        var points = new List<Vector3>();
        var timings = new List<float>();
        var lastPosition = pathPointTransforms[0].position;
        for (var i = 1; i <= pathPointTransforms.Length; i++)
        {
            var iLoop = i % pathPointTransforms.Length;
            var currentTransformPosition = pathPointTransforms[iLoop].position;
            points.Add(currentTransformPosition);
            var timing = (lastPosition - currentTransformPosition).magnitude / unitsPerSecond;
            timings.Add(timing);
        }
        pathPoints = points.ToArray();
        pathPointTimings = timings.ToArray();
        StartCoroutine(FollowPath());
    }

    // Update is called once per frame
    IEnumerator FollowPath()
    {
        for (var i = 0; ; i = (i + 1) % pathPoints.Length)
        {
            lastIterStart = Time.timeSinceLevelLoad;
            var endTime = lastIterStart + pathPointTimings[i];
            var nextI = (i + 1) % pathPoints.Length;
            var delta = pathPoints[nextI] - pathPoints[i];
            var timeDelta = endTime - lastIterStart;
            while (Time.timeSinceLevelLoad < endTime)
            {
                var interpolationCoefficient = (Time.timeSinceLevelLoad - lastIterStart) / timeDelta;
                var newPosition = pathPoints[i] + (delta * interpolationCoefficient);
                transform.position = newPosition;
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
