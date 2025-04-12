using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // Ball speed
    private Rigidbody2D rb; // Rigidbody2D variable

    private Vector2 direction; // Direction of movement

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D from this object
        direction = new Vector2(Random.Range(0.7f, -0.7f), Random.Range(0.7f, -0.7f)).normalized; // First direction ball movement (random)
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed; // move ball at a constant speed
    }

    private void OnCollisionEnter2D(Collision2D collisionReflect)
    {
        // If ball collides with an object, ball changes direction
        Vector2 normal = collisionReflect.contacts[0].normal; // Check normal of the object that was collided
        direction = Vector2.Reflect(direction, normal).normalized; // Reflect direction ball

        rb.linearVelocity = direction * speed; // Return speed ball
    }
}
