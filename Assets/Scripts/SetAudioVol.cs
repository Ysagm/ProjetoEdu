using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetAudioVol : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetAudioLevel (float sliderValue)
    {
        mixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
    }
}
