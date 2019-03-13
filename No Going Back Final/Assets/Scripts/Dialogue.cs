using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    bool transition;
    bool textFadeOut;
    bool textFadeIn;

    void Start()
    {
        StartCoroutine("IntroDialogue");
        textFadeIn = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Transition();
        }
        if(textFadeOut)
        {
            if (dialogueText.GetComponent<Text>().color.a >= 0)
            {
                dialogueText.GetComponent<Text>().color -= new Color(0, 0, 0, 0.03f);
            }
            if (dialogueText.GetComponent<Text>().color.a <= 0)
            {
                //dialogueText.gameObject.SetActive(false);
                textFadeOut = false;
            }
        }
        if (transition)
        {
            if (dialogueText.GetComponent<Text>().color.a >= 0)
            {
                dialogueText.GetComponent<Text>().color -= new Color(0, 0, 0, 0.03f);
            }
            if (dialogueText.GetComponent<Text>().color.a <= 0)
            {
                transition = false;
            }
        }
        else
        {          
            if (dialogueText.GetComponent<Text>().color.a <= 1 && textFadeIn)
            {
                dialogueText.GetComponent<Text>().color += new Color(0, 0, 0, 0.03f);
            }
        }
    }

    IEnumerator IntroDialogue()
    {
        dialogueText.text = "Where am I?";
        Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2);
        dialogueText.text = "What is this place?";
        Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2);
        dialogueText.text = "I should look around.";
        Invoke("Fade", 1.5f);
        //Invoke("Transition", 1.5f);
    }

    void Transition()
    {
        //dialogueText.SetActive(true);
        transition = true;
        //Invoke("DisableBlackScreen", 1.0f);
    }

    void Fade()
    {
        textFadeIn = false;
        textFadeOut = true;
    }
}
