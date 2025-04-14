using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // Ball speed
    private Rigidbody2D rb; // Rigidbody2D variable

    public AudioClip collisionSound;
    private AudioSource audioSource;

    private Vector2 direction; // Direction of movement

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D from this object

        // First ball direction movement (random, but not vertical)
        do
        { direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized; } 
        while (Mathf.Abs(direction.x) < 0.3f);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed; // move ball at a constant speed
    }

    private void OnCollisionEnter2D(Collision2D collisionReflect)
    {
        audioSource.PlayOneShot(collisionSound); // Play sound when collision

        // If ball collides with an object, ball changes direction
        Vector2 normal = collisionReflect.contacts[0].normal; // Check normal of the object that was collided
        direction = Vector2.Reflect(direction, normal).normalized; // Reflect direction ball

        rb.linearVelocity = direction * speed; // Return speed ball
    }
}
