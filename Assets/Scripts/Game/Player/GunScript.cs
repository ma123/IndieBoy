using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunScript : MonoBehaviour {
	public GameObject[] gunsObject;
	public Rigidbody2D[] gunsRigidBody;
	private Rigidbody2D currentWeaponRigidBody;

	public int nextChangeGun = 0;
	public static int currentGun = 0;
	public float speed = 18f;				// rychlost projektilu
	private float fireRate = 0f;
	private float lastShoot = 0f;
	private int numberOfWeapons = 3;  // pocet vsetkych zbrani 
	private float[] gunsFireRate = {0.4f, 0.2f, 0.9f};  // nastavenie rychlosti strelby zbrani
	private List<int> weaponsList = new List<int>();

	public AudioClip[] gunsClips;

	private PlayerControllerScript playerCtrl;		// Reference to the PlayerControl script.
	
	void Awake() {
		playerCtrl = transform.root.GetComponent<PlayerControllerScript>();
	}

	void Start() {
		for(int i = 0; i < numberOfWeapons; i++) { // prebehne pole ak su zbrane true ulozia sa do listu
			if(PlayerPrefs.GetInt("weapon" + i, 1) == 1) {
				weaponsList.Add(i);
			}
		} 

		SetActiveWeapons (weaponsList[0]);

		if(weaponsList.Count > 1) {
			nextChangeGun = weaponsList [currentGun + 1];
		}
	}

	// zmeni zbran za nasledujucu 
	public void ChangeWeapon() {
		if (weaponsList.Count > 1) {
			SetActiveWeapons (nextChangeGun);
			if (nextChangeGun == weaponsList [weaponsList.Count - 1]) {
				nextChangeGun = weaponsList [0];
			} else {
				nextChangeGun = weaponsList [nextChangeGun + 1];
			}
			
			AmmoScript.ChangeWeapon (currentGun);
		} else {
			print ("mas iba pistol");
		}
	}

	// zobrazi aktualnu zbran
	private void SetActiveWeapons(int weapon) {
		foreach(int w in weaponsList) {
			print ("weapon " + w);
			if(w == weapon) {
				gunsObject[w].SetActive(true);
				currentGun = weapon;
				currentWeaponRigidBody = gunsRigidBody[currentGun];
			} else {
				gunsObject[w].SetActive(false);
			}
		}
	}

	public void Shoot() {  
		if (Time.time > fireRate + lastShoot) {
			bool emptyStack = AmmoScript.TakeAmmo(currentGun);  // zistenie ci zasobnik nie je prazdny
			if(emptyStack) {
				fireRate = gunsFireRate[currentGun]; // vyber firerate 
				AudioSource.PlayClipAtPoint(gunsClips[currentGun], transform.position); // vyber zvuku
				BulletMove ();
			} 
			lastShoot = Time.time;
		}
	}

	private void BulletMove() {
		if(playerCtrl.facingRight) {
			Rigidbody2D bulletInstance = Instantiate(currentWeaponRigidBody, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(speed, 0);
		}
		else {
			Rigidbody2D bulletInstance = Instantiate(currentWeaponRigidBody, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(-speed, 0);
		}
	}
}
