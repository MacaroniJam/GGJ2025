using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;

    public AudioMixerGroup audioMixer;

    [Range(0f, 1f)]
    public float volume;

    [Range(-3f,3f)]
    public float pitch;

    public bool loop;


    [HideInInspector]
    public AudioSource source;
}
