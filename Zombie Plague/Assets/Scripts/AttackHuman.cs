using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackHuman : MonoBehaviour {

	GameObject board;
	Board boardClass;
	GameObject selectedPlayer;
	GameObject selectedZombie;
	GameObject selectedHuman;
	List<GameObject> zombies;
	List<GameObject> attackedHumans;
	GameObject[] players;

	void Start(){
		board = GameObject.FindWithTag ("GameBoard");
		boardClass = board.GetComponent<Board>();
	}

	void Update(){
		selectedPlayer = boardClass.selectedPlayer;
		selectedZombie = boardClass.selectedZombie;
		zombies = boardClass.zombies;
		players = boardClass.players;
		attackedHumans = boardClass.attackedHumans;
	}

	void OnMouseUp(){
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			if (selectedPlayer.GetComponent<Player> ().isZombiePlayer == true) {
				Debug.Log ("Human");
				SelectedHuman ();
				if (!ThisHumanWasAttacked ()) {
					AttackSelectedHuman ();
					attackedHumans.Add (selectedHuman);
				} else {
					Debug.Log ("This Human Was Attacked!!!");
				}
			}
		}
	}

	bool InAttackRadius(){
		if (Vector3.Distance (selectedZombie.transform.position, gameObject.transform.position) <= 1.8f) {
			return true;
		} 
		else {
			return false;
		}
	}

	bool ThisHumanWasAttacked(){
		bool thisHumanWasAttacked = false;
		for (int i = 0; i < attackedHumans.Count; i++) {
			if (selectedHuman == attackedHumans [i]) {
				thisHumanWasAttacked = true;
				break;
			} else {
				thisHumanWasAttacked = false;
			}
		}

		return thisHumanWasAttacked;
	}

	int CountZombies(){
		int countZombies = 0;

		for (int i = 0; i < zombies.Count; i++) {
			float distance = Vector3.Distance (gameObject.transform.position, zombies[i].transform.position);
			if (distance <= 1.8f) {
				countZombies++;
			}
		}

		return countZombies;
	}

	void SelectedHuman (){
		for (int i = 0; i < players.Length; i++) {
			if (players [i].name == gameObject.transform.parent.name) {
				selectedHuman = players [i];
				break;
			}
		}
	}

	void AttackSelectedHuman(){
		int chanceToAttack = Random.Range (1, 13);
		int countZombies = CountZombies ();

		if (InAttackRadius ()) {
			if (chanceToAttack >= (12 - countZombies)) {
				Debug.Log ("You attack human");
				selectedHuman.GetComponent<Player> ().currentHP -= 1;
			} else {
				Debug.Log ("Human was dodged");
			}
		} else {
			Debug.Log ("Human outside attack radius");
		}
	}
}
