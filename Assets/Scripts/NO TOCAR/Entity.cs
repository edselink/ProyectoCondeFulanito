using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
	// Campos
	struct infoAttack {
		GameObject who;
		bool impact;
		int originalDmg;
		int trueDmg;
	}
	private string name;

	// Propiedades
	public string Name { get; set; }
}
