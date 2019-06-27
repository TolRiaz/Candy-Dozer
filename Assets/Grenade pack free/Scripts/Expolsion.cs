using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expolsion : MonoBehaviour {


	// Grenade explodes after a time delay.
	private float Timer;
	public float fuseTime;
	Collider col = gameObject.GetComponent<BoxCollider>();


	void Start() {
		Timer = 0;	// set the current time
	}
		
	void Explode() {
		
		// var exp = GetComponent<ParticleSystem>();
		// exp.Play();
		Destroy(gameObject); //, exp.duration);
	}

	void Update() {
		Timer += Time.deltaTime;
		if (Timer >= fuseTime) {
			Explode ();
		}
	}
}
