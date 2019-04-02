using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    bool attack;
    public int i;
    GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("Hit");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !attack)
        {
            other.gameObject.GetComponent<Dialogue>().PlayMemoryDialogue(i, this);
        }
        else if(other.tag == "Player")
        {
            print("Issue");
        }
    }

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
		if(attack)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward;
        }
	}

    public void AttackCommand(float t)
    {
        Invoke("Attack", t);
    }

    void Attack()
    {
        attack = true;
    }
}
