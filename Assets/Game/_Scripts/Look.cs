using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {

	[SerializeField]
	private float _sensitivity = 1f;
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
		Vector3 newRotationX = transform.eulerAngles;
		Vector3 newRotationY = transform.localEulerAngles;

		// Aplicando valor apenas no eixo desejado;
		newRotationX.y += _mouseX * _sensitivity;
		// Verifica se a rotacao para Y esta setada para invertida
		if(invertYRotation) {			
			newRotationY.x += _mouseY * _sensitivity;
		} else {
			newRotationY.x -= _mouseY * _sensitivity;
		}	

		// Atualizando valores do transform inteiro.
		transform.eulerAngles = newRotationX;
		transform.localEulerAngles = newRotationY;
	}
}
