using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	public void WeaponReact () {
		print ("destroy object weapon");
        
		Destroy (gameObject);
	}
}
