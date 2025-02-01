using PrimeTween;
using UnityEngine;

public class RockFall : MonoBehaviour
{
    [SerializeField] private float dropspeed;
    [SerializeField] private GameObject player;

    private float deadZone = -12;

    public GameObject scareImage; // Reference to the jump scare image
    public AudioSource scareSound; // Reference to the audio source
    public float scareDuration = 2f; // Duration of the jump scare
    public Transform cam;

    private bool scareTriggered = false;
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * dropspeed) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D enemy) {
        
        if (enemy.gameObject.CompareTag("Player") && !scareTriggered){

            TriggerJumpScare();
        }
    }

    private void TriggerJumpScare() {

        scareTriggered = true;
        //Debug.Log("Jump scare image activated!");
        scareImage.SetActive(true); // Show the image
        scareSound.Play(); // Play the sound
        Invoke("HideScare", scareDuration); // Hide after duration

        //if (cam != null && cam.GetComponent<Camera>() != null) {
        //    Tween.ShakeCamera(cam.GetComponent<Camera>(), 10f); // Adjust intensity as needed
        //} else {
        //    Debug.LogWarning("Camera reference is missing or invalid!");
        //}
    }

    private void HideScare() {

        scareImage.SetActive(false); // Hide the image
    }


}
