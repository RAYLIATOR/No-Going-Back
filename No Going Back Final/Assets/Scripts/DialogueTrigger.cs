using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public int i;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Dialogue>().PlayDialogue(i);
            Destroy(gameObject);
        }
    }
    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
