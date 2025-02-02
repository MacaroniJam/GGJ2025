using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] AudioSource Music;
   // [SerializeField] AudioSource SFX;

    public AudioClip bgmusic;
   // public AudioClip buttonsound;

      
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Music.clip = bgmusic;
        Music.Play();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
