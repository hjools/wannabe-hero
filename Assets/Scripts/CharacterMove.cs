using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMove : MonoBehaviour {

	public Canvas combatHUD;
	public Canvas levelHUD;

	private Animator anim;
	private NavMeshAgent agent;
	private Transform targetedEnemy;
	private bool walking;
	private bool enemyClicked;

	private UnityEngine.EventSystems.EventSystem eSystem;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		eSystem = GameObject.Find ("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !eSystem.IsPointerOverGameObject () && !combatHUD.isActiveAndEnabled) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100)) {
				agent.destination = hit.point;
//				walking = true;
			} 
		}else { 
//			walking = false;
		}
//		anim.SetBool ("move", walking);
	}

}
