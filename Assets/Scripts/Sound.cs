using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] Transform listener;
    [SerializeField] float radius;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    
    void Update()
    {
        if (origin != null && listener != null)
        {

            float distance = Vector3.Distance(origin.position, listener.position);
            Debug.Log(distance);

            // Currently not working
            if (distance < radius)
            {
                audioSource.Stop();

            }
            else
            {
                audioSource.Play();
            }
        }
    }
}
