﻿using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject target;
	private float attackTimer;
	private float coolDown;

	// Use this for initialization
	void Start () {
		attackTimer = 0;
		coolDown = 0.5f;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTimer > 0)
						attackTimer -= Time.deltaTime;

		if (attackTimer < 0)
						attackTimer = 0;

		/*if (attackTimer == 0) {
			attackTimer = coolDown;
				}*/

		if (Input.GetKeyDown ("f")) {
			GetComponent<Animation>().Play("Attack");

			if (attackTimer == 0 ){
				Attack();
				attackTimer = coolDown;
			}
	
		}
	}

	private void Attack(){
	
	
		float distance = Vector3.Distance (target.transform.position, transform.position);

		Vector3 dir = (target.transform.position - transform.position).normalized;

		float direction = Vector3.Dot (dir, transform.forward);

		Debug.Log(distance);

		if (distance < 2.95f && direction > 0) {
			EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
			eh.AddjustCurrentHealth (-10);
			if (eh.curHealth==0)
				Destroy(GameObject.FindWithTag("Enemy"));
		}


	} 
}
