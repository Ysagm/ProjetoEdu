using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCat : MonoBehaviour
{
    // list of sprites assigned in the inspector
    public List<Sprite> cats;
 
    // variable to hold a reference to our SpriteRenderer component
    private Image img;
 
    // method called once by unity when the game loads
    private void Awake()
    {
        // get the SpriteRenderer component reference
        img = GetComponent<Image>();
 
        // choose a random sprite from the list of sprites
        img.sprite = cats[Random.Range(0, cats.Count)];
        Debug.Log("mudou hehe");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
