using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//public variables
	//private variables
	GameObject target;
	Animator anim;
	float speed;
	float chaseRange;
	float attackRange;
	float distanceToTarget;
	float attackRate;
	float attackTime;

	void Start ()
	{
		target = GameObject.FindGameObjectWithTag("Player");
		anim = GetComponent<Animator>();
		speed = 0.1f;
		chaseRange = 15f;
		attackRange = 3f;
		attackRate = 2;
		attackTime = 0;
	}
	
	void Update ()
	{
		distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
		if (distanceToTarget < chaseRange)
		{
			Chase();
		}
		else
		{
			anim.SetTrigger("Idle");
		}
	}

	void Chase()
	{
		transform.LookAt(target.transform);
		if (distanceToTarget < attackRange)
		{
			Attack();
		}
		else
		{
			transform.position += transform.forward * speed;
			anim.SetTrigger("Chase");
		}
	}

	void Attack()
	{
		if (Time.time >= attackTime)
		{
			anim.SetTrigger("Attack1");
			attackTime = Time.time + attackRate;
		}
	}

	void Idle()
	{
		anim.SetTrigger("Idle");
	}
}
