using UnityEngine;
using System.Collections;

public class PlayerCollisionScript : MonoBehaviour {
	//public Color fullColor;
	//public Color deadColor;
	//SpriteRenderer spriteRenderer;
	public static bool damageLock = true;

	void Start() {
		//spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.CompareTag ("Enemy")) {
			//damageLock = false;
			GameObject enemy = coll.collider.gameObject;
			/*Color c = new Color ();

				
			float fr = Mathf.Abs (fullColor.r - deadColor.r);
			fr /= 100;
			c.r = deadColor.r + (fr * currentHealth);

			float fg = Mathf.Abs (fullColor.g - deadColor.g);
			fg /= 100;
			c.g = deadColor.g + (fg * currentHealth);

			float fb = Mathf.Abs (fullColor.b - deadColor.b);
			fb /= 100;
			c.b = deadColor.b + (fb * currentHealth);

			c.a = 1;
			spriteRenderer.color = c;*/

			enemy.SendMessage ("React");
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.GetComponent<Collider2D>().CompareTag("Coin")) {
			GameObject coin = coll.GetComponent<Collider2D>().gameObject;
			coin.SendMessage ("React");
		}

		if(coll.GetComponent<Collider2D>().CompareTag("Life")) {
			GameObject life = coll.GetComponent<Collider2D>().gameObject;
			life.SendMessage ("React");
		}

		if(coll.GetComponent<Collider2D>().CompareTag("Munition")) {
			GameObject munition = coll.GetComponent<Collider2D>().gameObject;
			munition.SendMessage ("React");
		}
	}
}
