using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    //int sceneIndex;
    public Text percentage; 

    void Start()
    {
        StartCoroutine(LoadAsynchrononously());
    }
    IEnumerator LoadAsynchrononously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");
        
        loadingScreen.SetActive(true);

        operation.allowSceneActivation=false;

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            //Debug.Log(operation.progress);
            percentage.text = (operation.progress * 100).ToString("N3") + "%";
            slider.value = progress;

            yield return null;
        }
        operation.allowSceneActivation=true;
    }
    
}