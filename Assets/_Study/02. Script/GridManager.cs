using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public Node[,] nodes;

    private Vector3 origin;

    public int rows = 10;
    public int columns = 10;
    public float gridCellSize = 1f;

    void Awake()
    {
        origin = transform.position;
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        CalculateObstacles();
    }

    private void CalculateObstacles()
    {
        nodes = new Node[rows, columns];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                //격자에 노드를 생성
                var cellPos = GetGridCellCenter(index);
                Node node = new Node(cellPos);
                nodes[i, j] = node;
                index++;

            }
        }

        if (obstacles.Length > 0)
        {
            foreach (var obstacle in obstacles)
            {
                int indexCell = GetGridIndex(obstacle.transform.position);
                if (indexCell == -1)//범위 밖일 경우 아래에 있는 기능을 무시하고 다음 반복으로
                    continue;
                int row = GetRow(indexCell);
                int col = GetColumn(indexCell);
                nodes[row, col].SetObstacle();
            }
        }
    }

    private Vector3 GetGridCellCenter(int index) //Grid의 중앙 위치 확인
    {
        var cellPos = GetGridCellPosition(index);

        cellPos.x += gridCellSize / 2f;
        cellPos.z += gridCellSize / 2f;
        return cellPos;
    }

    private Vector3 GetGridCellPosition(int index) //Grid의 위치 확인
    {
        int row = GetRow(index);
        int col = GetColumn(index);

        float x = col * gridCellSize;
        float z = row * gridCellSize;

        return new Vector3(x, 0, z);
    }

    public int GetGridIndex(Vector3 pos)
    {
        if (!isInBounds(pos))
            return -1;

        Vector3 localPos = pos - origin;
        int col = (int)((pos.x - origin.x) / gridCellSize);
        int row = (int)((pos.z - origin.z) / gridCellSize);

        return row * columns + col;
    }

    private bool isInBounds(Vector3 pos)
    {
        float width = columns * gridCellSize;
        float height = rows * gridCellSize;

        return pos.x >= origin.x && pos.x < origin.x + width &&
               pos.z >= origin.z && pos.z < origin.z + height;
    }

    public int GetRow(int index)
    {
        return index / columns;

    }

    public int GetColumn(int index)
    {
        return index % columns;

    }

    public void GetNeighborNodes(Node node, List<Node> neighbors)
    {
        int nodeIndex = GetGridIndex(node.pos);
        if (nodeIndex == -1)
            return;
        
        int row = GetRow(nodeIndex);
        int col = GetColumn(nodeIndex);

        AssignNeighbor(row - 1, col, neighbors);     //상
        AssignNeighbor(row + 1, col, neighbors);     //하
        AssignNeighbor(row, col - 1, neighbors);     //좌
        AssignNeighbor(row, col + 1, neighbors);     //우

    }

    public void AssignNeighbor(int row, int col, List<Node> neighbors)
    {

    }

    public void ResetNodes()
    {
        foreach(var node in nodes)
        {
            node.nodeTotalCost = 0;
            node.estimateCost = 0;
            node.parent = null;
        }

    }

    void OnDrawGizmos()
    {
        if (rows == 0 || columns == 0 || gridCellSize == 0)
            return;

        Gizmos.color = Color.white;

        float width = columns * gridCellSize;
        float height = rows * gridCellSize;

        for (int i = 0; i <= rows; i++) //이걸 i < rows로 하면 맨 아래 선이 안그려짐
        {
            var startPos = transform.position + i * gridCellSize * Vector3.forward;
            var endPos = startPos + width * gridCellSize * Vector3.right;
            Gizmos.DrawLine(startPos, endPos);
        }

        for (int i = 0; i <= columns; i++)
        {
            var startPos = transform.position + i * gridCellSize * Vector3.right;
            var endPos = startPos + width * gridCellSize * Vector3.forward;
            Gizmos.DrawLine(startPos, endPos);
        }
    }
}