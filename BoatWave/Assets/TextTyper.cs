using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTyper : MonoBehaviour
{

    public float letterPause = 0.2f;
    public float fadeOutDelay = 2.0f;
   

    string message;
    Text textComp;

    // Use this for initialization
    void Start()
    {
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        yield return new WaitForSeconds(fadeOutDelay);
        foreach (char letter in message.ToCharArray())
        {
            textComp.text = textComp.text.Substring(1);
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        textComp.text = "";
    }

    public void writeText(string text)
    {
        message = text;
        StartCoroutine(TypeText());
    }

}