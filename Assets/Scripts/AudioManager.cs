using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public const string prefAudioMute = "prefAudioMute";
    public static AudioManager Instance;

    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup soundFxMixerGroup;
    [SerializeField] private Sound[] sounds;
    [SerializeField] private Image musicMuteButton;
    [SerializeField] private Sprite musicOnSprite;
    [SerializeField] private Sprite musicOffSprite;
    [SerializeField] private Image fxMuteButton;
    [SerializeField] private Sprite fxOnSprite;
    [SerializeField] private Sprite fxOffSprite;

    private void Awake()
    {

        Instance = this;
        GameObject.DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey(prefAudioMute))
            AudioOptionsManager.musicVolume = PlayerPrefs.GetFloat(prefAudioMute);

        UpdateMuteButtonImageSprite();

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.mute = s.mute;
            s.source.loop = s.isLoop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.volume = s.volume;

            switch (s.audioType)
            {
                case Sound.AudioTypes.soundFx:
                    s.source.outputAudioMixerGroup = soundFxMixerGroup;
                    break;

                case Sound.AudioTypes.music:
                    s.source.outputAudioMixerGroup = musicMixerGroup;
                    break;
            }

            if (s.playOnAwake)
            {
                s.source.Play();
            }

            if (s.source.mute == true)
                s.source.volume = 0.0001f;
            else
                s.source.volume = 1f;
        }
    }

    private void UpdateMuteButtonImageSprite()
    {
        Sound s = Array.Find(sounds, dummySound => dummySound.clipName == "BG Music OP 1");
        if (s.mute == true)
            musicMuteButton.sprite = musicOffSprite;
        else
            musicMuteButton.sprite = musicOnSprite;
    }

    private void UpdateVolumeButtonImageSprite()
    {
        Sound s = Array.Find(sounds, dummySound => dummySound.clipName == "Type");
        if (s.mute == true)
            fxMuteButton.sprite = fxOffSprite;
        else
            fxMuteButton.sprite = fxOnSprite;
    }

    public void Play(string clipName)
    {
        Sound s = Array.Find(sounds, dummySound => dummySound.clipName == clipName);
        s.source.Play();
    }

    public void Stop(string clipName)
    {
        Sound s = Array.Find(sounds, dummySound => dummySound.clipName == clipName);
        s.source.Stop();
    }

    public void ToggleMuteMusic()
    {
        Sound s = Array.Find(sounds, dummySound => dummySound.clipName == "BG Music OP 1");
        if (s.source.mute == false)
        {
            s.source.mute = true;
            s.mute = true;
        }
        else
        {
            s.source.mute = false;
            s.mute = false;
        }

        PlayerPrefs.SetFloat(prefAudioMute, AudioOptionsManager.musicVolume);

        UpdateMuteButtonImageSprite();
    }

    public void ToggleMuteSoundFx()
    {
        Sound s = Array.Find(sounds, dummySound => dummySound.clipName == "Type");
        if (s.source.mute == false)
        {
            s.source.mute = true;
            s.mute = true;
        }
        else
        {
            s.source.mute = false;
            s.mute = false;
        }

        PlayerPrefs.SetFloat(prefAudioMute, AudioOptionsManager.fxVolume);

        UpdateVolumeButtonImageSprite();
    }

    public void UpdateMixerVolume()
    {
        musicMixerGroup.audioMixer.SetFloat("Music Volume", Mathf.Log10(AudioOptionsManager.musicVolume) * 20);
        soundFxMixerGroup.audioMixer.SetFloat("Fx Volume", Mathf.Log10(AudioOptionsManager.fxVolume) * 20);
    }
}
