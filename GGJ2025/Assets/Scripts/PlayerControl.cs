using UnityEngine;
using UnityEngine.Rendering.Universal;
using PrimeTween;
public class PlayerControl : MonoBehaviour {
    public int life = 2;

    private Rigidbody2D rb;
    public float moveSpeed;
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

    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        light2D.intensity = 6;
        light2D.falloffIntensity = 0.5f;
    }

    private void Update() {
        if (!canLoseLife) {
            lifeCooldownTimer -= Time.deltaTime;

            if (lifeCooldownTimer <= 0f) {
                canLoseLife = true; // Allow life loss again after cooldown
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        // Keep lantern and circle positioned with the player
        lantern.position = this.transform.position;
        circle.position = this.transform.position;

        // Camera stays in place, only horizontal movement impacts gameplay
        cam.position = new Vector3(this.transform.position.x, cam.position.y, -10f);

        // Handle horizontal movement
        movementInput.x = Input.GetAxis("Horizontal"); // Returns a value between -1 and 1

        // Apply horizontal movement while keeping vertical velocity at 0
        float xVelocity = movementInput.x * moveSpeed;

        rb.linearVelocity = new Vector2(xVelocity, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy" && collision is BoxCollider2D) {
            if (canLoseLife == true) {
                life--;
                canLoseLife = false;
                lifeCooldownTimer = lifeCooldownTime; // Reset the cooldown timer

                if (life == 1) {
                    light2D.intensity = 4;
                    light2D.falloffIntensity = 0.8f;
                }
            }
        }
    }
}
