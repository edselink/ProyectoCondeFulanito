using UnityEngine;
using System.Collections;

public class Enemy1 : Actor {
	private RaycastHit hit;

	public Enemy1() {
		Velocity = new Vector2 (1f, 0f);
	}

	// Componentes
	private Actions actions;

	// Funciones
	public override void attack() {
		throw new System.NotImplementedException ();
	}

	public override void beAttacked() {
		throw new System.NotImplementedException ();
	}

	public override void die() {
		throw new System.NotImplementedException ();
	}

	public override void move() {
		//hit = actions.check (GameObject.FindGameObjectWithTag ("player").GetComponent<Transform>().position, 3f);
		if(actions.patrolRunning == false)
			StartCoroutine (actions.patrol (Vector2.left, 2, 2, 3));
		if (Physics.Raycast(gameObject.transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position, out hit, 3f))
			if(hit.collider.tag == "Player")
				Debug.Log("Found the player!");
		if(actions.check(GameObject.FindGameObjectWithTag ("Player").transform.position, 3f)) {
			if(actions.HitInfo.collider.tag == "Player")
				Debug.Log ("Found the player!");
		}
	}

	// Metodos Unity
	// Use this for initialization
	void Start () {
		actions = GetComponent<Actions> ();
		actions.Velocity = Velocity;
	}

	void Awake() {

	}
	
	// Update is called once per frame
	public override void Update () {
		move ();
	}

	public void FixedUpdate() {

	}
}
