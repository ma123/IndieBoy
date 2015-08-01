using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreScript : MonoBehaviour {

	Text highScoreText;
	// Use this for initialization
	void Start () {
		highScoreText = gameObject.GetComponent<Text>();
		int highScore = PlayerPrefs.GetInt ("highscore", 0);
		highScoreText.text = "HighScore " + highScore;
	}
}
