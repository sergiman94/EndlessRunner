using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

	public bool doublePoints;
	public bool safeMode;

	public float powerupLength;

	private PowerupManager thePowerupManager;

	// Use this for initialization
	void Start () {

		thePowerupManager = FindObjectOfType<PowerupManager> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D other){
	
		if (other.name == "Player"){	

			thePowerupManager.ActivatePowerUp ( doublePoints, safeMode, powerupLength);
		}

		gameObject.SetActive (false);
	}

}
