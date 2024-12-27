using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Enemy : MonoBehaviour
{
    // Components
    BoxCollider2D EnemyCollider;
    Rigidbody2D EnemyRigidBody;

    // Tags
    [SerializeField] string flipTag;
    [SerializeField] string damageTag;

    // Enemy Values
    [SerializeField] float hp  = 100f;
    [SerializeField] float movementSpeed = 1f;
    // Not sure if this is the best implementation, check later
    [SerializeField] float hitValue;

    // Other Classes
    private GameManager manager;

    void Start()
    {
        EnemyCollider = GetComponent<BoxCollider2D>();
        EnemyRigidBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        EnemyRigidBody.linearVelocity = new Vector2(movementSpeed, 0f);

        if(hp <= 0)
        {
            // NOT WORKING NEED CHANGE
            Debug.Log($"Removing: {gameObject.tag}");
            manager.RemoveFromGameObjects(gameObject);
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(flipTag))
        {
            movementSpeed = -movementSpeed;
            FlipEnemy();
        }
        else if (collision.collider.CompareTag(damageTag))
        {
           hp = GetsShoot(hp, hitValue);
        }
    }


    void FlipEnemy()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(EnemyRigidBody.linearVelocity.x)), 1f);
    }

    private float GetsShoot(float hp, float hitValue)
    {
        return hp -= hitValue;
    }
}
