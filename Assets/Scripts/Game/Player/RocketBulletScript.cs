using UnityEngine;
using System.Collections;

public class RocketBulletScript : MonoBehaviour {
	private int gunStrength = 3;
	public GameObject explosion;		// prefab na explozia efekt

	void Start () 
	{
		Destroy(gameObject, 2);
	}
	
	void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		
		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate(explosion, transform.position, randomRotation);
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Enemy") {
			col.gameObject.GetComponent<EnemyScript> ().EnemyHit (gunStrength);
			OnExplode();
			Destroy (gameObject);
		} else {
			if (col.tag == "Boss") {
				col.gameObject.GetComponent<BossScript> ().EnemyHit (gunStrength);
				OnExplode();
				Destroy (gameObject);
			} else {
				if (col.gameObject.tag != "Player") {
					Destroy (gameObject);
				}
			}
		}
	}
}
