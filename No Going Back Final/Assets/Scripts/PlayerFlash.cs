using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlash : MonoBehaviour
{
    public GameObject flashPanel;
    public GameObject canvas;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void Flash()
    {
        Instantiate(flashPanel, canvas.transform);
    }
}
