using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownLanguageChange : MonoBehaviour
{
    public Dropdown dropdown; // add this line to define the Dropdown component
    void Start()
    {
        //dropdown = GetComponent<Dropdown>();

     
        
            int dropdownID = PlayerPrefs.GetInt("dropdownID", 0);
            dropdown.value = dropdownID;
    }


    public void DropdownValueChanged(int index)
    {
        Debug.Log("Dropdown value changed: " + index);
        // save the ID of the selected option in PlayerPrefs
        PlayerPrefs.SetInt("dropdownID", index);
        PlayerPrefs.Save();
    }
}
