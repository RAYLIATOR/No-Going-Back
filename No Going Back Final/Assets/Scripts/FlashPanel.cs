using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashPanel : MonoBehaviour
{
    Image image;
    
	void Start ()
    {
        image = GetComponent<Image>();
	}
	
	void Update ()
    {
        image.color -= new Color(0, 0, 0, 0.01f);
	}
}
