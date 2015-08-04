using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class LevelSelectionScript : MonoBehaviour {
	private int openedLevel = 1;	
	public GameObject gameObject;

	void Start() {
		gameObject.GetComponent<Button>().interactable = false;
	}

	public void OnClickedLevel(int numberOfLevel) {
		Application.LoadLevel ("Level" + numberOfLevel);
	}
}
