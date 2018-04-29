using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {

	[SerializeField]
	private float sensitivity = 1f;
	[SerializeField]
	private bool invertYRotation = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float _mouseX = Input.GetAxis("Mouse X");
		float _mouseY = Input.GetAxis("Mouse Y");

		// Para pegar o valor de rotacao de um eixo individual utilizamos Euler e não Quartenium.
		// Armazenando valores do tranform atual em uma variável temporária
		Vector3 newRotation = transform.localEulerAngles;

		// Aplicando valor apenas no eixo desejado;
		newRotation.y += _mouseX * sensitivity;
		// Verifica se a rotacao para Y esta setada para invertida
		if(invertYRotation) {			
			newRotation.x += _mouseY * sensitivity;
		} else {
			newRotation.x -= _mouseY * sensitivity;
		}	

		// Atualizando valores do transform inteiro.
		transform.localEulerAngles = newRotation;
	}
}
