using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject[] candyPrefab;
	public GameObject candyHolder;
	public CandyHolder candyholder;
	public float shotSpeed;
	public float shotTorTorque;
	public float baseWidth;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) Shot ();
	}

	// Return a vector of shooter
	Vector3 GetInstantiatePosition() {
		float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
		return transform.position + new Vector3 (x, 0, 0);
	}

	GameObject ChoosedCandy() {
		GameObject prefab = null;

		int index = Random.Range (0, candyPrefab.Length);
		prefab = candyPrefab [index];
		return prefab;
	}
		
	public void Shot() {
		if (candyholder.GetCandyAmount () <= 0)
			return;

		GameObject candy = (GameObject) Instantiate (
							   ChoosedCandy(),
							   GetInstantiatePosition(),
			                   Quaternion.identity
		                   );

		Rigidbody candyRigidBody = candy.GetComponent<Rigidbody> ();
		candyRigidBody.AddForce (transform.forward * shotSpeed);
		candyRigidBody.AddForce (new Vector3 (0, shotTorTorque, 0));

		candyholder.ConsumeCandy ();
	}
}
