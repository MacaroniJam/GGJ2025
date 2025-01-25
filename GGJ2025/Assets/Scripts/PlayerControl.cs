using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int life = 2;

    private Rigidbody2D rb;
    public float moveSpeed;
    public float floatSpeed;
    private Vector2 movementInput;

    public Transform lantern;
    public Light2D light2D;

    public Transform cam;
    public float delay;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        light2D.intensity = 6;
        light2D.falloffIntensity = 0.5f;
    }
    private void Update()
    {
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //lantern position = player position
        lantern.position = this.transform.position;

        //camera y position = player y position delayed
        if (this.transform.position.y > 0)
        {
            cam.position = new Vector3(cam.position.x, this.transform.position.y, -10f);
        }

        

        movementInput.x = Input.GetAxis("Horizontal"); // Returns a value between -1 and 1

        // Combine upward float speed and horizontal movement
        float xVelocity = movementInput.x * moveSpeed;

        // Apply velocity to Rigidbody2D
        rb.linearVelocity = new Vector2(xVelocity, floatSpeed);

        

    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            life--;
            if (life == 1)
            {
                light2D.intensity = 4;
                light2D.falloffIntensity = 0.8f;
            }
        }
    }*/


}
