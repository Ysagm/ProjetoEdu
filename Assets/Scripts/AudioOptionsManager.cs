using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioOptionsManager : MonoBehaviour
{
    public static float musicVolume { get; set; }
    public static float fxVolume { get; set; }

    public static void OnMusicValueChange(float value)
    {
        musicVolume = value;
        AudioManager.Instance.UpdateMixerVolume();
    }

    public void OnFxValueChange(float value)    
    {
        fxVolume = value;
        AudioManager.Instance.UpdateMixerVolume();
    }
}
