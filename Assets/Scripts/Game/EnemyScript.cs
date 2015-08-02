using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public GameObject parts;
	private int enemyHP = 5;
	private float waitTime = 2;

	public float walkSpeed = 1.0f;      // Walkspeed
	public float wallLeft = 0.0f;       // Define wallLeft
	public float wallRight = 5.0f;      // Define wallRight
	float walkingDirection = 1.0f;
	Vector2 walkAmount;
	float originalX; // Original float value
	
	
	void Start () {
		this.originalX = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
		if (walkingDirection > 0.0f && transform.position.x >= originalX + wallRight) {
			walkingDirection = -1.0f;
		} else if (walkingDirection < 0.0f && transform.position.x <= originalX - wallLeft) {
			walkingDirection = 1.0f;
		}
		transform.Translate(walkAmount);
	}

    public void React () {
		HealthScript.Hit (50);
		Destroy (gameObject);
		//StartCoroutine(Example());

		//PlayerCollisionScript.damageLock = true;
	}

	/*IEnumerator Example() {
		yield return new WaitForSeconds(waitTime);
	} */

	public void EnemyHit (int gunStrength) {
		print (enemyHP);
		enemyHP -= gunStrength;
		if(enemyHP <= 0) {
			Destroy (gameObject);
			ScoreScript.AddScore(10);
		}

		//Destroy (gameObject, 1); // druhy parameter urcuje cas vykonania
	}
}
