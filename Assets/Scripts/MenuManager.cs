using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string nameOfLevel;

    public void Play(){
        SceneManager.LoadScene(nameOfLevel);
    }  

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

