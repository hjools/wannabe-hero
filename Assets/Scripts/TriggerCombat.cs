using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCombat : MonoBehaviour {

	public GameObject gameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			Debug.Log ("You entered my space!");
			GetComponent<Animator> ().SetTrigger ("combatTrig");
			gameManager.GetComponent<GameMachine> ().startCombat (transform.gameObject);
		}
	}
}
