using UnityEngine;
using System.Collections;

//Creamos un tipo enumerado para definir la dirección
//public enum Direccion { Horizontal}

public class ObjetoLanzable : MonoBehaviour
{
	
	//Variables publicas
	//public Direccion DireccionArma = Direccion.Horizontal;

	public GameObject target;
	public GameObject helen;
	
	public bool couroutine01= true;
	public bool couroutine02= false;
	
	//Variables privadas
	private Rigidbody thisRigidbody;
	
	public Transform target01;
	public Transform origen;
	public Transform destino;
	public float fract;
	
	public int i=0;
	public int j=0;

	


	void Start ()
	{
		
	}
	
	
	void Update ()
	{


		if (couroutine01) {
			
			
			StartCoroutine (Lanza(0.0002f));
			
		}
		
		if (couroutine02) {
			
			
			StartCoroutine (Atrapa(0.0002f));
			
		}
	}

	
	IEnumerator Lanza(float seconds){
		couroutine01 = false;
		i++;
		
		
		transform.position = Vector3.Lerp (target01.position, destino.position, fract);
		target.transform.parent = null;
		couroutine01 = true;
		
		if (i >= 25) {
			couroutine01 = false;
			couroutine02 = true;

		}
		
		yield return new WaitForSeconds(seconds);
	}
	
	IEnumerator Atrapa(float seconds){
		couroutine02 = false;
		j++;
		
		transform.position = Vector3.Lerp (target01.position, origen.position, fract);
		//target.transform.parent = ;
		couroutine02 = true;
		
		if (j >= 40) {
			couroutine01 = false;
			couroutine02 = false;
			target.GetComponent<ObjetoLanzable>().enabled = false;
			target.transform.parent = helen.transform;
		}
		yield return new WaitForSeconds(seconds);
		
	}
	
}