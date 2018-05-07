using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField] private Text _textAmmo;
	[SerializeField] private GameObject coin;
	[SerializeField] private GameObject ammoText;
	public void UpdateAmmo (int count) {		
		if(count == 99999) {
			_textAmmo.text = "Reloading...";
		} else {
			_textAmmo.text = "Ammo: " + count;					
		}		
	}

	public void CollectedCoin () {
		coin.SetActive(true);
	}

	public void RemoveCoin () {
		coin.SetActive(false);
	}

	public void ShowAmmoText () {
		ammoText.SetActive(true);
	}
}
