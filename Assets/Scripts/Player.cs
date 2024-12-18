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
    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;
    private Transform playerTransform;
    // Other Classes
    private GameManager manager;


    void Start()
    {
        playerColllider2D = GetComponent<BoxCollider2D>();
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  
        manager = FindObjectOfType<GameManager>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = GetComponent<Transform>();
       
        ///// TO REMOVE LATER
        //audioSource.Play();
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
        Debug.Log($"This is inpuX: {inputX} This is inputY {inputY} ");

        Vector3 movement = new Vector3(inputX * movementSpeed, inputY * movementSpeed, 0);
        movement *= Time.deltaTime;
    
        transform.Translate(movement);

        // Is there A better way to deal with this? Perhaps just a
        // function for physical moving, another function for animation and sound? 


        // Prototype
        switch (inputY)
        {
            case < 0:
                playerSpriteRenderer.flipY = true;
                break;
            default:
                playerSpriteRenderer.flipY = false;
                break;
        }
        // Prototype
        switch (inputX)
        {
            case < 0:
                playerTransform.Rotate(0.0f, 0.0f, 1.0f);
                break;
            case > 0:
                playerTransform.Rotate(0.0f, 0.0f, -1.0f);
                break;
            default:
                break;
        }

        // Animation related
        if (inputX < 0 || inputY < 0)
        {
            playerAnimator.SetBool("isMoving", true);
        }

        else
        {
            playerAnimator.SetBool("isMoving",false);
        }

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
            // Not good practise to get in every other frame, need to change this in future 
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
    
    //private void RotateSpriteVertically(SpriteRenderer SpriteRenderer)
    //{
    //    SpriteRenderer.flipY = true;
    //}



}
