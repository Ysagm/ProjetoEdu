using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenRatio : MonoBehaviour
{
    public CanvasScaler myScaler;
    public float width;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        width = Screen.width;
        height = Screen.height;

        float x = ((float)Screen.width/Screen.height) / ( myScaler.referenceResolution.x/ myScaler.referenceResolution.y);
        myScaler.referenceResolution =  new Vector2(myScaler.referenceResolution.x * x , myScaler.referenceResolution.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
