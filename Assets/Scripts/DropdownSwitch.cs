using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class DropdownSwitch : MonoBehaviour
{
    public TMP_Dropdown language;
    public static string linguinha;
    public static int index;

    private void Start()
    {
        language.onValueChanged.AddListener(OnLanguageValueChanged);
        linguinha = "Portugues";
        language.text = language.options[index].text;
    }

    private void OnLanguageValueChanged(int i)
    {
        index = i;
        Debug.Log($"Language selected: {language.options[index].text}");
        linguinha = language.options[index].text;
    }
}
