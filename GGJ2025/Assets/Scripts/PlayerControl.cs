using UnityEngine;
using UnityEngine.Rendering.Universal;
using PrimeTween;
public class PlayerControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int life = 2;

    private Rigidbody2D rb;
    public float moveSpeed;
    public float floatSpeed;
    public float maxSpeed;
    public float slowDownRate;
    private Vector2 movementInput;
    private bool slowDown = false;

    public Transform lantern;
    public Light2D light2D;

    public Transform cam;
    public float delay;

    public Transform circle;

    // New variables for life cooldown
    private bool canLoseLife = true; // Flag to control if life can be lost
    public float lifeCooldownTime = 3f; // Time in seconds before the player can lose life again
    private float lifeCooldownTimer = 0f; // Timer to track the cooldown period


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        light2D.intensity = 6;
        light2D.falloffIntensity = 0.5f;
    }
    private void Update()
    {
        if (slowDown)
        {
            if (floatSpeed > 1)
            {
                //adjust the rate of slowing down
                floatSpeed -= slowDownRate *Time.deltaTime;
            }
            else
            {
                slowDown = false;
            }
        }

        if (floatSpeed < 1)
        {
            floatSpeed = 1;
        }

        if (!canLoseLife)
        {
            lifeCooldownTimer -= Time.deltaTime;

            if (lifeCooldownTimer <= 0f)
            {
                canLoseLife = true; // Allow life loss again after cooldown
            }
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //lantern position = player position
        lantern.position = this.transform.position;
        circle.position = this.transform.position;

        //camera y position = player y position delayed
        if (this.transform.position.y > 0 && floatSpeed == 1)
        {

            float speed = 1f;

            // Smoothly adjust the camera's Y position
            float smoothTime = 0.3f; // Larger values = slower smoothing
            float newY = Mathf.SmoothDamp(cam.position.y, this.transform.position.y, ref speed, smoothTime);

            // Update camera position
            cam.position = new Vector3(cam.position.x, newY, -10f);
        }


        if (floatSpeed > 1)
        {
            float newY = Mathf.Lerp(cam.position.y, this.transform.position.y - 2f, delay * Time.deltaTime);
            cam.position = new Vector3(cam.position.x, newY, -10f);
        }

        

        movementInput.x = Input.GetAxis("Horizontal"); // Returns a value between -1 and 1

        // Combine upward float speed and horizontal movement
        float xVelocity = movementInput.x * moveSpeed;

        // Apply velocity to Rigidbody2D
        rb.linearVelocity = new Vector2(xVelocity, floatSpeed);

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision is BoxCollider2D)
        {
            if (life > 1)
            {
                //Camera shake
                Tween.ShakeCamera(cam.gameObject.GetComponent<Camera>(), 10f);
            }

           

            if (canLoseLife == true)
            {
                life--;
                canLoseLife = false;
                lifeCooldownTimer = lifeCooldownTime; // Reset the cooldown timer

                if (life == 1) 
                {
                    light2D.intensity = 4;
                    light2D.falloffIntensity = 0.8f;
                }
                
            }
        }

        if (collision.gameObject.tag == "Current")
        {
            if (floatSpeed <= 1)
            {
                floatSpeed = maxSpeed;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Current")
        {
            slowDown = true;
        }
    }


}
