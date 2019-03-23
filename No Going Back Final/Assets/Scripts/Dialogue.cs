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
        PanelFadeIn();
        Invoke("TextFadeIn", 1);
    }

    void Update()
    {
        //Mathf.Clamp(dialoguePanel.GetComponent<Image>().color.a, 0, 1);
        //print(textFadeOut);
        //print(dialogueText.GetComponent<Text>().color.a);
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Transition();
        }
        if (panelFadeOut)
        {
            if (dialoguePanel.GetComponent<Image>().color.a > 0)
            {
                dialoguePanel.GetComponent<Image>().color -= new Color(0, 0, 0, 0.03f);
            }
            if (dialoguePanel.GetComponent<Image>().color.a <= 0)
            {
                //dialogueText.gameObject.SetActive(false);
                panelFadeOut = false;
            }
        }
        else
        {
            if (dialoguePanel.GetComponent<Image>().color.a <= 1 && panelFadeIn)
            {
                dialoguePanel.GetComponent<Image>().color += new Color(0, 0, 0, 0.03f);
                if(dialoguePanel.GetComponent<Image>().color.a >= 1)
                {
                    panelFadeIn = false;
                }
            }
        }
        if (textFadeOut)
        {
            if (dialogueText.GetComponent<Text>().color.a > 0)
            {
                dialogueText.GetComponent<Text>().color -= new Color(0, 0, 0, 0.03f);
            }
            if (dialogueText.GetComponent<Text>().color.a <= 0)
            {
                //dialogueText.gameObject.SetActive(false);
                textFadeOut = false;
                print("a is 0");
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
            if (dialogueText.GetComponent<Text>().color.a <= 1 && textFadeIn && !textFadeOut)
            {
                dialogueText.GetComponent<Text>().color += new Color(0, 0, 0, 0.03f);
            }
        }
        if(dialoguePanel.GetComponent<Image>().color.a < 0)
        {
            dialoguePanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        if (dialogueText.GetComponent<Text>().color.a < 0)
        {
            dialogueText.GetComponent<Text>().color = new Color(1, 1, 1, 0);
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
        Invoke("PanelFadeOut", 2f);
        yield return new WaitForSeconds(3.5f);
        tutorial.IntroTutorial();
        //Invoke("Transition", 1.5f);
    }

    public void PlayDialogue(int i)
    {
        switch(i)
        {
            case 1:
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "Which way should I go?";
                Invoke("TextFadeOut", 2f);
                Invoke("PanelFadeOut", 2.5f);
                break;
            case 2:
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "This place is beautiful.";
                Invoke("TextFadeOut", 2f);
                Invoke("PanelFadeOut", 2.5f);
                break;
            case 3:
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "I'm gonna need some kind of tool. Maybe If I could find a sharp rock, I could use that.";
                Invoke("TextFadeOut", 4f);
                Invoke("PanelFadeOut", 4.5f);
                break;
            case 4:
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "Well, I guess this is a good place to build a raft.";
                Invoke("TextFadeOut", 3f);
                Invoke("PanelFadeOut", 3.5f);
                break;
        }
    }
    
    void Transition()
    {
        //dialogueText.SetActive(true);
        transition = true;
        //Invoke("DisableBlackScreen", 1.0f);
    }

    void PanelFadeOut()
    {
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
