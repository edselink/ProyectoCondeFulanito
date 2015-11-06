using UnityEngine;
using System.Collections;

public abstract class Actor : Entity {
	// Campos
	private int health;

	// Propiedades
	public int Health { get; set; }
	public Vector2 Velocity { get; set; }

	// Metodos
	public abstract void attack();
	public abstract void beAttacked();
	public abstract void die();
	public abstract void move();
	/*public virtual bool isOnGround() {

	}*/

	// Metodos Unity
	public virtual void Update() {

	}
}
