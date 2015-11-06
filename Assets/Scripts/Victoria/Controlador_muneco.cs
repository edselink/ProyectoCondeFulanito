using UnityEngine;
using System.Collections;

public class Controlador_muneco : MonoBehaviour {

	float movimiento_recto;
	float movimiento_horizontal;
	public Animator animacion;
	bool salto;
	bool slide;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		movimiento_recto = Input.GetAxis ("Vertical");
		movimiento_horizontal = Input.GetAxis ("Horizontal");
		animacion.SetFloat ("velocidad", movimiento_recto);
		animacion.SetFloat ("horizontal", movimiento_horizontal);
		salto = Input.GetKeyDown (KeyCode.LeftShift);
		animacion.SetBool("salto", salto);
		slide = Input.GetKeyDown (KeyCode.Z);
		animacion.SetBool("slide", slide);
	}
}
