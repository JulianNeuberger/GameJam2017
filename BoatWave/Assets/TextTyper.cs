using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTyper : MonoBehaviour
{

    public float letterPause = 0.2f;
    public float fadeOutDelay = 2.0f;
    public float letterPauseFadeOut = 0.1f;

    public GameObject levelChanger;

    string message;
    Text textComp;

    bool finishedWriting = false;
    int curLetter = 0;
    float lastLetterTime = -1;

    // Use this for initialization
    void Start()
    {
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
    }

    void Update()
    {
        if (!finishedWriting)
        {
            if (Time.time - lastLetterTime > letterPause)
            {
                textComp.text += message[curLetter++];
                lastLetterTime = Time.time;

                if(curLetter == message.Length)
                {
                    finishedWriting = true;
                }
            }
        } else
        {
            if (Time.time - lastLetterTime > letterPause)
            {
                if(textComp.text.Length > 0)
                {
                    textComp.text = textComp.text.Substring(1);
                }
                else if(levelChanger != null)
                {
                    LevelChangerBehaviour behaviour = levelChanger.GetComponent<LevelChangerBehaviour>();
                    if (behaviour != null)
                    {
                        behaviour.DoChange();
                    }
                    levelChanger = null;
                }
                lastLetterTime = Time.time;
            }
            //remove text
        }
    }

    public void writeText(string text)
    {
        message = text;
        finishedWriting = false;
        curLetter = 0;
        lastLetterTime = -1;
    }

}