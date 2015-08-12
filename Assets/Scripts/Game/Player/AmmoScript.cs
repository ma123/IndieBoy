using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoScript : MonoBehaviour {
	private static Text ammoText; // zobrazenie zostavajucich nabojov 
	private static int pistolAmmo = 0;
	private static int automachineAmmo = 0;
	private static int bazookaAmmo = 0;
	private static int actualAmmo = 0;

	// Use this for initialization
	void Start () {
		pistolAmmo = PlayerPrefs.GetInt ("pistolammo", 5);
		automachineAmmo = PlayerPrefs.GetInt ("automachineammo", 0);
		bazookaAmmo = PlayerPrefs.GetInt ("bazookaammo", 0);

		ammoText = gameObject.GetComponent<Text>();
		actualAmmo = pistolAmmo; // nastavenie ako default pistol
		ammoText.text = actualAmmo + "Left";
	}

	public static void AddAmmo(int currentGun) {
			pistolAmmo += 5;
			automachineAmmo += 5;
			bazookaAmmo += 3;
		ChangeWeapon (currentGun);
	}

	
	public static bool TakeAmmo(int currentGun) {
		if (actualAmmo > 0) {
			actualAmmo--;
				
			switch (currentGun) {
			case 0: 
				pistolAmmo = actualAmmo;
				break;
			case 1: 
				automachineAmmo = actualAmmo;
				break;
			case 2: 
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
		switch (currentGun) {
		case 0: 
			actualAmmo = pistolAmmo;
			break;
		case 1: 
			actualAmmo = automachineAmmo;
			break;
		case 2: 
			actualAmmo = bazookaAmmo;
			break;
		}
		ammoText.text = actualAmmo + "Left"; 
	}

	public static int GetPistolAmmo() {
		return pistolAmmo;
	}

	public static int GetAutomachineAmmo() {
		return automachineAmmo;
	}

	public static int GetBazookaAmmo() {
		return bazookaAmmo;
	}
}
