using UnityEngine;
using System.Collections;

public abstract class Attack : MonoBehaviour {
	// Campos
	private int dmg;
	private float accuracy;
	private int cooldown;
	private Weapon weapon;
	private Weapon[] weapons;

	// Propiedades
	public int Dmg { get; set; }
	public float Accuracy { get; set; }
	public int Cooldown { get; set; }
	public Weapon Weapon { get; set; }
	public Weapon[] Weapons { get; set;}

	public abstract void attack();
	public void launchProyectile() {

	}
}
