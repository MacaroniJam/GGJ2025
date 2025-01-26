using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5f;
    //private Rigidbody2D rb;
    public GameObject player;
    private float distance;

    //private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AiChase();
    }

    void AiChase()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
