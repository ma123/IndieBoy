﻿using UnityEngine;
using System.Collections;

public class MunitionScript : MonoBehaviour {
	public void React () {
		print ("destroy object munition");
		//Destroy(Instantiate (parts, transform.position, Quaternion.identity), 2); // po 2 sekundach sa znici particle system
		AmmoScript.AddAmmo (GunScript.currentAudioGun);
		Destroy (gameObject);
	}
}