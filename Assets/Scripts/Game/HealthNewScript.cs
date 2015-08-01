using UnityEngine;
using System.Collections;

public class HealthNewScript : MonoBehaviour {
	int health = 100;
	float initSize;
	bool isDead = false;
	public GameObject endPanel;
	
	// Use this for initialization
	void Start () {
		initSize = transform.localScale.x;  // zisti pociatocnu velkost health baru
		RefreshHealthBar ();
		health = 100;
	}
	
	public int Hit(int damage) {
		if(isDead) {
			return 0;
		}
		
		health -= damage;
		
		if(health <= 0) {
			health = 0;
			isDead = true;
		}
		
		RefreshHealthBar ();

		return health;
	}

	void OnGUI() {
		if (isDead) {
			Time.timeScale = 0; // pauznutie hry
			endPanel.SetActive(true);
		} 
	}
	
	void RefreshHealthBar() {
		Vector3 scale = transform.localScale;
		scale.x = (initSize / 100) * health;
		transform.localScale = scale;
	}
}
