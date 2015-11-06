using UnityEngine;
using System.Collections;

public class NoGirar : MonoBehaviour {
	//private float LockedX = 0;
	private float LockedY = 2.5f; 
	private float LockedZ = -12;
	
	public GameObject player;
	
	void Update() { 
		transform.position = new Vector3(player.transform.position.x, LockedY, LockedZ); 
	}
	
}
