using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public int playerHealth = 100;
	public Slider healthSlider;
	UnityEngine.UI.Text questText;

	// Use this for initialization
	void Start () {
		GameObject t = GameObject.Find ("QuestText");
		questText = t.GetComponent<UnityEngine.UI.Text> ();
		playerHealth = GetComponent<GameMachine>().player.getPlayerHealth ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateQuest(int x) {
		questText.text = "Kill 2 slimes. (" + x + "/2)";
	}

	public void updateHealth(int x) {
		healthSlider.value = x;
	}
}
