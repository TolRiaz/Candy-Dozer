using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expolsion : MonoBehaviour {


	// Grenade explodes after a time delay.
	private float Timer;
	public float fuseTime;
	public float expTime = 0.1f;
	public GameObject expPrefab;

	void Start() {
		Timer = 0;	// set the current time
	}
		
	void Explode() {
		var col = gameObject.GetComponent<BoxCollider>();
		col.size = new Vector3 (1.0f, 1.0f, 1.0f);
		if (Timer >= fuseTime + expTime) {
			GameObject exp = (GameObject)Instantiate (expPrefab, transform.position); 
			var exp_component = exp.GetComponent<ParticleSystem>();
			exp_component.Play ();
			Destroy(gameObject, exp_component.duration);
			Destroy (exp, exp_component.duration);
		}
	}

	void Update() {
		Timer += Time.deltaTime;
		if (Timer >= fuseTime) {
			Explode ();
		}
	}
}
