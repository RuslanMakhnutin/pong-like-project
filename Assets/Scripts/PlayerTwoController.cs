using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    public float speed = 5f; // Create a variable that reflects the speed of the player-one's movement
    private Rigidbody2D rb; // Create a variable of Rigidbody player-one's for i can manipulated his position on space

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Taking Rigidbody2D from object
    }

    void FixedUpdate()
    {
        float verticalInput = 0;

        if (Input.GetKey(KeyCode.UpArrow)) // If press key W
        {
            verticalInput = 1; // Move object up
        }

        else if (Input.GetKey(KeyCode.DownArrow)) // If press key S
        {
            verticalInput = -1; // Move object down
        }

        rb.linearVelocity = new Vector2(0, verticalInput * speed);
    }
}