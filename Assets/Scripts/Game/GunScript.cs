using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {
	bool haveGun = true;
	public Rigidbody2D pistolRigidBody;				// pistol bullet
	public Rigidbody2D automachineRigidBody;				// automachine bullet
	public Rigidbody2D bazookaRigidBody;				// bazooka bullet

	Rigidbody2D currentWeaponRigidBody;
	public GameObject pistolObject;
	public GameObject automachineObject;
	public GameObject bazookaObject;

	public int currentGun = 1;
	public int currentAudioGun = 1;
	public float speed = 18f;				// The speed the rocket will fire at.
	public float fireRate = 0;

	public AudioClip pistolClips;
	public AudioClip automachineClips;	
	public AudioClip bazookaClips;	

	private PlayerControllerScript playerCtrl;		// Reference to the PlayerControl script.
	
	void Awake() {
		playerCtrl = transform.root.GetComponent<PlayerControllerScript>();
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
			switch(currentGun) {
			case 1:
				pistolObject.SetActive (true);
				automachineObject.SetActive (false);
				bazookaObject.SetActive (false);
				currentAudioGun = 1;
				currentGun = 2;
				currentWeaponRigidBody = pistolRigidBody;
				break;
			case 2:
				pistolObject.SetActive (false);
				automachineObject.SetActive (true);
				bazookaObject.SetActive (false);
				currentAudioGun = 2;
				currentGun = 3;
				currentWeaponRigidBody = automachineRigidBody;
				break;
			case 3:
				pistolObject.SetActive (false);
				automachineObject.SetActive (false);
				bazookaObject.SetActive (true);
				currentAudioGun = 3;
				currentGun = 1;
				currentWeaponRigidBody = bazookaRigidBody;
				break;
 			}

			AmmoScript.ChangeWeapon(currentAudioGun);
		} else {
		    // todo dialog nemas ziadnu zbran
		}
	}

	public void Shoot() {   // todo firerate zbrani
		if (haveGun) {
			bool emptyStack = AmmoScript.TakeAmmo(currentAudioGun);
			if(emptyStack) {
				switch (currentAudioGun) {
				case 1: 
					AudioSource.PlayClipAtPoint(pistolClips, transform.position);
					BulletMove ();
					break;
				case 2: 
					AudioSource.PlayClipAtPoint(automachineClips, transform.position);
					BulletMove ();
					break;
				case 3: 
					AudioSource.PlayClipAtPoint(bazookaClips, transform.position);
					BulletMove ();
					break;
				}
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
