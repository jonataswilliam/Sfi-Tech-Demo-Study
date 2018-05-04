using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

	[SerializeField]
	private AudioClip _coinSound;	

	private void OnTriggerStay (Collider other) {
		if(other.tag == "Player") {
			
			if (Input.GetKeyDown(KeyCode.E)) {
				Player player = other.GetComponent<Player>();
				
				if(player != null) {
					player.hasCoin = true;
					// Posicao de onde o som sairá. Utilizamos a camera para ter certeza que o player ouvirá
					AudioSource.PlayClipAtPoint(_coinSound, Camera.main.transform.position, 1f);
					UIManager _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
					if(_uimanager != null) {
						_uimanager.CollectedCoin();
					}

					Destroy(this.gameObject);
				}
			}
		}
	}
}
