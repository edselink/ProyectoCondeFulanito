using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(AreaCreator))]
public class AreaCreatorEditor : Editor {

	public override void OnInspectorGUI() {
		AreaCreator AC = (AreaCreator)target;

		// GUI Area
		DrawDefaultInspector ();
		if (GUILayout.Button ("Spawn Object")) {
			AC.spawnObj ();
		}

		// Update Area
		AC.spawnPoint = AC.cursor.transform.localPosition;
	}
}
