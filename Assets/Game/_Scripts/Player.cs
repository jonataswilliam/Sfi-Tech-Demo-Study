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

		// Escondendo e travando o Mouse no centro do tela
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update () {
		CalculateMove();

		// Habilitando cursor novamente se o ESC for pressionando.
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}


		if(Input.GetMouseButtonDown(0)) {
			// Armazenando o valor do centro da tela
			// Vector3 _centerOfScreen = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
			// Criando a origem do disparo do RayCast pelo centro da tela
			// Ray rayOrigin = Camera.main.ScreenPointToRay(_centerOfScreen);


			// Criando a origem do disparo do RayCast usando a viewport como referencia. O calculo da viewport é feito de 0 a 1.
			Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			
			// Tipo de dado para armazenar informacao de retorno do raycast informando o que foi atingido.
			RaycastHit hitInfo;

			Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

			// Chamando o sistema de disparo do RayCast. Verifica se atinge algum object que possui um Collider. Distancia maximo do raio(MaxDepth) = Infinito
			// if(Physics.Raycast(rayOrigin, Mathf.Infinity)) {
			

			// Chamando o sistema de disparo do RayCast. Verifica se atinge algum object que possui um Collider. HitInfo retornará informacoes do objeto atingido.
			if(Physics.Raycast(rayOrigin, out hitInfo)) {			
				Debug.Log("Hit:" + hitInfo.transform.name);
			}
		}

	}

	void CalculateMove() {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
		// Guarda direcao de acordo com a entrada no controle do jogador
		Vector3 direction = new Vector3( horizontal, 0, vertical);
		Vector3 velocity = direction * _speed;		

		//Aplica gravidade no personagem
		velocity.y -= _gravity;

		// Transformando valores que alteram o Local Space para alteração do World Space.
		velocity = transform.transform.TransformDirection(velocity);	
		
 
		// Aplica Movimentação
		_controller.Move(velocity * Time.deltaTime);
	}

}
