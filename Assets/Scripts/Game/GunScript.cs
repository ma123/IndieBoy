using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {
	bool haveGun = true;
	public Rigidbody2D bazookaRigidBody;				// bazooka bullet
	public Rigidbody2D automachineRigidBody;				// automachine bullet
	public Rigidbody2D pistolRigidBody;				// pistol bullet
	Rigidbody2D currentWeaponRigidBody;
	public GameObject pistolObject;
	public GameObject automachineObject;
	public GameObject bazookaObject;

	public int currentGun = 2;
	public float speed = 18f;				// The speed the rocket will fire at.
	public float fireRate = 0;

	private PlayerControllerScript playerCtrl;		// Reference to the PlayerControl script.
	
	void Awake() {
		playerCtrl = transform.root.GetComponent<PlayerControllerScript>();
		print (playerCtrl);
	}

	void Start() {
		pistolObject.SetActive(true);
		automachineObject.SetActive(false);
		bazookaObject.SetActive(false);
		currentWeaponRigidBody = pistolRigidBody;
		currentGun = 2;
	}

	public void ChangeWeapon() {
		if (haveGun) {
			if (currentGun == 1) {
				pistolObject.SetActive (true);
				automachineObject.SetActive (false);
				bazookaObject.SetActive (false);
				currentGun = 2;
				currentWeaponRigidBody = pistolRigidBody;
			} else {
				if (currentGun == 2) {
					pistolObject.SetActive (false);
					automachineObject.SetActive (true);
					bazookaObject.SetActive (false);
					currentGun = 3;
					currentWeaponRigidBody = automachineRigidBody;
				} else {
					pistolObject.SetActive (false);
					automachineObject.SetActive (false);
					bazookaObject.SetActive (true);
					currentGun = 1;
					currentWeaponRigidBody = bazookaRigidBody;
				}
			}
		} else {
		    // todo dialog nemas ziadnu zbran
		}
	}

	public void Shoot() {   // todo firerate zbrani
		BulletMove ();
	}

	void BulletMove() {
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
