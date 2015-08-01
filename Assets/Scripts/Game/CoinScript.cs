using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
	public void React () {
		print ("destroy object coin");
		//Destroy(Instantiate (parts, transform.position, Quaternion.identity), 2); // po 2 sekundach sa znici particle system
		
		Destroy (gameObject);
	}
}
