using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private CharacterController _controller;

	[SerializeField]
	private float _speed = 3.5f;
	private float _gravity = 9.81f; //Gravidade da Terra

	// Use this for initialization
	void Start () {	
		_controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		CalculateMove();
	}

	void CalculateMove() {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		// Guarda direcao de acordo com a entrada no controle do jogador
		Vector3 direction = new Vector3( horizontal, 0, vertical);
		Vector3 velocity = direction * _speed;

		//Aplica gravidade no personagem
		velocity.y -= _gravity;

		// Aplica Movimentação
		_controller.Move(velocity * Time.deltaTime);
	}

}
