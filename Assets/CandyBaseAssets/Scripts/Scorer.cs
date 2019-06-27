using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour {

	uint score;
	string label;
	public CandyHolder ch;
	public int reward;
	public GameObject point;

	void Start() {
		score = 0;
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Candy") {
			Destroy (col.gameObject);
			score++;
			ch.AddCandy (reward);
			GameObject star = (GameObject)Instantiate (point, transform.position, Quaternion.identity);
			star.transform.Translate (0, 10, 0);
			Destroy (star, 3.0f);
		}
	}

	void Update() { 
		label = "Score: " + score.ToString ();
	}

	void OnGUI() {
		GUI.color = Color.black;
		GUI.Label (new Rect (10, 10, 100, 300), label);
	}
}
