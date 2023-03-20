using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public enum AudioTypes { soundFx, music }
    public AudioTypes audioType;

    [HideInInspector] public AudioSource source;
    public string clipName;
    public AudioClip audioClip;
    public bool isLoop;
    public bool playOnAwake;
    public bool mute;

    [Range(0, 1)] public float volume = 1f;

}
