using UnityEngine;
using System.Collections;

public class PlayerCollisionScript : MonoBehaviour {
	public static bool damageLock = true;
	private float waitTime = 2f;
	private float lastTime = 0f;

	public AudioClip ouchClips;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.CompareTag ("Enemy")) {
			GameObject enemy = coll.collider.gameObject;

			if (Time.time > waitTime + lastTime) {
				if(damageLock) {
					damageLock = false;
					AudioSource.PlayClipAtPoint(ouchClips, transform.position);
					enemy.SendMessage ("EnemyReact");
					damageLock = true;  
				}
				lastTime = Time.time;
			}
		}

		if (coll.collider.CompareTag ("Trampoline")) {
			GameObject trampoline = coll.collider.gameObject;
		     trampoline.SendMessage ("TrampolineReact");
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.GetComponent<Collider2D>().CompareTag("Coin")) {
			GameObject coin = coll.GetComponent<Collider2D>().gameObject;
			coin.SendMessage ("CoinReact");
		}

		if(coll.GetComponent<Collider2D>().CompareTag("Life")) {
			GameObject life = coll.GetComponent<Collider2D>().gameObject;
			life.SendMessage ("LifeReact");
		}

		if(coll.GetComponent<Collider2D>().CompareTag("Munition")) {
			GameObject munition = coll.GetComponent<Collider2D>().gameObject;
			munition.SendMessage ("MunitionReact");
		}

		if(coll.GetComponent<Collider2D>().CompareTag("Spike")) {
			GameObject munition = coll.GetComponent<Collider2D>().gameObject;
			munition.SendMessage ("SpikeReact");
		}

		if(coll.GetComponent<Collider2D>().CompareTag("EndLevel")) {
			GameObject endLevel = coll.GetComponent<Collider2D>().gameObject;
			endLevel.SendMessage ("EndLevelReact");
		}
	}
}
