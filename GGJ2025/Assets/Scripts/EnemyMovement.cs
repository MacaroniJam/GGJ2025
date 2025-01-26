using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed;    // Speed of rotation (degrees per second)
    public float rotationDuration; // How long the enemy rotates to face the player (in seconds)

    private bool canRotate = false;      // Flag to allow rotation
    private float rotationTimer = 0f;   // Timer to track rotation duration
    private bool attack = false;
    public float chargeSpeed = 5f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            RotateToPlayer();
            UpdateRotationTimer();
        }

        if (attack)
        {
            Attack();
        }

        if (this.transform.position.y + 15f < player.position.y)
        {
            Destroy(this.gameObject);
        }
        
    }

    void Attack()
    {
        Vector2 forward;
        //charges towards player
        if (transform.localScale.x > 0)
        {
            forward = transform.right; // Assuming right is the forward direction
        }
        else
        {
            forward = -transform.right; // Assuming left is the forward direction
        }
        
        transform.position += (Vector3)(forward * chargeSpeed * Time.deltaTime);
    }

    void RotateToPlayer()
    {
        // Calculate the direction to the player
        Vector2 direction = player.position - transform.position;

        // Get the current angle
        float currentAngle = NormalizeAngle(transform.eulerAngles.z);

        // Calculate the target angle based on the direction
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // If the enemy is facing left (scale.x < 0), flip the target angle
        if (transform.localScale.x < 0)
        {
            // Flip the angle by 180 degrees
            targetAngle += 180f;
            targetAngle = NormalizeAngle(targetAngle);
        }

        // Calculate the angle difference
        float angleDifference = targetAngle - currentAngle;

        // Ensure we rotate the correct direction (clockwise or counter-clockwise)
        float rotationStep = Mathf.Sign(angleDifference) * rotationSpeed * Time.deltaTime;

        // Prevent overshooting the target angle
        if (Mathf.Abs(rotationStep) > Mathf.Abs(angleDifference))
        {
            rotationStep = angleDifference;
        }

        // Apply the rotation
        transform.rotation = Quaternion.Euler(0, 0, currentAngle + rotationStep);
    }



    // Normalize an angle to the range [0, 360]
    private float NormalizeAngle(float angle)
    {
        return Mathf.Repeat(angle + 180f, 360f) - 180f;
    }

    void UpdateRotationTimer()
    {
        // Update the timer
        rotationTimer += Time.deltaTime;

        // Check if the rotation time has exceeded the duration
        if (rotationTimer >= rotationDuration)
        {
            canRotate = false; // Stop rotation
            attack = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canRotate = true;
        }

    }

}