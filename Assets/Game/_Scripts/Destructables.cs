using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructables : MonoBehaviour {

	[SerializeField] private GameObject _crateDestroyd;

	public void DestroyCrate () {
		Instantiate(_crateDestroyd, transform.position, transform.rotation);
		Destroy(this.gameObject);
	}
}
