using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed;    // Speed of rotation (degrees per second)
    public float rotationDuration; // How long the enemy rotates to face the player (in seconds)

    private bool canRotate = true;      // Flag to allow rotation
    private float rotationTimer = 0f;   // Timer to track rotation duration
    private bool attack = false;
    public float chargeSpeed = 5f;
    private Animator anim;
 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //anim = GetComponent<Animator>();
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
        Vector2 direction;
        if (player.position.y > transform.position.y)
        {
            direction = (player.position - transform.position).normalized;
        }
        else
        {
            direction = (transform.position - player.position).normalized;
        }

        // Get the target angle in degrees
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Normalize the current angle to the range [-180, 180]
        float currentAngle = NormalizeAngle(transform.eulerAngles.z);

        // Wrap the target angle to [-180, 180] for shortest path
        targetAngle = NormalizeAngle(targetAngle);

        // Determine the shortest rotation direction
        float angleDifference = targetAngle - currentAngle;

        // Wrap the angle difference to [-180, 180]
        angleDifference = Mathf.Repeat(angleDifference + 180f, 360f) - 180f;

        // Check the enemy's current facing direction (based on X scale)
        bool isFacingRight = transform.localScale.x > 0;

        // Prioritize turning in the direction the enemy is already facing
        if ((isFacingRight && angleDifference > 0) || (!isFacingRight && angleDifference < 0))
        {
            angleDifference = (angleDifference > 0) ? angleDifference - 360f : angleDifference + 360f;
        }

        // Determine the rotation step (rotate toward the shortest direction)
        float rotationStep = Mathf.Sign(angleDifference) * rotationSpeed * Time.deltaTime;

        // Ensure we don't overshoot the target angle
        if (Mathf.Abs(rotationStep) > Mathf.Abs(angleDifference))
        {
            rotationStep = angleDifference; // Snap directly to the target angle
        }

        // Apply the rotation
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle + rotationStep));
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