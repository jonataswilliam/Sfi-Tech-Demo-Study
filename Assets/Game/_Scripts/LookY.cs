using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour {

	[SerializeField] float _sensitivity = 1f;
	private float pitch = 0.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// float _mouseY = Input.GetAxis("Mouse Y");
		// Vector3 newRotation = transform.localEulerAngles;		
		// newRotation.x -= _mouseY * _sensitivity;
		// transform.localEulerAngles = newRotation;

		// Correção BUG de Camera. Colocando limitador na rotação da camera.		
		pitch -= Input.GetAxis("Mouse Y") * _sensitivity;
		// A funcao Clamp Limita os valores max e min. 
		pitch = Mathf.Clamp(pitch, -50f, 65f);		
		print (pitch);
		transform.localEulerAngles = new Vector3 (pitch, transform.localEulerAngles.y, 0);		
	}
}
