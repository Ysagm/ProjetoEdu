using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;
    static bool showTutorial = true;
    //static Tutorial instance = null;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.GetInt("showTutorial");

        if (showTutorial)
        {
            StartCoroutine("StartDelay");
            showTutorial = false;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator StartDelay()
    {
        //Pause scene
        Time.timeScale = 0;
        //Star countdown after start
        float pauseTime = Time.realtimeSinceStartup + 5f;
        //Finish coutdown and Close tutorial
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        tutorial.gameObject.SetActive(false);
        //Continue game
        Time.timeScale = 1;
    }

    public static void Reset()
    {
        showTutorial = true;
    }
}
