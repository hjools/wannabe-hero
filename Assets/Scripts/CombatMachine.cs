using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMachine : MonoBehaviour {

	public Button attackButton;
	public Button escapeButton;
	public Canvas combatHUD;

	public AudioClip attackSound;
	public AudioClip demiseSound;
	private AudioSource soundSource;

	public enum BattleStates {
		START,
		PLAYERCHOICE,
		ENEMYCHOICE,
		LOSE,
		WIN
	}

	public bool startBattle = false;
	PlayerCharacter player;
	GameObject playerChar;
	public GameObject enemy;
	private BattleStates currentState;
	public GameMachine gMachine;
	bool battleWon;

	// Use this for initialization
	void Start () {
		currentState = BattleStates.START;
		gMachine = GetComponent<GameMachine> ();
		player = gMachine.player;
		playerChar = GameObject.FindGameObjectWithTag ("Player");
		soundSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		while (!startBattle) {
			return;
		}
		switch (currentState) {
		case(BattleStates.START):
			combatHUD.gameObject.SetActive (true);
			attackButton.onClick.AddListener (attack);
			escapeButton.onClick.AddListener (escape);
			attackButton.interactable = true;
			escapeButton.interactable = true;
			currentState = BattleStates.PLAYERCHOICE;
			break;
		case(BattleStates.PLAYERCHOICE):
			attackButton.interactable = true;
			escapeButton.interactable = true;
			break;
		case(BattleStates.ENEMYCHOICE):
			player.subtractPlayerHealth (Random.Range (1, 10));
			currentState = BattleStates.PLAYERCHOICE;
			break;
		case(BattleStates.LOSE):
			battleWon = false;
//			endBattle (battleWon);
			StartCoroutine(endBattle(battleWon));
			break;
		case(BattleStates.WIN):
			battleWon = true;
//			endBattle (battleWon);
			StartCoroutine(endBattle(battleWon));
			break;
		}
	}

	void attack() {
		// attack enemy

		// move to next state
//		currentState = BattleStates.ENEMYCHOICE;
		// disable combat option buttons
//		attackButton.interactable = false;
//		escapeButton.interactable = false;
		playerChar.GetComponent<Animator>().Play("Jab");
		StartCoroutine (playAttackSound ());
		currentState = BattleStates.WIN;
	}
	void escape() {
		currentState = BattleStates.LOSE;
		// disable combat option buttons
		attackButton.interactable = false;
		escapeButton.interactable = false;
	}
//	void endBattle(bool result) {
//		combatHUD.gameObject.SetActive (false);
//		if (currentState == BattleStates.WIN) {
//			DestroyObject (enemy);
//			gMachine.updateQuest ();
//		}
//		startBattle = false;
//		currentState = BattleStates.START;
//		gMachine.endCombat ();
//	}

	// so we can wait for attack animation to finish
	IEnumerator endBattle(bool result) {
		yield return new WaitForSeconds (2);
		combatHUD.gameObject.SetActive (false);
		if (currentState == BattleStates.WIN) {
			soundSource.PlayOneShot (demiseSound);
			DestroyObject (enemy);
			gMachine.updateQuest ();
		}
		startBattle = false;
		currentState = BattleStates.START;
		gMachine.endCombat ();
	}

	IEnumerator playAttackSound() {
		yield return new WaitForSeconds (0.5f);
		soundSource.PlayOneShot (attackSound);
	}

}
