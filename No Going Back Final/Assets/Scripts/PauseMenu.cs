using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool paused;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (paused)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                PlayerMove.paused = true;
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                PlayerMove.paused = false;
            }
        }
	}
}
