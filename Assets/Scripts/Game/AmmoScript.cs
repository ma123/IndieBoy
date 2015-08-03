using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoScript : MonoBehaviour {
	private static Text ammoText; // zobrazenie zostavajucich nabojov 
	private static int pistolAmmo = 5;
	private static int automachineAmmo = 3;
	private static int bazookaAmmo = 2;
	private static int actualAmmo = 0;

	// Use this for initialization
	void Start () {
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
