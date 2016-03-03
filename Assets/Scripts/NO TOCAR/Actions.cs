using UnityEngine;
using System.Collections;

public class Actions : Raycast {
	// Variables
	public bool goToRunning;
	public bool patrolRunning;
	private float interactChance;
	
	// Propiedades
	public Vector2 Velocity { get; set; }

	public Rigidbody RB2D { get; set; }

	public float BaseChance { get; set; }
	
	public float InteractChance {
		get {
			// Algoritmo de probabilidad.
			// Hacer uso de baseChance.
			return interactChance;
		}
	}
	
	public float DistanceTraveled { get; set; }
	
	// Metodos
	public void idle() {
		// Accion que debera ser ejecutada en estado de reposo
		// Ejemplo de Uso //
		/* Si no ha sido atacado
		   mantener posicion */
		//----------------//
		// Deter cualquier aceleracion y velocidad.
		// Animacion de reposo.
	}

	public IEnumerator goTo(Vector2 direction, float target) {
		// Mover gameObject a una posicion determinada.
		goToRunning = true;
		Debug.Log ("Will move " + target + "Units");
		while (DistanceTraveled < target) {
			DistanceTraveled += Velocity.x * Time.fixedDeltaTime;
			RB2D.velocity = Vector2.Scale (direction, Velocity);
			yield return null;
		}
		Debug.Log ("Reached target!");
		RB2D.velocity = new Vector2 (0, 0);
		DistanceTraveled = 0;
		goToRunning = false;
	}
	
	public void jump() {
		// Accion de salto
		// Ejemplo de Uso //
		/* Si el objetivo se encuentra en:
		   Un valor de "Y" mas alto && Existe una plataforma en rango
		   saltar a plataforma. */
		//----------------//
	}
	
	public void crouch() {
		// Accion de agacharse
		// Ejemplo de Uso //
		/* Implementable en conjunto con el metodo calcInteract() */
		//----------------//
		// Animacion de agachar.
		// Reducir tamaño de hitbox.
	}
	
	public IEnumerator patrol(Vector2 direction, float target1, float target2, float delay) {
		//float distanceTraveled; // Valor incrementado en base a la velocidad
		// Recibe un valor para definir el limite de patruyaje
		// Hace uso de check() para identificar obstaculos
		//if((check() == gap || obstacle) || distanceTraveled >= maxDistance) {
		//	distanceTraveled = 0;
		// Cambiar direccion de movimiento
		//}
		//yield WaitForSeconds(delay);
		patrolRunning = true;
		Debug.Log("Commencing patrol between: " + target1 + " and " + target2);
		while (gameObject) {
			while (DistanceTraveled < target1) {
				DistanceTraveled += Velocity.x * Time.fixedDeltaTime;
				RB2D.velocity = Vector2.Scale (direction, Velocity);
				yield return null;
			}
			DistanceTraveled = 0;
			direction = Vector2.Scale (direction, new Vector2(-1, 0));
			yield return new WaitForSeconds(delay);
			while (DistanceTraveled < target2) {
				DistanceTraveled += Velocity.x * Time.fixedDeltaTime;
				RB2D.velocity = Vector2.Scale (direction, Velocity);
				yield return null;
			}
			DistanceTraveled = 0;
			direction = Vector2.Scale (direction, new Vector2(-1, 0));
			yield return new WaitForSeconds(delay);
			yield return null;
		}
		Debug.Log ("Object died!");
		patrolRunning = false;
	}
	
	public void alert() {
		// Ejemplo de Uso //
		/* Si el objetivo entra dentro del rango
		      Mirar objetivo
		      Animacion de alerta */
		//----------------//
	}
	
	// NO IMPLEMENTAR AUN
	public void interact() {
		// Ejemplo de Uso //
		//if(InteractChance.get() >= value) {
		// Interactuar con GameObject
		//}
		//----------------//
	}

	// Metodos Unity
	void Start() {
		RB2D = gameObject.GetComponent<Rigidbody> ();
	}
}
