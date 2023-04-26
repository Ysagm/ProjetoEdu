using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Image imgOriginal;
    public GameObject tutorial;
    public Sprite[] imgNext;
    private int currentIndex = 0;

    private static bool tutorialCompleted = false;

    private void Start()
    {
        if (tutorialCompleted)
        {
            CloseTutorial();
        }
        else
        {
            NewImage();
        }
    }

    public void NewImage()
    {
        if (currentIndex < imgNext.Length)
        {
            imgOriginal.sprite = imgNext[currentIndex];
            currentIndex++;
        }
        else
        {
            tutorialCompleted = true;
            CloseTutorial();
        }
    }

    private void CloseTutorial()
    {
        // Implement the code to close the tutorial
        tutorial.SetActive(false);
    }

    public static void ResetTutorial()
    {
        tutorialCompleted = false;
    }
}