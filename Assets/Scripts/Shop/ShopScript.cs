using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShopScript : MonoBehaviour {
	private GameObject gameObject;
	private int numberOfWeapons = 3;
	private int[] priceWeapon = {1000, 10000, 50000};
	private int[] priceAmmo = {200, 500, 1000};


	void Start() {
		for(int i = 1; i < numberOfWeapons; i++) { // prebehne pole ak su zbrane true ulozia sa do listu
			if(PlayerPrefs.GetInt("weapon" + i, 1) == 1) {
				gameObject = GameObject.Find("BuyBtn"+ i);
				gameObject.GetComponent<Button> ().interactable = false;
			} else {
				gameObject = GameObject.Find("SellBtn"+ i);
				gameObject.GetComponent<Button> ().interactable = false;
			}
		} 
	}

	public void BuyWeapon(int typeOfWeapon) {
		if (PlayerPrefs.GetInt ("money", 0) >= priceWeapon[typeOfWeapon]) {   // zisti ci mas dost penazi
			ScoreScript.RemoveScore (priceWeapon[typeOfWeapon]); //odobranie penazi
			PlayerPrefs.SetInt ("money", ScoreScript.GetMoney ()); // ulozenie zostatku penazi
			PlayerPrefs.SetInt ("weapon" + typeOfWeapon, 1); // ulozenie vlastnictva zbrane

			gameObject = GameObject.Find("BuyBtn"+ typeOfWeapon);
			gameObject.GetComponent<Button> ().interactable = false;
			gameObject = GameObject.Find ("SellBtn" + typeOfWeapon);
			gameObject.GetComponent<Button> ().interactable = true;   // vypnutie tlacitka
		} else {
			print ("nemas dost penazi bez makat biely cigan");
		}
	} 

	public void SellWeapon(int typeOfWeapon) {
		if (PlayerPrefs.GetInt("weapon" + typeOfWeapon, 1) == 1) {   // zisti ci vlastnis zbran
			ScoreScript.AddScore (priceWeapon[typeOfWeapon]); // pridanie penazi za zbran
			PlayerPrefs.SetInt ("money", ScoreScript.GetMoney ()); // ulozenie zostatku penazi
			PlayerPrefs.SetInt ("weapon" + typeOfWeapon, 0); // ulozenie vlastnictva zbrane
			
			gameObject = GameObject.Find ("SellBtn" + typeOfWeapon);
			gameObject.GetComponent<Button> ().interactable = false;
			gameObject = GameObject.Find("BuyBtn"+ typeOfWeapon);
			gameObject.GetComponent<Button> ().interactable = true;
		} else {
			print ("nemas taku zbran");
		}
	} 

	public void BuyAmmo(int typeOfWeapon) {
		if (PlayerPrefs.GetInt ("money", 0) >= priceAmmo[typeOfWeapon]) {   // zisti ci mas dost penazi
			ScoreScript.RemoveScore (priceAmmo[typeOfWeapon]); //odobranie penazi
			PlayerPrefs.SetInt ("money", ScoreScript.GetMoney ()); // ulozenie zostatku penazi


			PlayerPrefs.SetInt ("pistolammo", PlayerPrefs.GetInt ("pistolammo", 5) + 5); // ziska pocet nabojov a ulozi + 5 
			
			/*gameObject = GameObject.Find("BuyBtn"+ typeOfWeapon);
			gameObject.GetComponent<Button> ().interactable = false;
			gameObject = GameObject.Find ("SellBtn" + typeOfWeapon);
			gameObject.GetComponent<Button> ().interactable = true;   // vypnutie tlacitka*/
		} else {
			print ("nemas dost penazi na naboje bez makat biely cigan");
		}
	} 

	public void SellAmmo(int typeOfWeapon) {
		
	} 
}
