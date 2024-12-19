using UnityEngine;
using UnityEngine.Windows;
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
        float inputX = UnityEngine.Input.GetAxis("Horizontal");
        float inputY = UnityEngine.Input.GetAxis("Vertical");
        

        Vector3 movement = new Vector3(inputX * movementSpeed, inputY * movementSpeed, 0);
        movement *= Time.deltaTime;
    
        transform.Translate(movement,Space.World);
        PlayerRotates(inputX, inputY, playerTransform);

        // Is there A better way to deal with this? Perhaps just a
        // function for physical moving, another function for animation and sound? 

        
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

        if (manager.getVision() && UnityEngine.Input.GetKeyDown(instinctKey))
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

    private void PlayerRotates(float inputX, float inputY, Transform playerTransform)
    {
        // Prototype, this looks incredible dumb but it works
        switch (inputY, inputX)
        {
            // Up
            case ( > 0, 0):
                playerTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            // Down
            case ( < 0, 0):
                playerTransform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            // Left
            case ( 0, < 0):
                playerTransform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            //Right
            case (0,> 0):
                playerTransform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            // Up Left
            case ( > 0, < 0):
                playerTransform.rotation = Quaternion.Euler(0, 0, 45);
                break;
            // UP Right
            case ( > 0, > 0):
                playerTransform.rotation = Quaternion.Euler(0, 0, 315);
                break;
            // Down right
            case ( < 0, > 0):
                playerTransform.rotation = Quaternion.Euler(0, 0, 225);
                break;
            // Down left
            case ( < 0, < 0):
                playerTransform.rotation = Quaternion.Euler(0, 0, 135);
                break;

            default:
                break;

        }
        

        

    }



}
