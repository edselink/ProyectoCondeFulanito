using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]
public class AreaCreator : MonoBehaviour {

	public GameObject cursor;
	public GameObject obj;
	public Vector3 movementAxis = new Vector3(1, 0, 0);
	public Vector3 spawnPoint;

	public void spawnObj()
	{
		GameObject temp = Instantiate(obj);
		temp.transform.localPosition = spawnPoint;
		temp.transform.parent = transform;
	}
}
