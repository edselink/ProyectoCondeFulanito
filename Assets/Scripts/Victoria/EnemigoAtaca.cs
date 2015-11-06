using UnityEngine;
using System.Collections;

public class EnemigoAtaca : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player") {
		Debug.Log ("Le pegue");
		}*/

		void OnCollisionEnter(Collision collision){
				Debug.Log ("Le pegue");
	}
}
