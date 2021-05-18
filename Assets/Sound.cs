using UnityEngine.Audio;
using UnityEngine;

/*
    Sound class contains the name of the object so it's easily findable,
    and the AudioClip that will be played.
*/
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
