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
                panelFadeOut = false;
            }
        }
        else
        {
            if (tutorialPanel.GetComponent<Image>().color.a <= 1 && panelFadeIn)
            {
                tutorialPanel.GetComponent<Image>().color += new Color(0, 0, 0, 0.03f);
                if (tutorialPanel.GetComponent<Image>().color.a >= 1)
                {
                    panelFadeIn = false;
                }
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
        if (tutorialPanel.GetComponent<Image>().color.a < 0)
        {
            tutorialPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        if (tutorialText.GetComponent<Text>().color.a < 0)
        {
            tutorialText.GetComponent<Text>().color = new Color(1, 1, 1, 0);
        }
    }

    IEnumerator IntroDialogue()
    {
        yield return new WaitForSeconds(1);
        tutorialText.text = "Use the Mouse to look around.";
        Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2);
        tutorialText.text = "Use W, A, S and D keys to move";
        Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2);
        tutorialText.text = "Press Escape to pause the game.";
        Invoke("TextFadeOut", 1.5f);
        Invoke("PanelFadeOut", 2.5f);
        //Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2.5f);
        PlayerMove.paused = false;
    }

    public void LogInstruction()
    {
        panelFadeIn = true;
        Invoke("TextFadeIn", 1);
        tutorialText.text = "Press E to place log on marked spot.";
        Invoke("TextFadeOut", 2f);
        Invoke("PanelFadeOut", 2.5f);
        Invoke("UnPause", 2.5f);
    }

    public void ToolInstruction()
    {
        panelFadeIn = true;
        Invoke("TextFadeIn", 1);
        tutorialText.text = "Press E to pickup tool.";
        Invoke("TextFadeOut", 2f);
        Invoke("PanelFadeOut", 2.5f);
        Invoke("UnPause", 2.5f);
    }

    public void MarkerInstruction()
    {
        panelFadeIn = true;
        Invoke("TextFadeIn", 1);
        tutorialText.text = "Press E to mark location.";
        Invoke("TextFadeOut", 2f);
        Invoke("PanelFadeOut", 2.5f);
        Invoke("UnPause", 2.5f);
    }

    public void TreeInstruction()
    {
        panelFadeIn = true;
        Invoke("TextFadeIn", 1);
        tutorialText.text = "Press E to chop down tree.";
        Invoke("TextFadeOut", 2f);
        Invoke("PanelFadeOut", 2.5f);
        Invoke("UnPause", 2.5f);
    }

    void UnPause()
    {
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
