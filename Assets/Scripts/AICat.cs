using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AICat : MonoBehaviour
{
    public Text falas;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AIPhrases());
    }

    // Update is called once per frame
    IEnumerator AIPhrases()
    {
        return null;
    }
}
