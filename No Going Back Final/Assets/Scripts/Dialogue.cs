using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject fadePanel;
    bool fadeToBlack;
    bool fadeIn;

    void Start()
    {
        PlayerMove.paused = true;
        tutorial = FindObjectOfType<Tutorial>();
        if(FindObjectOfType<Canvas>().gameObject.tag == "Stage 1")
        {
            StartCoroutine("IntroDialogue");
            PanelFadeIn();
            Invoke("TextFadeIn", 1);
        }
        else if (FindObjectOfType<Canvas>().gameObject.tag == "Stage 2")
        {
            fadeIn = true;
            StartCoroutine("Stage2Intro");
            Invoke("PanelFadeIn", 1);
            Invoke("TextFadeIn", 2);
        }
        else if (FindObjectOfType<Canvas>().gameObject.tag == "Stage 3")
        {
            fadeIn = true;
            StartCoroutine("Stage3Intro");
            Invoke("PanelFadeIn", 1);
            Invoke("TextFadeIn", 2);
        }
    }
    
    void Update()
    {
        //if(PlayerMove.paused == true)
        //{
        //    print("paused");
        //}
        //else
        //{
        //    print("not paused");
        //}
        if (fadePanel.GetComponent<Image>().color.a < 1 && fadeToBlack)
        {
            fadePanel.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
        }
        if(fadePanel.GetComponent<Image>().color.a >= 1 && FindObjectOfType<Canvas>().gameObject.tag == "Stage 1")
        {
            SceneManager.LoadScene(2);
        }
        if (fadePanel.GetComponent<Image>().color.a > 0 && fadeIn)
        {
            fadePanel.GetComponent<Image>().color -= new Color(0, 0, 0, 0.01f);
        }
        if(fadePanel.GetComponent<Image>().color.a <= 0)
        {
            fadeIn = false;
        }
        //Mathf.Clamp(dialoguePanel.GetComponent<Image>().color.a, 0, 1);
        //print(textFadeOut);
        //print(dialogueText.GetComponent<Text>().color.a);
        if (Input.GetKeyDown(KeyCode.Return))
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
        dialogueText.text = "Where am I? I can't remember anything.";
        Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2);
        dialogueText.text = "Head hurts...Wait...There's the ship!";
        Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2);
        dialogueText.text = "I need to get to the other side of this island.";
        Invoke("TextFadeOut", 1.5f);
        Invoke("PanelFadeOut", 2f);
        yield return new WaitForSeconds(3.5f);
        tutorial.IntroTutorial();
        //Invoke("Transition", 1.5f);
    }

    IEnumerator Stage2Intro()
    {
        yield return new WaitForSeconds(1);
        dialogueText.text = "Where am I? My head hurts.";
        Invoke("Transition", 2.5f);
        yield return new WaitForSeconds(3);
        dialogueText.text = "There's the ship! Wait a second...";
        Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2);
        dialogueText.text = "It feels like.. I've been here before.";
        Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2);
        dialogueText.text = "I need to get to the other side of this island.";
        Invoke("TextFadeOut", 1.5f);
        Invoke("PanelFadeOut", 2f);
        Invoke("UnPause", 2);
        //yield return new WaitForSeconds(3.5f);
        //Invoke("Transition", 1.5f);
    }

    IEnumerator Stage3Intro()
    {
        yield return new WaitForSeconds(1);
        dialogueText.text = "Where am I? what is...My head....Wait!";
        Invoke("Transition", 2.5f);
        yield return new WaitForSeconds(3);
        dialogueText.text = "No No No! What is happening to me?";
        Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2);
        dialogueText.text = "Need to get to the other side.";
        Invoke("Transition", 1.5f);
        yield return new WaitForSeconds(2);
        dialogueText.text = "I NEED TO LEAVE THIS PLACE!";
        Invoke("TextFadeOut", 1.5f);
        Invoke("PanelFadeOut", 2f);
        Invoke("UnPause", 2);
        //yield return new WaitForSeconds(3.5f);
        //Invoke("Transition", 1.5f);
    }

    void UnPause()
    {
        PlayerMove.paused = false;
    }

    public void PlayPlayerDialogue(int i)
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
                PlayerMove.paused = true;
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "The ship's too far away, I'm gonna have to build a raft.";
                Invoke("TextFadeOut", 3f);
                Invoke("PanelFadeOut", 3.5f);
                Invoke("UnPause", 4f);
                break;
            case 4:
                PlayerMove.paused = true;
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "This looks like a good spot for the raft. Let's mark it.";
                Invoke("TextFadeOut", 4f);
                Invoke("PanelFadeOut", 4.5f);
                Invoke("MarkerInstruction", 4.5f);
                break;
            case 5:
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "I think I'm getting closer to the ship.";
                Invoke("TextFadeOut", 4f);
                Invoke("PanelFadeOut", 4.5f);
                break;
            case 6:
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "Wha...Whats happening? No!";
                Invoke("TextFadeOut", 4f);
                Invoke("PanelFadeOut", 4.5f);
                break;
            case 13:
                PlayerMove.paused = true;
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "An axe! Just what I need. I should pick it up.";
                Invoke("TextFadeOut", 4f);
                Invoke("PanelFadeOut", 4.5f);
                Invoke("ToolInstruction", 4.5f);
                break;
            case 14:
                PlayerMove.paused = true;
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "Now I need to collect logs from these trees.";
                Invoke("TextFadeOut", 4f);
                Invoke("PanelFadeOut", 4.5f);
                Invoke("TreeInstruction", 4.5f);
                break;
            case 15:
                PlayerMove.paused = true;
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "I should first find a good spot for the raft.";
                Invoke("TextFadeOut", 4f);
                Invoke("PanelFadeOut", 4.5f);
                Invoke("MarkInstruction", 4.5f);
                break;
            case 16:
                PlayerMove.paused = true;
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "I should go as close to the edge as possible.";
                Invoke("TextFadeOut", 4f);
                Invoke("PanelFadeOut", 4.5f);
                Invoke("UnPause", 4f);
                break;
            case 17:
                PlayerMove.paused = true;
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "I need to place this log on the marked spot.";
                Invoke("TextFadeOut", 4f);
                Invoke("PanelFadeOut", 4.5f);
                Invoke("LogInstruction", 4.5f);
                break;
            case 7:
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "Why does this island seem familiar?";
                Invoke("TextFadeOut", 2f);
                Invoke("PanelFadeOut", 2.5f);
                break;
            case 8:
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "I need to get to that ship";
                Invoke("TextFadeOut", 2f);
                Invoke("PanelFadeOut", 2.5f);
                break;
            case 9:
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "The ship's too far away, I'm gonna have to build a raft.";
                Invoke("TextFadeOut", 3f);
                Invoke("PanelFadeOut", 3.5f);
                break;
            case 10:
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "This looks like a good spot for the raft. Let's mark it.";
                Invoke("TextFadeOut", 4f);
                Invoke("PanelFadeOut", 4.5f);
                break;
            case 11:
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "I think I'm getting closer... to the ship.";
                Invoke("TextFadeOut", 4f);
                Invoke("PanelFadeOut", 4.5f);
                break;
            case 12:
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "Wha...Whats going on? No! No!";
                Invoke("TextFadeOut", 4f);
                Invoke("PanelFadeOut", 4.5f);
                break;

        }
    }

    public void PlayMemoryDialogue(int i, Memory memory)
    {
        switch (i)
        {
            case 1:
                PlayerMove.paused = true;
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "This is where you belong!";
                Invoke("TextFadeOut", 2f);
                Invoke("PanelFadeOut", 2.5f);
                memory.AttackCommand(2.5f);
                Invoke("UnPause", 3f);
                break;
            case 2:
                PlayerMove.paused = true;
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "You deserve this!";
                Invoke("TextFadeOut", 2f);
                Invoke("PanelFadeOut", 2.5f);
                memory.AttackCommand(2.5f);
                Invoke("UnPause", 3f);
                break;
            case 3:
                PlayerMove.paused = true;
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "You are never leaving this place!";
                Invoke("TextFadeOut", 2f);
                Invoke("PanelFadeOut", 2.5f);
                memory.AttackCommand(2.5f);
                Invoke("UnPause", 3f);
                break;
            case 4:
                PlayerMove.paused = true;
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "You did this to yourself!";
                Invoke("TextFadeOut", 2f);
                Invoke("PanelFadeOut", 2.5f);
                memory.AttackCommand(2.5f);
                Invoke("UnPause", 3f);
                break;
            case 5:
                PlayerMove.paused = true;
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "You can't run from this!";
                Invoke("TextFadeOut", 2f);
                Invoke("PanelFadeOut", 2.5f);
                memory.AttackCommand(2.5f);
                Invoke("UnPause", 3f);
                break;
            case 6:
                PlayerMove.paused = true;
                panelFadeIn = true;
                Invoke("TextFadeIn", 1);
                dialogueText.text = "Why do you deny reality?";
                Invoke("TextFadeOut", 2f);
                Invoke("PanelFadeOut", 2.5f);
                memory.AttackCommand(2.5f);
                Invoke("UnPause", 3f);
                break;
        }
    }
    
    void ToolInstruction()
    {
        tutorial.ToolInstruction();
    }

    void MarkInstruction()
    {
        PlayPlayerDialogue(16);
    }
    
    void MarkerInstruction()
    {
        tutorial.MarkerInstruction();
    }
    void TreeInstruction()
    {
        tutorial.TreeInstruction();
    }

    void LogInstruction()
    {
        tutorial.LogInstruction();
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

    public void FadeToBlack()
    {
        fadeToBlack = true;
    }
}
