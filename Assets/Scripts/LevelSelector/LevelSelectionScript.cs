using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class LevelSelectionScript : MonoBehaviour {
	private int openedLevel = 1;	
	private int numberOfLevels = 6;
	private int numberOfWeapons = 3;
	private GameObject gameObject;

	void Start() {
		openedLevel = PlayerPrefs.GetInt ("openedLevel", 1);

		// vypnutie interakcie levelov ktore nie su pristupne
		for(int i = openedLevel+1; i <= numberOfLevels; i++) {
			gameObject = GameObject.Find("Lvl"+i+"Btn");
			gameObject.GetComponent<Button>().interactable = false;
		}

		if(openedLevel == 1) {
			PlayerPrefs.SetInt("weapon" + 0, 1);
			for(int i= 1; i < numberOfWeapons; i++) {
				PlayerPrefs.SetInt("weapon" + i, 0);
			}
		}

		//PlayerPrefs.DeleteAll ();
	}

	public void OnClickedLevel(int currentLevel) {
		PlayerPrefs.SetInt("currentLevel", currentLevel);
		Application.LoadLevel ("Level" + currentLevel);
	}

	public void OnClickShop() {
		Application.LoadLevel ("Shop");
	}
}
