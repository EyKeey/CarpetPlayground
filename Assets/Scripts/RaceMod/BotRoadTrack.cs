using System.Collections.Generic;
using UnityEngine;

public class BotPathFollower : MonoBehaviour
{
    [Header("Path Points")]
    public Transform pointsParent;
    public List<Transform> pathPoints;

    [Header("Bot Settings")]
    public float speed = 10f;
    [Range(0.0f, 1.0f)]
    public float startProgress = 0f;
    public float turnSpeed = 3f;

    private float progress;
    private int segmentCount;
    private Rigidbody rb;

    private void Awake()
    {
        pathPoints.Clear();
        for (int i = 0; i < pointsParent.childCount; i++)
        {
            pathPoints.Add(pointsParent.GetChild(i).transform);
        }
    }

    void Start()
    {
        if (pathPoints.Count < 4)
        {
            this.enabled = false;
            return;
        }

        segmentCount = pathPoints.Count - 3;
        progress = startProgress;

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            this.enabled = false;
            return;
        }
    }

    void FixedUpdate()
    {
        progress += (speed / EstimatePathLength()) * Time.deltaTime;
        if (progress >= 1.0f)
        {
            progress = 0f; // Reset to 0 when we reach the end
        }

        Vector3 newPosition = GetPositionOnSpline(progress);
        Vector3 forwardDirection = GetDirectionOnSpline(progress);

        Vector3 steering = Vector3.RotateTowards(transform.forward, forwardDirection, turnSpeed * Time.deltaTime, 0f);
        rb.MoveRotation(Quaternion.LookRotation(steering));

        rb.MovePosition(newPosition);
    }

    float EstimatePathLength()
    {
        float totalLength = 0f;
        Vector3 previousPoint = GetPositionOnSpline(0f);
        int steps = 20;
        for (int i = 1; i <= steps; i++)
        {
            Vector3 nextPoint = GetPositionOnSpline((float)i / steps);
            totalLength += Vector3.Distance(previousPoint, nextPoint);
            previousPoint = nextPoint;
        }
        return totalLength;
    }

    Vector3 GetPositionOnSpline(float t)
    {
        int currentSegment = Mathf.Min(Mathf.FloorToInt(t * segmentCount), segmentCount - 1);
        float localT = (t * segmentCount) - currentSegment;

        Vector3 p0 = pathPoints[currentSegment].position;
        Vector3 p1 = pathPoints[currentSegment + 1].position;
        Vector3 p2 = pathPoints[currentSegment + 2].position;
        Vector3 p3 = pathPoints[currentSegment + 3].position;

        return CatmullRomInterpolation(p0, p1, p2, p3, localT);
    }

    Vector3 GetDirectionOnSpline(float t)
    {
        Vector3 position1 = GetPositionOnSpline(t);
        Vector3 position2 = GetPositionOnSpline(Mathf.Min(t + 0.01f, 1f));
        return (position2 - position1).normalized;
    }

    Vector3 CatmullRomInterpolation(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 a = 2f * p1;
        Vector3 b = p2 - p0;
        Vector3 c = 2f * p0 - 5f * p1 + 4f * p2 - p3;
        Vector3 d = -p0 + 3f * p1 - 3f * p2 + p3;

        return 0.5f * (a + (b * t) + (c * t * t) + (d * t * t * t));
    }

    private void OnDrawGizmos()
    {
        if (pathPoints == null || pathPoints.Count < 4) return;

        Gizmos.color = Color.red;
        Vector3 previousPoint = pathPoints[1].position;
        for (float t = 0; t < 1; t += 0.02f)
        {
            Vector3 nextPoint = GetPositionOnSpline(t);
            Gizmos.DrawLine(previousPoint, nextPoint);
            previousPoint = nextPoint;
        }
    }
}
