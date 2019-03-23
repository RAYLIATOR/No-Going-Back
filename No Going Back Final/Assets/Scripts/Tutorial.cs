using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    //Dialogue
    public GameObject tutorialPanel;
    public Text tutorialText;
    bool transition;
    bool textFadeOut;
    bool textFadeIn;
    bool panelFadeIn;
    bool panelFadeOut;

    public void IntroTutorial()
    {
        StartCoroutine("IntroDialogue");
        panelFadeIn = true;
        Invoke("TextFadeIn", 1);
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Transition();
        }
        if (panelFadeOut)
        {
            if (tutorialPanel.GetComponent<Image>().color.a >= 0)
            {
                tutorialPanel.GetComponent<Image>().color -= new Color(0, 0, 0, 0.03f);
            }
            if (tutorialPanel.GetComponent<Image>().color.a <= 0)
            {
                //dialogueText.gameObject.SetActive(false);
                textFadeOut = false;
            }
        }
        else
        {
            if (tutorialPanel.GetComponent<Image>().color.a <= 1 && panelFadeIn)
            {
                tutorialPanel.GetComponent<Image>().color += new Color(0, 0, 0, 0.03f);
            }
        }
        if (textFadeOut)
        {
            if (tutorialText.GetComponent<Text>().color.a >= 0)
            {
                tutorialText.GetComponent<Text>().color -= new Color(0, 0, 0, 0.03f);
            }
            if (tutorialText.GetComponent<Text>().color.a <= 0)
            {
                //dialogueText.gameObject.SetActive(false);
                textFadeOut = false;
            }
        }
        if (transition)
        {
            if (tutorialText.GetComponent<Text>().color.a >= 0)
            {
                tutorialText.GetComponent<Text>().color -= new Color(0, 0, 0, 0.03f);
            }
            if (tutorialText.GetComponent<Text>().color.a <= 0)
            {
                transition = false;
            }
        }
        else
        {
            if (tutorialText.GetComponent<Text>().color.a <= 1 && textFadeIn)
            {
                tutorialText.GetComponent<Text>().color += new Color(0, 0, 0, 0.03f);
            }
        }
    }

    IEnumerator IntroDialogue()
    {
        PlayerMove.paused = true;
        yield return new WaitForSeconds(1);
        tutorialText.text = "Use the Mouse to look around.";
        Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2);
        tutorialText.text = "Use W, A, S and D keys to move";
        Invoke("TextFadeOut", 1.5f);
        Invoke("PanelFadeOut", 2.5f);
        //Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2.5f);
        PlayerMove.paused = false;
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
