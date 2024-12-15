using UnityEngine;
using Vector3 = UnityEngine.Vector3;


public class Player: MonoBehaviour
{

    // Commands? Change later
    [SerializeField] KeyCode instinctKey;

    // Player Variables
    [SerializeField] float movementSpeed = 1f;

    // Colliders and Rigid body
    private BoxCollider2D playerColllider2D;
    private Rigidbody2D playerRigidBody2D;
    private AudioSource audioSource;

    // Other Classes
    private GameManager manager;


    void Start()
    {
        playerColllider2D = GetComponent<BoxCollider2D>();
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  
        manager = FindObjectOfType<GameManager>();
        /// TO REMOVE LATER
        audioSource.Play();
    }


    void Update()
    {
        PlayerMoves(movementSpeed);
        PlayerFeelsEnviroment(manager, instinctKey);
        
    }


    private void PlayerMoves(float movementSpeed)
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputX * movementSpeed, inputY * movementSpeed, 0);

       

        movement *= Time.deltaTime;

        
        

        transform.Translate(movement);

    }

    private void PlayerFeelsEnviroment(GameManager manager, KeyCode instinctKey)
    {
        if (manager == null)
        {
            Debug.LogError("GameManager is not assigned!");
            return;
        }

        if (manager.getVision() && Input.GetKeyDown(instinctKey))
        {
            GameObject[] allObjects = manager.GetAllGameObjects();

            if (manager.CountObjectWithTag(allObjects, "Enemy") == 0)
            {
                Debug.Log("I Feel I should go North");
            } 
            else
            {
                Debug.Log("It's Dangerous here, I Feel I should go North");
            }
        }

        
    }



}
