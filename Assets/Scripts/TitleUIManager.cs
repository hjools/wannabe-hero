using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUIManager : MonoBehaviour {

	public Button button_startGame; 

	public AudioClip sound_buttonSelect;
	private AudioSource soundSource;

	// Use this for initialization
	void Start () {
		soundSource = GetComponent<AudioSource> ();
		button_startGame.onClick.AddListener (startGame);
		Debug.Log ("Button instantiated");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void startGame() {
		Debug.Log ("Button clicked!");
		soundSource.PlayOneShot (sound_buttonSelect);
		SceneManager.LoadScene ("tutorial");
	}
}
