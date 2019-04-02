using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    Animator anim;
    public bool inZone;
    bool hasTool;
    int logs;
    bool marked;
    public GameObject xMark;
    public GameObject tool;
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
            //PlayerMove.paused = true;
            //anim.SetTrigger("Pick");
            Destroy(other.gameObject);
            //Invoke("UnPause", 7.5f);
            hasTool = true;
        }
        if (other.tag == "Tree" && Input.GetKeyDown(KeyCode.E) && hasTool && marked && logs == 0)
        {
            //PlayerMove.paused = true;
            //anim.SetTrigger("Chop");
            Destroy(other.gameObject);
            currentLog = Instantiate(log, transform.position, Quaternion.identity);
            currentLog.transform.parent = transform;
            currentLog.transform.localPosition = logCarryPosition;
            currentLog.transform.localEulerAngles = new Vector3(3.26f, -20.2f, 180);
            //Invoke("UnPause", 2.4f);
            logs += 1;
            print(logs);
        }
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
        if (inZone && Input.GetKeyDown(KeyCode.E) && !marked)
        {
            GameObject g = Instantiate(xMark, xMarkPosition, Quaternion.identity);
            g.transform.Rotate(90,-17.1f,0);
            marked = true;
        }
        if (inZone && Input.GetKeyDown(KeyCode.E) && logs > 0 && marked)
        {
            Destroy(currentLog);
            Instantiate(log, logPositions[logsPlaced], Quaternion.identity);
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
