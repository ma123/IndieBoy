using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoScript : MonoBehaviour {
	static Text ammoText;

	static int pistolAmmo = 5;
	static int automachineAmmo = 3;
    static int bazookaAmmo = 2;
	static int actualAmmo = 0;

	// Use this for initialization
	void Start () {
		ammoText = gameObject.GetComponent<Text>();
		actualAmmo = pistolAmmo; // nastavenie ako default pistol
		ammoText.text = actualAmmo + "Left";
	}

	public static void AddAmmo(int currentGun) {
		switch (currentGun) {
		case 1: 
			pistolAmmo++;
			break;
		case 2: 
			automachineAmmo++;
			break;
		case 3: 
			bazookaAmmo++;
			break;
		}
	}

	
	public static bool TakeAmmo(int currentGun) {
		if (actualAmmo > 0) {
			actualAmmo--;
			print(actualAmmo);
				
			switch (currentGun) {
			case 1: 
				pistolAmmo = actualAmmo;
				break;
			case 2: 
				automachineAmmo = actualAmmo;
				break;
			case 3: 
				bazookaAmmo = actualAmmo;
				break;
			}

			ammoText.text = actualAmmo + "Left";
			return true;
		} else {
			return false;
		}
	}

	public static void ChangeWeapon(int currentGun) {
		print (currentGun);
		switch (currentGun) {
		case 1: 
			actualAmmo = pistolAmmo;
			break;
		case 2: 
			actualAmmo = automachineAmmo;
			break;
		case 3: 
			actualAmmo = bazookaAmmo;
			break;
		}
		ammoText.text = actualAmmo + "Left"; 
	}
}
