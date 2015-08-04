using UnityEngine;
using System.Collections;

public class EndLevelScript : MonoBehaviour {
	private bool isWin = false;
	public GameObject endLevelPanel;

	public void EndLevelReact () {
		print ("end level");
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
