using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] Transform listener;
    [SerializeField] float radius;
    [SerializeField] Sprite soundDistanceSprite;

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
            //DebugSound();
           
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



    //void DebugSound()
    //{
    //    SpriteRenderer soundDistanceSpriteRenderer;


    //    float distance = Vector3.Distance(origin.position, listener.position);
    //    Debug.Log("THis is distance" +  distance);

    //    soundDistanceSpriteRenderer = gameObject.AddComponent<SpriteRenderer>();

    //    soundDistanceSpriteRenderer.sprite = soundDistanceSprite;


    //}

}
