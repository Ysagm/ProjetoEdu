using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AICat : MonoBehaviour
{
    //Get text where the phrases will appear
    public Text falas;

    //Falas AI
    public GameObject falasGato;

    //Coroutine for the phrases appear
    private Coroutine popFalas;

    //List of phrases
    public List<string> phrases;

    //Sprites
    public Image catImage;
    public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartPhrases());
        ShowFalas(" ",0f,false);
        catImage.sprite = spriteArray[0]; 
    }
    void ShowFalas(string message, float duration, bool stayForever)
    {
        // If a popup routine exists, we should stop that first,
        // this makes sure that not 2 coroutines can run at the same time.
        // Since we are using the same popup for every message, we only want one of these coroutines to run at any time
        if (popFalas != null)
        {
            StopCoroutine(popFalas);
        }
        popFalas = StartCoroutine(AIPhrases(message, duration, stayForever));
    }

    public string GetRandomWord()
    {
        return phrases[Random.Range(0, phrases.Count)];
    }

    /*IEnumerator StartPhrases()
    {
        yield return new WaitForSeconds(2f);

        yield return PopAIVisualRoutine(true);
        ShowFalas("GATO FALANDO", 0f, true);

        yield return new WaitForSeconds(2f);
        yield return PopAIVisualRoutine(false);

        //ShowFalas("GATO FALANDO", 0f, false);
    }*/

    // Update is called once per frame
    IEnumerator AIPhrases(string message, float duration, bool stayForever = false)
    {
        duration = 5f;
        // Set the message of the popup
        falasGato.transform.GetChild(0).GetComponent<Text>().text = message;

        // Activate the popup
        yield return PopAIVisualRoutine(false);
        

        // If it should stay forever or not
        if (stayForever)
        {
            while (true)
            {
                yield return null;
            }
        }
        // Wait for the duration time
        yield return new WaitForSeconds(duration);

        // Deactivate the popup
        yield return PopAIVisualRoutine(true);
    }

    IEnumerator PopAIVisualRoutine(bool hide)
    {
        // Our timer
        float timer = 0f;

        // Duration of the animation
        float duration = 2f;

        // Reference to the popups transform
        Transform popupTransform = falasGato.transform;

        // Set the start scale
        Vector3 startScale = Vector3.zero;

        // Set the end scale
        Vector3 endScale = Vector3.one;

        // If we're hiding the popup, we will swap the startscale and endscale variables
        if (hide)
        {
            (startScale, endScale) = (endScale, startScale);
        }
        // Set the popups scale to 0
        popupTransform.localScale = startScale;

        // Turn on the popup gameobject FalaAI
        falasGato.SetActive(true);
        ShowFalas(GetRandomWord(), 0f, true);
        

        // First we lerp the scale from 0 to 1
        while (timer <= duration)
        {
            catImage.sprite = spriteArray[1];
            // This is just to make the variable value a bit cleaner
            float t = timer / duration;

            // This will create a smoothstep curve
            // It will ease in, and then ease out
            float value = t * t * (3f - (2f * t));

            // Lerp the scale from (0,0,0) to (1,1,1)
            popupTransform.localScale = Vector3.Lerp(startScale, endScale, value);

            // Increase the timer by the delta time
            timer += Time.deltaTime;

            yield return null;
        }
        // Set the scale to (1, 1, 1) in case we overshoot
        popupTransform.localScale = endScale;

        if (hide)
        {
            falasGato.SetActive(false);
            catImage.sprite = spriteArray[0];
        }

    }
}
