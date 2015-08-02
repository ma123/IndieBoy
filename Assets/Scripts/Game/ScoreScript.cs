using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	static int money = 0;
	static bool change = false;
	Text moneyText;

	void Start() {
		money = 0;
		moneyText = gameObject.GetComponent<Text>();
	}

	void Update() {
		if(change) {
			change = false;
			moneyText.text = money + " €";
		}
	}

	/*void OnDestroy() {
		int highScore = PlayerPrefs.GetInt ("highscore", 0);

		if(score > highScore) {
			PlayerPrefs.SetInt ("savescore", score);
		}

		//PlayerPrefs.DeleteAll ();
	}*/

	public static void AddScore(int gains) {
		money += gains;
		change = true;
	}
}
