using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	private int enemyHP = 5;

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

    public void EnemyReact () {
		HealthScript.Hit (20);
	}

	public void EnemyHit (int gunStrength) {
		enemyHP -= gunStrength;
		if(enemyHP <= 0) {
			Destroy (gameObject);
			ScoreScript.AddScore(10);
		}
	}
}
