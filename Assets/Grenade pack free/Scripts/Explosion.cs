using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Grenade explodes after a time delay.
	private float Timer;
	public float fuseTime;
	float expTime = 0.1f;
	public GameObject expPrefab;

	void Start() {
		Timer = 0;	// set the current time
	}

	void Explode() {
		var col = gameObject.GetComponent<BoxCollider>();
		col.size = new Vector3 (1.0f, 1.0f, 1.0f);
		GameObject exp = (GameObject)Instantiate (expPrefab, transform.position, Quaternion.identity); 
		Destroy(gameObject);
		Destroy (exp, 0.5f);
	}

	void Update() {
		Timer += Time.deltaTime;
		if (Timer >= fuseTime) {
			Explode ();
		}
	}
}
