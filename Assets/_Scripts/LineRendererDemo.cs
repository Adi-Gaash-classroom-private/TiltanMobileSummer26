using UnityEngine;

public class LineRendererDemo : MonoBehaviour
{
    LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Clear and start fresh
            lineRenderer.positionCount = 0;
        }

        // Append a point at the transform's position each frame
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
    }
}
