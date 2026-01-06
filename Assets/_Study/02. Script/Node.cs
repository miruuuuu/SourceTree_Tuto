using System;
using UnityEngine;

public class Node : IComparable<Node>
{
    public Node parent;
    public Vector3 pos;

    public float nodeTotalCost; // G (시작점 ~ 현재지점 비용)
    public float estimateCost; // H (현재지점 ~ 목표지점 비용)

    public bool isObstacle = false;

    public Node(Vector3 pos) // 생성자.
    {
        this.pos = pos;
        parent = null;
        nodeTotalCost = 0f;
        estimateCost = 0f;
        isObstacle = false;
    }

    public void SetObstacle()
    {
        isObstacle = true;
    }

    public float GetFCost()
    {
        return nodeTotalCost + estimateCost;
    }

    public int CompareTo(Node other)
    {
        float myF = GetFCost();
        float otherF = other.GetFCost();

        if (myF < otherF)
            return -1;
        if(myF > otherF)
            return 1;

        if (estimateCost < other.estimateCost)
            return -1;
        if (estimateCost > other.estimateCost)
            return 1;

        return 0;
    }
}
