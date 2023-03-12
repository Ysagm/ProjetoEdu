using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusic : MonoBehaviour
{
    private Music music;
    public Sprite musicOnImage;
    public Sprite musicOffImage;
    public Button buttonMusic;
    //private bool musicIsOn = true;

    //public AudioSource musicMenu;
    //public AudioSource musicGame;

    // Start is called before the first frame update
    void Start()
    {
        //musicOnImage = buttonMusic.image.sprite;
        music = GameObject.FindObjectOfType<Music>();
        ButtonMusicClicked();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseMusic()
    {
        music.ToggleSound();
        ButtonMusicClicked();
    }

    public void ButtonMusicClicked()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            buttonMusic.GetComponent<Image>().sprite = musicOnImage;
        }
        else
        {
            AudioListener.volume = 0;
            buttonMusic.GetComponent<Image>().sprite = musicOffImage;
        }
    }
}
