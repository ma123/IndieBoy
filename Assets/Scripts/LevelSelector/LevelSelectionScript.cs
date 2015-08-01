using UnityEngine;
using System.Collections;

public class LevelSelectionScript : MonoBehaviour {

	public void OnClickedLevel() {
		Application.LoadLevel ("Level1");
	}
}
