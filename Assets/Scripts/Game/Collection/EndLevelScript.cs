﻿using UnityEngine;
using System.Collections;

public class EndLevelScript : MonoBehaviour {
	private bool isWin = false;
	private int openedLevel = 0;
	private int currentLevel = 0;
	public GameObject endLevelPanel;

	public void EndLevelReact () {
		print ("end level");
		PlayerPrefs.SetInt ("money", ScoreScript.GetMoney());
		PlayerPrefs.SetInt ("pistolammo", AmmoScript.GetPistolAmmo());
		PlayerPrefs.SetInt ("automachineammmo", AmmoScript.GetAutomachineAmmo());
		PlayerPrefs.SetInt ("bazookaammo", AmmoScript.GetBazookaAmmo());


		openedLevel = PlayerPrefs.GetInt ("openedLevel", 1);
		currentLevel = PlayerPrefs.GetInt ("currentLevel");

		if(currentLevel == openedLevel) {
			openedLevel++;
			PlayerPrefs.SetInt("openedLevel", openedLevel);
			openedLevel = PlayerPrefs.GetInt ("openedLevel");
		}
		
		isWin = true;
	}

	void OnGUI() {
		if (isWin) {
			Time.timeScale = 0; // pauznutie hry
			endLevelPanel.SetActive(true);
			isWin = false;
		} 
	}
}
