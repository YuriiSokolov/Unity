using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour {
	public int countCarFuel = 0;
	public bool startedUp = false;
	public bool[] inCar;
	public bool leave = false;
	bool load = false;
	GameObject board;
	Board boardClass;
	GameObject[] players;
	List<GameObject> zombies;
	GameObject selectedPlayer;
	public GameObject endGamePanel;
	public GameObject buttonEnter;
	public GameObject buttonGetOff;
	public GameObject buttonToLeave;
	public Text whoWin;
	public Text result;
	Vector3[] carRadius;
	const int criticalZombieCount = 5;

	void Start(){
		board = GameObject.FindWithTag ("GameBoard");
		boardClass = board.GetComponent<Board>();
		carRadius = new [] { new Vector3 (2f, 0f, 4f), new Vector3 (2f, 0f, 3f), 
			new Vector3 (3f, 0f, 3f), new Vector3 (4f, 0f, 3f), new Vector3 (4f, 0f, 4f), new Vector3 (4f, 0f, 5f),
			new Vector3 (4f, 0f, 6f), new Vector3 (4f, 0f, 7f), new Vector3 (4f, 0f, 8f), new Vector3 (3f, 0f, 8f),
			new Vector3 (2f, 0f, 8f), new Vector3 (2f, 0f, 7f), new Vector3 (2f, 0f, 6f) };
	}

	void Update(){
		if (load == false) {
			players = boardClass.players;
		}
		if (load == false && players.Length > 0) {
			inCar = new bool[players.Length - 1];
			for (int i = 0; i < inCar.Length; i++) {
				inCar [i] = false;
			}
			load = true;
		}

		selectedPlayer = boardClass.selectedPlayer;
		zombies = boardClass.zombies;

		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;

		if (countCarFuel == 2 && ((posX == 4.0f && posZ == 6.0f) || (posX == 2.0f && posZ == 6.0f))
		    && PlayerInCar () == false && CriticalZombieCount () < criticalZombieCount) {
			buttonEnter.SetActive (true);
		} else {
			buttonEnter.SetActive (false);
		}

		if (PlayerInCar () == true && ((posX == 4.0f && posZ == 6.0f) || (posX == 2.0f && posZ == 6.0f))) {
			buttonGetOff.SetActive (true);
		} 
		else {
			buttonGetOff.SetActive (false);
		}

		if (startedUp == true && PlayerInCar () == true && CriticalZombieCount() < criticalZombieCount) {
			buttonToLeave.SetActive (true);
		}

		if (leave == true) {
			buttonToLeave.SetActive (false);
			endGamePanel.SetActive (true);
			buttonGetOff.SetActive (false);
			whoWin.text = "Humans";
			whoWin.color = Color.green;
			result.text = "Humans could\n leave";
			result.color = Color.green;
		} 
		else if (AllPlayersDied(players) == true) {
			endGamePanel.SetActive (true);
			whoWin.text = "Zombie";
			whoWin.color = Color.red;
			result.text = "All Humans\n are dead";
			result.color = Color.red;
		}
	}

	bool AllPlayersDied(GameObject[] players){
		int countDied = 0;
		for (int i = 0; i < players.Length; i++) {
			int playerHp = players [i].GetComponent<Player> ().currentHP;
			if (playerHp <= 1) {
				countDied++;
			} 
			else {
				continue;
			}
		}
		if (countDied == players.Length - 1) {
			return true;
		} 
		else {
			return false;
		}
	}

	//Проверка находится ли игрок в машине
	bool PlayerInCar(){
		GameObject[] players;
		players = boardClass.players;
		bool tempInCar = false;
		for (int i = 0; i < players.Length; i++) {
			if (selectedPlayer = players [i]) {
				tempInCar = inCar [i];
				break;
			}
		}
		if (tempInCar == true) {
			return true;
		} 
		else {
			return false;
		}
	}

	//Проверка количества зомби вокруг машины
	int CriticalZombieCount(){
		int criticalZombieCount = 0;
		for (int i = 0; i < zombies.Count; i++) {
			Vector3 zombiePos = zombies [i].transform.position;
			for (int j = 0; j < carRadius.Length; j++) {
				if (zombiePos == carRadius [j]) {
					criticalZombieCount++;
					break;
				}
			}
		}
		return criticalZombieCount;
	}
}
