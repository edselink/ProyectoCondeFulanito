using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public GameObject target;
	public float attackTimer;
	public float coolDown;
	
	// Use this for initialization
	void Start () {
		attackTimer = 0;
		coolDown = 1.0f;
		
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

		if (attackTimer == 0 ){
				Attack();
				attackTimer = coolDown;
		}


	}
	


	private void Attack(){
		
		float distance = Vector3.Distance (target.transform.position, transform.position);
		
		Vector3 dir = (target.transform.position - transform.position).normalized;
		
		float direction = Vector3.Dot (dir, transform.forward);
		
		Debug.Log(distance);
		
		if (distance < 1.0f && direction > 0) {
			PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
			ph.AddjustCurrentHealth (-30);
			GameObject.FindWithTag("Player").GetComponent<Animation>().Play("Damage");

			//GameObject.FindWithTag("Player").transform.position = new Vector3(transform.position.x, transform.position.y-0.05f, transform.position.z - 0.05f );
			

			if(ph.curHealth==0){
				GameObject.FindWithTag("Player").GetComponent<Animation>().Play("Dead");
			}

		}
		
	} 
}
