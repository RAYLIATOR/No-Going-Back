using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public GameObject rightHand;
    GameObject tool;
    Animator anim;
    public bool inZone;
    bool hasTool;
    int logs;
    bool marked;
    public GameObject xMark;
    public GameObject log;
    Vector3 xMarkPosition;
    //logs
    public Vector3[] logPositions;
    Vector3 logRotation;
    int logsPlaced;
    Vector3 logCarryPosition;
    GameObject currentLog;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Tool" && Input.GetKeyDown(KeyCode.E))
        {
            PlayerMove.paused = true;
            tool = other.gameObject;
            ResetCamera();
            transform.localEulerAngles = new Vector3(0, 113.9f, 0);
            transform.localPosition = new Vector3(335f, 8.9f, -33.37f);
            anim.SetTrigger("Pick");
            Invoke("ToolInHand", 2.14f);
            hasTool = true;
            Invoke("UnPause", 9.567f);
            if (marked)
            {
                Invoke("TreeDialogue", 9.567f);
            }
            else
            {
                Invoke("MarkDialogue", 9.567f);
            }
        }
        if (other.tag == "Tree" && Input.GetKeyDown(KeyCode.E) && hasTool && marked && logs == 0)
        {
            other.tag = "Untagged";
            PlayerMove.paused = true;
            anim.SetTrigger("Chop");
            Destroy(other.gameObject,2.4f);
            Invoke("CarryLog", 2.4f);
            Invoke("UnPause", 2.4f);
        }
    }

    void TreeDialogue()
    {
        FindObjectOfType<Dialogue>().PlayPlayerDialogue(14);
    }

    void MarkDialogue()
    {
        FindObjectOfType<Dialogue>().PlayPlayerDialogue(15);
    }

    void CarryLog()
    {
        currentLog = Instantiate(log, transform.position, Quaternion.identity);
        currentLog.transform.parent = transform;
        currentLog.transform.localPosition = logCarryPosition;
        currentLog.transform.localEulerAngles = new Vector3(3.26f, -20.2f, 180);
        //Invoke("UnPause", 2.4f);
        logs += 1;
        if(logsPlaced == 0)
        {
            FindObjectOfType<Dialogue>().PlayPlayerDialogue(17);
        }
        print(logs);
    }

    void ToolInHand()
    {
        Destroy(tool.GetComponent<Rigidbody>());
        tool.transform.parent = rightHand.transform;
        tool.transform.localPosition = new Vector3(0.09f, -0.4f, -0.6f);
        tool.transform.localEulerAngles = new Vector3(15.506f, -138.59f, 75.481f);
    }

    void ResetCamera()
    {
        Camera.main.transform.localEulerAngles = Vector3.zero;
    }

    void ChopCamera()
    {
        Camera.main.transform.localEulerAngles = new Vector3(0,0,0);
    }

    void UnPause()
    {
        PlayerMove.paused = false;
    }

    void Start ()
    {
        logsPlaced = 0;
        anim = GetComponent<Animator>();
        xMarkPosition = new Vector3(329.19f, 7.6f, -78.21f);
        logRotation = new Vector3(-6.25f, -20.22f, 180f);
        logCarryPosition = new Vector3(4.55f, 2.7f, -6.4f);
    }
	
	void Update ()
	{
        if (Input.GetKeyDown(KeyCode.P))
        {
            ResetCamera();
            PlayerMove.paused = true;
            anim.SetTrigger("Pick");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("Chop");
        }
        if (inZone && Input.GetKeyDown(KeyCode.E) && !marked)
        {
            GameObject g = Instantiate(xMark, xMarkPosition, Quaternion.identity);
            g.transform.Rotate(90,-17.1f,0);
            if(tool == true)
            {
                TreeDialogue();
            }
            marked = true;
        }
        if (inZone && Input.GetKeyDown(KeyCode.E) && logs > 0 && marked)
        {
            Destroy(currentLog);
            GameObject l = Instantiate(log, logPositions[logsPlaced], Quaternion.identity);
            l.transform.localEulerAngles = new Vector3(5.203f, 0.052f, 0.348f);
            logs -= 1;
            logsPlaced += 1;
            if(logsPlaced == 7)
            {
                gameObject.GetComponent<Dialogue>().PlayPlayerDialogue(6);
                Invoke("Fade", 2);
            }
        }
	}

    void Fade()
    {
        gameObject.GetComponent<Dialogue>().FadeToBlack();
        Destroy(this);
    }
}
