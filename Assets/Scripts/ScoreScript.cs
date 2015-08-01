using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	static int score = 0;
	static bool change = false;
	Text scoreText;

	void Start() {
		score = 0;
		scoreText = gameObject.GetComponent<Text>();
	}

	void Update() {
		if(change) {
			change = false;
			scoreText.text = "Score " + score;
		}
	}

	void OnDestroy() {
		int highScore = PlayerPrefs.GetInt ("highscore", 0);

		if(score > highScore) {
			PlayerPrefs.SetInt ("highscore", score);
		}

		//PlayerPrefs.DeleteAll ();
	}

	public static void AddScore() {
		score++;
		change = true;
	}
}
