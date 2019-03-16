using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public Vector2[] logPositions;
    public bool inZone;
    bool hasTool;
    int logs;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Tool" && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(other.gameObject);
            hasTool = true;
        }
        if (other.tag == "Tree" && Input.GetKeyDown(KeyCode.E) && hasTool)
        {
            Destroy(other.gameObject);
            logs += 1;
            print(logs);
        }
    }

    void Start ()
    {
        print(logs);
    }
	
	void Update ()
    {
		if(inZone && Input.GetKeyDown(KeyCode.E) && logs > 0)
        {
            print("Placed Log");
            logs -= 1;
        }
	}
}
