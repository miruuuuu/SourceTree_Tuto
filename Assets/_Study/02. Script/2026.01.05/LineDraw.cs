using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    private LineRenderer line;

    private int lineCount;

    public Color color;

    public float lineWidth = 0.05f;

    public List<GameObject> lines = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //드래그 시작
        {
            GameObject lineObj = new GameObject("Line");
            line = lineObj.AddComponent<LineRenderer>();
            line.useWorldSpace = false;

            line.startWidth = lineWidth;
            line.endWidth = lineWidth;
            line.startColor = color;
            line.endColor = color;

            line.material = new Material(Shader.Find("Universal Render Pipeline/Particles/Unlit"));

            lines.Add(lineObj);
        }
        else if (Input.GetMouseButton(0)) //드래그
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; //카메라로부터의 거리

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            line.positionCount = ++lineCount;
            line.SetPosition(lineCount - 1, worldPos);
        }
        else if (Input.GetMouseButtonUp(0)) //드래그 종료
        {
            lineCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (var line in lines)
                Destroy(line.gameObject);

            lines.Clear();
        }
    }
}
