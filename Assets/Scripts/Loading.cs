using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    //public GameObject loadingScreen;
    //public Slider slider;
    public Image loadingBarImage;
    public Text percentage; 

    void Start()
    {

        loadingBarImage.fillAmount = 0;
        StartCoroutine(LoadAsynchrononously());
    }

    IEnumerator LoadAsynchrononously()
    {
        yield return new WaitForSecondsRealtime(5);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");

        //operation.allowSceneActivation=false;

        while(!operation.isDone)
        {
            //float progress = Mathf.Clamp01(operation.progress / 0.9f);
            //Debug.Log(operation.progress);
            percentage.text = (operation.progress * 100).ToString("N0") + "%";
            loadingBarImage.fillAmount = operation.progress;

            yield return null;
            
        }
        //operation.allowSceneActivation=true;
        //Prevent crashes
        System.GC.Collect();

        
    }
    
}