using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    private float distance;

    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private float distanceBetween;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        AIScript();
    }

    void AIScript()
    {
        // Calculate the distance between the enemy and the player
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceBetween)
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            // Calculate the angle and rotate the enemy to face the player
            Vector2 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            //plays Animation
            anim.SetBool("IsAttacking", true);

        }
        else if (distance > distanceBetween)
        {

            anim.SetBool("IsAttacking", false);
        }
    }
}