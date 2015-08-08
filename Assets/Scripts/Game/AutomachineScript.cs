using UnityEngine;
using System.Collections;

public class AutomachineScript : MonoBehaviour {
	private int gunStrength = 2;

	void Start () {
		Destroy(gameObject, 2);
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
