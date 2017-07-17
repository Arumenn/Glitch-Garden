﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Chicken : MonoBehaviour {
	
	private Animator anim;
	private Attacker attacker;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D collider){		
		GameObject obj = collider.gameObject;
		
		//ignore if not colliding with a defender
		if (!obj.GetComponent<Defender>()){
			return;
		}
		
		anim.SetBool("isAttacking", true);
		attacker.Attack (obj);
	}
}
