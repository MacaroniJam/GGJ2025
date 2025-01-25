using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    public float moveSpeed;
    public float floatSpeed;
    private Vector2 movementInput;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementInput.x = Input.GetAxis("Horizontal"); // Returns a value between -1 and 1

        // Combine upward float speed and horizontal movement
        float xVelocity = movementInput.x * moveSpeed;
        float yVelocity = floatSpeed; // Always move upward

        // Apply velocity to Rigidbody2D
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);

    }


}
