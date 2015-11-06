using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {
	// Campos
	private Ray targetRay;
	private RaycastHit hitInfo;

	// Propiedades
	public Ray TargetRay { get; set; }
	public RaycastHit HitInfo { get; set; }

	// Constructor
	public Raycast() {

	}

	// Funciones
	// Implementacion de Raycast para simular observacion
	/*public RaycastHit check(Vector3 targetPos, float range) {
		TargetRay = new Ray(gameObject.transform.position, targetPos);
		if (Physics.Raycast (TargetRay, out hitInfo, range))
			return hitInfo;
		else
			return null;
	}*/

	public bool check(Vector3 targetPos, float range) {
		TargetRay = new Ray (gameObject.transform.position, targetPos);
		return Physics.Raycast (TargetRay, out hitInfo, range);
	}

	public void debugRay() {

	}
}
