using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string nameOfLevel;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Options;
    //[SerializeField] private GameObject Extra;
    [SerializeField] private GameObject Credits;

    public void Play(){
        SceneManager.LoadScene(nameOfLevel);
    }
    public void OpenOptions(){
        Options.SetActive(true);
        Debug.Log("Abriu opção");
    }
    public void CloseOptions(){
        Menu.SetActive(true);       
    }
   /* public void OpenExtra(){
        Menu.SetActive(false);
        Extra.SetActive(true);
        Debug.Log("Abriu extra");
    }
    public void CloseExtra(){
        Extra.SetActive(false);
        Menu.SetActive(true);
    }*/

    public void OpenCredits(){
        Credits.SetActive(true);
        Debug.Log("Abriu credits");
    }
    public void CloseCredits(){
        Menu.SetActive(true);        
    }
}

