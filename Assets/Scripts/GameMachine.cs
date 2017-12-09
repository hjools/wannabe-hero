using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMachine : MonoBehaviour {

	public Canvas regularHUD;
	public Canvas levelHUD;
	public Canvas locHUD;

	public PlayerCharacter player;
	public GameObject playerChar;
	public bool inCombat;
	public int questProgress = 0;

	// Use this for initialization
	void Start () {
		// this class manages the entire game. (this level)
		DontDestroyOnLoad (transform.gameObject);
		player = new PlayerCharacter ();
		inCombat = false;
		StartCoroutine (introText ());
	}
	
	// Update is called once per frame
	void Update () {
		if (questProgress == 2) {
			// CELEBRATE!!!
			regularHUD.enabled = false;
			levelHUD.enabled = true;
			levelHUD.GetComponent<Animator> ().SetTrigger ("endLevel");
			playerChar.GetComponent<Animator> ().SetBool ("dancing", true);
		}
	}

	public void startCombat(GameObject enemy) {
		inCombat = true;
		CombatMachine cMachine = GetComponent<CombatMachine> ();
		cMachine.startBattle = true;
		cMachine.enemy = enemy;
	}
	public void endCombat() {
		inCombat = false;
	}

	public void updateQuest() {
		questProgress += 1;
		GetComponent<UIManager> ().updateQuest (questProgress);
	}

	IEnumerator introText() {
		yield return new WaitForSeconds (5);
		locHUD.GetComponent<CanvasGroup> ().alpha = 0;
		StartCoroutine (showHelp ());
	}

	// hide help after 5 seconds
	IEnumerator showHelp() {
		GameObject.Find ("HelpUI").GetComponent<CanvasGroup> ().alpha = 1;
		yield return new WaitForSeconds (5);
		GameObject.Find ("HelpUI").GetComponent<CanvasGroup> ().alpha = 0;
	}
}
