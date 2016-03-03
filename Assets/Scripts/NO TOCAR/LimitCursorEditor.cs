using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LimitCursor))]
public class LimitCursorEditor : Editor {

	public override void OnInspectorGUI() {
		LimitCursor LC = (LimitCursor)target;
		Vector3 newPosition = LC.transform.localPosition;
		float tempPos;

		// Update Area
		/*// Copy parent's BoxCollider STILL NEEDS SOME FINE TUNING. WON'T WORK AS INTENDED.
		LC.GetComponent<BoxCollider> ().center = LC.transform.parent.GetComponent<BoxCollider> ().center;
		LC.GetComponent<BoxCollider> ().size = LC.transform.parent.GetComponent<BoxCollider> ().size; */
		// Limit X axis
		if (LC.transform.position.x > (LC.transform.parent.transform.position.x + LC.transform.parent.GetComponent<BoxCollider>().size.x)) {
			tempPos = LC.transform.parent.transform.position.x + LC.transform.parent.GetComponent<BoxCollider>().size.x;
			newPosition.x = tempPos;
			LC.transform.position = newPosition;
		}
		// Limit Y axis
		if (LC.transform.position.y > (LC.transform.parent.transform.position.y + LC.transform.parent.GetComponent<BoxCollider>().size.y)) {
			tempPos = LC.transform.parent.transform.position.y + LC.transform.parent.GetComponent<BoxCollider>().size.y;
			newPosition.y = tempPos;
			LC.transform.position = newPosition;
		}
		// Limit Z axis
		if (LC.transform.position.z > (LC.transform.parent.transform.position.z + LC.transform.parent.GetComponent<BoxCollider>().size.z)) {
			tempPos = LC.transform.parent.transform.position.z + LC.transform.parent.GetComponent<BoxCollider>().size.z;
			newPosition.z = tempPos;
			LC.transform.position = newPosition;
		}
	}
}
