using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour {
	void OnTriggerStay (Collider other) {
		if(other.tag == "Player") {

			if(Input.GetKeyDown(KeyCode.E)) {
				Player player = other.GetComponent<Player>();;

				if (player != null) {

					if (player.hasCoin) {
						player.hasCoin = false;
						UIManager _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();

						if(_uimanager != false) {
							_uimanager.RemoveCoin();
						}

						AudioSource audio = GetComponent<AudioSource> ();
						audio.Play();
						player.EnableWeapons();

					} else {
						Debug.Log("Dê o Fora daqui!");
					}
				}
			}
		}
	}
}
