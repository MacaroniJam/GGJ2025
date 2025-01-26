using UnityEngine;

public class RockFall : MonoBehaviour
{
    [SerializeField] private float dropspeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * dropspeed) * Time.deltaTime;
    }
}
