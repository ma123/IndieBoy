using UnityEngine;
using System.Collections;

public class EnemyBuletScript : MonoBehaviour {
	private int gunStrength = 30;
	
	void Start () {
		Destroy(gameObject, 2); // znicenie naboja po 2 sekundach ak nenajde ciel
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			print ("shoot enemy");
			HealthScript.Hit (gunStrength);
			Destroy (gameObject);
		} else {
			if (col.gameObject.tag != "Enemy") {
				Destroy (gameObject);
			}
		}
	}
}
