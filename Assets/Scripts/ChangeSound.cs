using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSound : MonoBehaviour
{
    private Sounds sounds;
    public Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button buttonSound;
    //private bool musicIsOn = true;

    //public AudioSource musicMenu;
    //public AudioSource musicGame;

    // Start is called before the first frame update
    void Start()
    {
        //musicOnImage = buttonMusic.image.sprite;
        sounds = GameObject.FindObjectOfType<Sounds>();
        ButtonSoundClicked();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseSound()
    {
        sounds.ToggleSound();
        ButtonSoundClicked();
    }

    public void ButtonSoundClicked()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            buttonSound.GetComponent<Image>().sprite = soundOnImage;
        }
        else
        {
            AudioListener.volume = 0;
            buttonSound.GetComponent<Image>().sprite = soundOffImage;
        }
    }
}