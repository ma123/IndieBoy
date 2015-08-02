using UnityEngine;
using System.Collections;

public class PistolScript : MonoBehaviour {
	private int gunStrength = 1;

	void Start () {
		Destroy(gameObject, 2); // znicenie naboja po 2 sekundach ak nenajde ciel
	}

	void OnTriggerEnter2D (Collider2D col) {
		// If it hits an enemy...
		if (col.tag == "Enemy") {
			// ... find the Enemy script and call the Hurt function.
			print ("shoot automachine");
			col.gameObject.GetComponent<EnemyScript> ().EnemyHit(gunStrength);
			// Call the explosion instantiation.
			//OnExplode();
			
			// Destroy the rocket.
			Destroy (gameObject);
		}
		// Otherwise if the player manages to shoot himself...
		else if(col.gameObject.tag != "Player")
		{
			// Instantiate the explosion and destroy the rocket.
			//OnExplode();
			Destroy (gameObject);
		}
	}
}
