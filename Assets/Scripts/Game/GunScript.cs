using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {
	bool haveGun = true;
	public Rigidbody2D[] gunsRigidBody;

	Rigidbody2D currentWeaponRigidBody;
	public GameObject[] gunsObject;

	public int nextChangeGun = 1;
	public static int currentGun = 1;
	public float speed = 18f;				// rychlost projektilu
	private float fireRate = 0f;
	private float lastShoot = 0f;
	private float[] gunsFireRate = {1f, 0.4f, 2};  // nastavenie rychlosti strelby zbrani
	public bool shooting = true; 

	public AudioClip[] gunsClips;

	private PlayerControllerScript playerCtrl;		// Reference to the PlayerControl script.
	
	void Awake() {
		playerCtrl = transform.root.GetComponent<PlayerControllerScript>();
	}

	void Start() {
		gunsObject[0].SetActive(true);
		gunsObject[1].SetActive(false);
		gunsObject[2].SetActive(false);
		currentWeaponRigidBody = gunsRigidBody[0];
		nextChangeGun = 2;
	}

	public void ChangeWeapon() {
		if (haveGun) {
			switch(nextChangeGun) {
			case 1:
				gunsObject[0].SetActive (true);
				gunsObject[1].SetActive (false);
				gunsObject[2].SetActive (false);
				currentGun = nextChangeGun;
				nextChangeGun = 2;
				currentWeaponRigidBody = gunsRigidBody[0];
				break;
			case 2:
				gunsObject[0].SetActive (false);
				gunsObject[1].SetActive (true);
				gunsObject[2].SetActive (false);
				currentGun = nextChangeGun;
				nextChangeGun = 3;
				currentWeaponRigidBody = gunsRigidBody[1];
				break;
			case 3:
				gunsObject[0].SetActive (false);
				gunsObject[1].SetActive (false);
				gunsObject[2].SetActive (true);
				currentGun = nextChangeGun;
				nextChangeGun = 1;
				currentWeaponRigidBody = gunsRigidBody[2];
				break;
 			}

			AmmoScript.ChangeWeapon(currentGun);
		} else {
		    // todo dialog nemas ziadnu zbran
		}
	}

	public void Shoot() {   // todo firerate zbrani
		if (haveGun) {

			if (Time.time > fireRate + lastShoot) {
				bool emptyStack = AmmoScript.TakeAmmo(currentGun);  // zistenie ci zasobnik nie je prazdny
				if(emptyStack) {
					switch (currentGun) {
					case 1: 
						fireRate = gunsFireRate[0]; // pistol
						AudioSource.PlayClipAtPoint(gunsClips[0], transform.position);
						break;
					case 2:
						fireRate = gunsFireRate[1]; // automachine
						AudioSource.PlayClipAtPoint(gunsClips[1], transform.position);
						break;
					case 3: 
						fireRate = gunsFireRate[2];   // bazooka
						AudioSource.PlayClipAtPoint(gunsClips[2], transform.position);
						break;
					}

					BulletMove ();

				} 
				lastShoot = Time.time;
			}
		} else {
		    // todo nemas ziadnu zbran
		}
	}

	private void BulletMove() {
		if(playerCtrl.facingRight)
		{
			// ... instantiate the rocket facing right and set it's velocity to the right. 
			Rigidbody2D bulletInstance = Instantiate(currentWeaponRigidBody, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(speed, 0);
		}
		else
		{
			// Otherwise instantiate the rocket facing left and set it's velocity to the left.
			Rigidbody2D bulletInstance = Instantiate(currentWeaponRigidBody, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(-speed, 0);
		}
	}
}
