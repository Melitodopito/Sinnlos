using UnityEngine;

public class Door : MonoBehaviour
{
    private BoxCollider2D doorColllider2D;
    void Start()
    {
        doorColllider2D = GetComponent<BoxCollider2D>();


    }


    private void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Touched Player");
        }
    }


}
