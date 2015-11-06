using UnityEngine;
using System.Collections;


public class AtaqueEscudo : MonoBehaviour {
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
		
		if (Input.GetKeyDown ("z")) {
			
			if (attackTimer == 0) {
				Attack ();
				attackTimer = coolDown;
			}

		}

		if (Input.GetKey ("x")) {
			if (target.transform.rotation.y > 0) {
				Attack2 ();
			} 
		}

		else {
			if (target.transform.rotation.y != 90) {
				//EstadoInicial ();
			}
			
			
		}

	}
	
	private void Attack(){


		target.GetComponent<ObjetoLanzable>().enabled = true;
		target.GetComponent<ObjetoLanzable> ().i = 0;
		target.GetComponent<ObjetoLanzable> ().j = 0;
		target.GetComponent<ObjetoLanzable> ().couroutine01 = true;
		target.GetComponent<ObjetoLanzable> ().couroutine02 = false;




	} 


	private void Attack2(){
		
		target.transform.Rotate(Vector3.up, -60f );
		
	} 


	private void EstadoInicial(){
		
		target.transform.Rotate (Vector3.up, 90f);
		
	} 
}
