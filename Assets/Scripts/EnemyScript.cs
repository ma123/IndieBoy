using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public GameObject parts;

    public void React () {
		print ("destroy object");
		//Destroy(Instantiate (parts, transform.position, Quaternion.identity), 2); // po 2 sekundach sa znici particle system

		Destroy (gameObject);
		//Destroy (gameObject, 1); // druhy parameter urcuje cas vykonania
	}
}
