using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] Audio;

    public static AudioManager instance;
    

    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in Audio)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.audioMixer;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }


    //Used to find Song of a certain name
    public void Play (string name)
    {
        Sound s = Array.Find(Audio, sound => sound.name == name);
        s.source.Play();
        if (s == null)
        {
            Debug.LogWarning("Audio: " + name + " not found!");
            return;
        }      
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(Audio, sound => sound.name == name);
        s.source.Stop();
    }

    public void Volume(string name, float volume)
    {
        Sound s = Array.Find(Audio, sound => sound.name == name);
        s.source.volume = volume;
    }

    // ref makes it a reference not a value
    public void isPlaying(string name, ref bool isPlaying)
    {
        Sound s = Array.Find(Audio, sound => sound.name == name);
        isPlaying = s.source.isPlaying;
        
    }


}
