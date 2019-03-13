using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeInOut : MonoBehaviour
{
    Text text;
    float rate;

	void Start ()
    {
        text = GetComponent<Text>();
        rate = 0.01f;
	}
	
	void Update ()
    {
        FadeInOut();
	}

    void FadeInOut()
    {
        if(text.color.a >= 1 || text.color.a <= 0)
        {
            rate = -rate;
        }
        text.color += new Color(0, 0, 0, rate);
    }
}
