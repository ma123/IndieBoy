using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	int health = 100;
	float initSize;
	bool isDead = false;
	public GameObject panel;

	// Use this for initialization
	void Start () {
		initSize = transform.localScale.x;  // zisti pociatocnu velkost health baru
		RefreshHealthBar ();
		health = 100;
	}

	public int Hit(int damage) {
		if(isDead)
			return 0;

		health -= damage;

		if(health <= 0) {
			health = 0;
			Die ();
		}

		RefreshHealthBar ();
		return health;
	}

	public void Die() {
		isDead = true;
	}

	void OnGUI() {
		if (isDead) {
			Time.timeScale = 0; // pauznutie hry
			panel.SetActive(true);
		} 
	}

	void RefreshHealthBar() {
		transform.GetChild(0).GetComponent<GUIText>().text = health + "%";
		Vector3 scale = transform.localScale;
		scale.x = (initSize / 100) * health;
		transform.localScale = scale;
	}
}
