using UnityEngine;

public class MgBgAudio : MonoBehaviour
{
    [SerializeField] AudioSource bgsound;

    public AudioClip bgmusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgsound.clip = bgmusic;
        bgsound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
