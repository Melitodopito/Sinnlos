using UnityEngine;

public class Smell : MonoBehaviour
{

    [SerializeField] Transform SmellStart;
    [SerializeField] Transform SmellEnd;

    private LineRenderer lineRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SmellStart != null && SmellEnd != null)
        {
            lineRenderer.SetPosition(0, SmellStart.position);
            lineRenderer.SetPosition(1, SmellEnd.position);
        }

    }
}