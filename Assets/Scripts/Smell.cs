using UnityEngine;

public class Smell : MonoBehaviour
{

    [SerializeField] Transform SmellStart;
    [SerializeField] Transform SmellEnd;

    [SerializeField] float maxSmellDistance = 10f;
    [SerializeField] float preSmellLenght;

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
            Vector3 generalDirection = (SmellEnd.position - SmellStart.position).normalized;

            float distance = Vector3.Distance(SmellStart.position, SmellEnd.position);

            if (distance < maxSmellDistance)
            {
                lineRenderer.SetPosition(0, SmellStart.position);
                lineRenderer.SetPosition(1, SmellEnd.position);

            }
            else
            {
                lineRenderer.SetPosition(0, SmellStart.position);
                lineRenderer.SetPosition(1, SmellStart.position + generalDirection * preSmellLenght);
            }
        }

    }


}