﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public int enemyHP = 5;
	public int attackStrength = 20;

	public float walkSpeed = 1.0f;      // Walkspeed
	public float wallLeft = 0.0f;       // Define wallLeft
	public float wallRight = 5.0f;      // Define wallRight
	private float walkingDirection = 1.0f;
	private Vector2 walkAmount;
	private float originalX; // Original float value

	public bool shooting = true;
	public Rigidbody2D enemyWeaponRigidBody;
	public float bulletSpeed = 19.0f;
	public float fireRate = 2.0f;
	private float lastShoot = 0f;
	
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

		if(shooting) {
			if (Time.time > fireRate + lastShoot) {
				BulletMove();
				lastShoot = Time.time;
			}
		}
	}

    public void EnemyReact () {
		HealthScript.Hit (attackStrength);
	}

	public void EnemyHit (int gunStrength) {
		enemyHP -= gunStrength;
		if(enemyHP <= 0) {
			Destroy (gameObject);
			ScoreScript.AddScore(10);
		}
	}

	private void BulletMove() {
		if(walkingDirection > 0.0f) {
			Rigidbody2D bulletInstance = Instantiate(enemyWeaponRigidBody, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(bulletSpeed, 0);
		}
		else {
			Rigidbody2D bulletInstance = Instantiate(enemyWeaponRigidBody, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(-bulletSpeed, 0);
		}
	}
}
