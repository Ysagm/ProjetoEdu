using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    //Img
    public Image imgOriginal;
    //Tutorial Panel
    public GameObject tutorial;
    //List of Sprites
    public Sprite[] imgNext;
    //index
    private int currentIndex = 0;
    
    //Set PLayerPrefs
    //Note: if you want to reset the tutorial and show it again, you can call the PlayerPrefs.DeleteKey(TUTORIAL_COMPLETED_KEY) 
    //function to remove the tutorial_completed variable from storage. 
    //This will cause the tutorial to be shown again the next time the scene is loaded.
    private const string TUTORIAL_COMPLETED_KEY = "tutorial_completed";

    private void Start()
    {
        // Check if tutorial has been completed before
        if (PlayerPrefs.GetInt(TUTORIAL_COMPLETED_KEY, 0) == 1)
        {
            // Tutorial has been completed, close the tutorial
            CloseTutorial();
        }
        else
        {
            // Tutorial has not been completed, show the first image
            NewImage();
        }
    }

    public void NewImage()
    {
        //check if current image index is less than the max of list
        if (currentIndex < imgNext.Length)
        {
            imgOriginal.sprite = imgNext[currentIndex];
            //next img
            currentIndex++;
        }
        else
        {
            // Tutorial has been completed, save the state and close the tutorial
            // This will ensure that the tutorial is not shown again when the scene is reset.
            PlayerPrefs.SetInt(TUTORIAL_COMPLETED_KEY, 1);
            CloseTutorial();
        }
    }

    private void CloseTutorial()
    {
        // Implement the code to close the tutorial
        tutorial.SetActive(false);
    }
}