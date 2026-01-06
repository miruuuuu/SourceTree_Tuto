using UnityEngine;

public class Path : MonoBehaviour
{
    public Vector3[] points;
    public float Radius = 2f; // 도착 판정하는 반경.

    public Vector3 GetPoint(int index)
    {
        return points[index];
    }

    void OnDrawGizmos()
    {
        if (points == null)
            return;

        for (int i = 0; i < points.Length; i++)
        {
            if (i + 1 < points.Length)
            {
                Gizmos.DrawLine(points[i], points[i + 1]);
            }
        }

    }
}
