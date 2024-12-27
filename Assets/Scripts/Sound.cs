using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] Transform listener;
    [SerializeField] float radius;
    [SerializeField] bool soundDebug;

    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (origin != null && listener != null)
        {

            float distance = Vector3.Distance(origin.position, listener.position);
            
            if (soundDebug)
            {
                OnDrawGizmos();
            }
           
            if (distance > radius)
            {
                audioSource.Stop();
            }
            else if (distance <= radius) 
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }
    }


    // Gizmos are used to debug in sceneview
    void OnDrawGizmos()
    {
        if (origin != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(origin.position, radius);
        }
    }

}
