using UnityEngine;
using System.Collections;

public class PistolScript : MonoBehaviour {
	private int gunStrength = 1;

	void Start () {
		Destroy(gameObject, 2); // znicenie naboja po 2 sekundach ak nenajde ciel
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Enemy") {
			col.gameObject.GetComponent<EnemyScript> ().EnemyHit (gunStrength);
			Destroy (gameObject);
		} else {
			if (col.tag == "Boss") {
				col.gameObject.GetComponent<BossScript> ().EnemyHit (gunStrength);
				Destroy (gameObject);
			} else {
				if (col.gameObject.tag != "Player") {
					Destroy (gameObject);
				}
			}
		}
	}
}
