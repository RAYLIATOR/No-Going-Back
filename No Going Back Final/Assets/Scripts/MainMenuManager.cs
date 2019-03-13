using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    Stack<GameObject> screens;
    public GameObject titleScreen;
    public GameObject mainMenuScreen;
    public GameObject creditsScreen;
    public GameObject blackScreen;
    bool transition;

	void Start ()
    {
        screens = new Stack<GameObject>();
        screens.Push(titleScreen);
        print(blackScreen.GetComponent<Image>().color.a);
    }
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Transition();
        }
        screens.Peek().SetActive(true);
        if(screens.Peek() == titleScreen && Input.GetKeyDown(KeyCode.Return))
        {
            MainMenuTransition();
        }
        if(transition)
        {
            if(blackScreen.GetComponent<Image>().color.a <= 1)
            {
                blackScreen.GetComponent<Image>().color += new Color(0, 0, 0, 0.03f);
            }
            if(blackScreen.GetComponent<Image>().color.a >= 1)
            {
                transition = false;
            }
        }
        else
        {
            if (blackScreen.GetComponent<Image>().color.a >= 0)
            {
                blackScreen.GetComponent<Image>().color -= new Color(0, 0, 0, 0.03f);
            }
        }
	}

    public void BackTransition()
    {
        Transition();
        Invoke("Back", 0.5f);
    }

    void Back()
    {
        screens.Pop().SetActive(false);
    }

    void MainMenuTransition()
    {
        Transition();
        Invoke("MainMenu", 0.5f);
    }

    void MainMenu()
    {
        screens.Push(mainMenuScreen);
    }

    public void CreditsTransition()
    {
        Transition();
        Invoke("Credits", 0.5f);
    }

    void Credits()
    {
        screens.Push(creditsScreen);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Transition()
    {
        blackScreen.SetActive(true);
        transition = true;
        Invoke("DisableBlackScreen", 1.0f);
    }

    void DisableBlackScreen()
    {
        blackScreen.SetActive(false);
    }
}
