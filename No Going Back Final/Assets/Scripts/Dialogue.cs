using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    Tutorial tutorial;
    public GameObject dialoguePanel;
    public Text dialogueText;
    bool transition;
    bool textFadeOut;
    bool textFadeIn;
    bool panelFadeIn;
    bool panelFadeOut;

    void Start()
    {
        tutorial = FindObjectOfType<Tutorial>();
        StartCoroutine("IntroDialogue");
        panelFadeIn = true;
        Invoke("TextFadeIn", 1);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Transition();
        }
        if (panelFadeOut)
        {
            if (dialoguePanel.GetComponent<Image>().color.a >= 0)
            {
                dialoguePanel.GetComponent<Image>().color -= new Color(0, 0, 0, 0.03f);
            }
            if (dialoguePanel.GetComponent<Image>().color.a <= 0)
            {
                //dialogueText.gameObject.SetActive(false);
                textFadeOut = false;
            }
        }
        else
        {
            if (dialoguePanel.GetComponent<Image>().color.a <= 1 && panelFadeIn)
            {
                dialoguePanel.GetComponent<Image>().color += new Color(0, 0, 0, 0.03f);
            }
        }
        if (textFadeOut)
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
        yield return new WaitForSeconds(1);
        dialogueText.text = "Where am I?";
        Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2);
        dialogueText.text = "What is this place?";
        Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2);
        dialogueText.text = "I should look around.";
        Invoke("TextFadeOut", 1.5f);
        Invoke("PanelFadeOut", 2.5f);
        yield return new WaitForSeconds(3.5f);
        tutorial.IntroTutorial();
        //Invoke("Transition", 1.5f);
    }
    
    void Transition()
    {
        //dialogueText.SetActive(true);
        transition = true;
        //Invoke("DisableBlackScreen", 1.0f);
    }

    void PanelFadeOut()
    {
        panelFadeIn = false;
        panelFadeOut = true;
    }

    void PanelFadeIn()
    {
        panelFadeIn = true;
    }

    void TextFadeOut()
    {
        textFadeIn = false;
        textFadeOut = true;
    }

    void TextFadeIn()
    {
        textFadeIn = true;
    }
}
