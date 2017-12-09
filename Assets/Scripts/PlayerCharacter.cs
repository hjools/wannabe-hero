using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter {

	private int health;

	public PlayerCharacter() {
		health = 100;
	}

	public int subtractPlayerHealth(int x) {
		health = health - x;
		return health;
	}

	public int getPlayerHealth() {
		return health;
	}

}
