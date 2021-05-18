using UnityEngine.Audio;
using System;
using UnityEngine;

/*
    AudioManager will manage all sounds and music for the whole game.
*/
public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;
    [Range(0f,1f)]
    public float volume = 1f;

    void Awake()
    {
        // Single instance.
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        // Establishing AudioSources for each sound.
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }

    public void SetVolume (float v)
    {
        volume = v;
    }

    public static AudioManager GetInstance ()
    {
        return instance;
    }

    // Main theme will start here.
    void Start ()
    {
        Play("Theme");
    }

    // Given a name, it'll try to find the Sound object and play its AudioClip. 
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        else
        {
            s.source.Play();
        }
    }
}
