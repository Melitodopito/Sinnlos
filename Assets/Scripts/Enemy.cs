using UnityEngine;

public class Enemy : MonoBehaviour
{
    BoxCollider2D EnemyCollider;
    Rigidbody2D EnemyRigidBody;
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] string flipTag;

    void Start()
    {
        EnemyCollider = GetComponent<BoxCollider2D>();
        EnemyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyRigidBody.linearVelocity = new Vector2(movementSpeed, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(flipTag))
        {
        movementSpeed = -movementSpeed;
        FlipEnemy();
        }
    }


    void FlipEnemy()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(EnemyRigidBody.linearVelocity.x)), 1f);
    }
}
