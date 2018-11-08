using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsingInventory : MonoBehaviour {

	public GameObject selectedPlayer;
	public Image[] slots;
	GameObject board;
	Board boardClass;
	GameEnd gameEndClass;

	void Start(){
		board = GameObject.FindWithTag ("GameBoard");
		boardClass = board.GetComponent<Board> ();
		gameEndClass = board.GetComponent<GameEnd> ();
		slots = boardClass.slots;
	}

	void Update(){
		selectedPlayer = boardClass.selectedPlayer;
	}

	public void AidKitBtn(){
		int number = Random.Range (0, 13);
		if (selectedPlayer.GetComponent<Player> ().moves >= 3) {
			if (number <= 5) {
				for (int i = 0; i < slots.Length; i++) {
					if (slots [i].transform == transform.parent) {
						selectedPlayer.GetComponent<Inventory> ().isFull [i] = false;
						for (int j = 0; j < selectedPlayer.GetComponent<Player> ().inventory.Count; j++) {
							string goName = selectedPlayer.GetComponent<Player> ().inventory [j].thingPrefab.name + "(Clone)";
							if (gameObject.name == goName) {
								selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
									selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
								selectedPlayer.GetComponent<Player> ().inventory.RemoveAt (j);
								break;
							}
						}
						Destroy (gameObject);
					}
				}
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
				Debug.Log ("You lost your thing");
			} 
			else if (number == 6) {
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 3;
				Debug.Log ("Oops, you lost 3 moves");
			} 
			else if (number == 7) {
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
				Debug.Log ("Nothing has happened");
			} 
			else if (number >= 8 && selectedPlayer.GetComponent<Player> ().currentHP < 4) {
				selectedPlayer.GetComponent<Player> ().currentHP = selectedPlayer.GetComponent<Player> ().currentHP + 1;
				Debug.Log ("You restored 1 heart");
			} 
			else {
				Debug.Log ("Nothing has happened");
			}
			Debug.Log ("Using Thing");
		} else {
			Debug.Log ("You don't have 3 moves.");
		}
	}

	public void ButtonAmmo(){
		for (int i = 0; i < slots.Length; i++) {
			if (slots [i].transform == transform.parent) {
				selectedPlayer.GetComponent<Inventory> ().isFull [i] = false;
				for (int j = 0; j < selectedPlayer.GetComponent<Player> ().inventory.Count; j++) {
					string goName = selectedPlayer.GetComponent<Player> ().inventory [j].thingPrefab.name + "(Clone)";
					if (gameObject.name == goName) {
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
							selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
						selectedPlayer.GetComponent<Player> ().inventory.RemoveAt (j);
						break;
					}
				}
				Destroy (gameObject);
			}
		}
		selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
		Debug.Log ("Using Thing");
	}

	public void ButtonBint(){
		if (selectedPlayer.GetComponent<Player> ().moves >= 2) {
			for (int i = 0; i < slots.Length; i++) {
				if (slots [i].transform == transform.parent) {
					selectedPlayer.GetComponent<Inventory> ().isFull [i] = false;
					for (int j = 0; j < selectedPlayer.GetComponent<Player> ().inventory.Count; j++) {
						string goName = selectedPlayer.GetComponent<Player> ().inventory [j].thingPrefab.name + "(Clone)";
						if (gameObject.name == goName) {
							selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
								selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
							selectedPlayer.GetComponent<Player> ().inventory.RemoveAt (j);
							break;
						}
					}
					Destroy (gameObject);
				}
			}
			selectedPlayer.GetComponent<Player> ().currentHP = Mathf.Clamp (selectedPlayer.GetComponent<Player> ().currentHP + 2, 1, 5);
			Debug.Log ("You restored 2 heart");
			selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
			Debug.Log ("Using Thing");
		}
	}

	public void ButtonCarKey(){
		int number = Random.Range (0, 13);
		if (selectedPlayer.GetComponent<Player> ().moves >= 1 && PlayerInCar() == true) {
			if (number >= 10) {
				for (int i = 0; i < slots.Length; i++) {
					if (slots [i].transform == transform.parent) {
						selectedPlayer.GetComponent<Inventory> ().isFull [i] = false;
						for (int j = 0; j < selectedPlayer.GetComponent<Player> ().inventory.Count; j++) {
							string goName = selectedPlayer.GetComponent<Player> ().inventory [j].thingPrefab.name + "(Clone)";
							if (gameObject.name == goName) {
								selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
									selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
								selectedPlayer.GetComponent<Player> ().inventory.RemoveAt (j);
								break;
							}
						}
						Destroy (gameObject);
					}
				}
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
				gameEndClass.startedUp = true;
				Debug.Log ("Using Thing");
			} 
			else {
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
				Debug.Log ("The car didn't start");
			}
		}
	}

	public void ButtonFuel(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH; 
		if (selectedPlayer.GetComponent<Player> ().moves >= 2 && (posX == 4.0f && posZ == 4.0f)) {
			for (int i = 0; i < slots.Length; i++) {
				if (slots [i].transform == transform.parent) {
					selectedPlayer.GetComponent<Inventory> ().isFull [i] = false;
					for (int j = 0; j < selectedPlayer.GetComponent<Player> ().inventory.Count; j++) {
						string goName = selectedPlayer.GetComponent<Player> ().inventory [j].thingPrefab.name + "(Clone)";
						if (gameObject.name == goName) {
							selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
								selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
							selectedPlayer.GetComponent<Player> ().inventory.RemoveAt (j);
							break;
						}
					}
					Destroy (gameObject);
				}
			}
			selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
			gameEndClass.countCarFuel = gameEndClass.countCarFuel + 1;
			Debug.Log ("Using Thing");
		}
	}

	public void ButtonMorphine(){
		for (int i = 0; i < slots.Length; i++) {
			if (slots [i].transform == transform.parent) {
				selectedPlayer.GetComponent<Inventory> ().isFull [i] = false;
				for (int j = 0; j < selectedPlayer.GetComponent<Player> ().inventory.Count; j++) {
					string goName = selectedPlayer.GetComponent<Player> ().inventory [j].thingPrefab.name + "(Clone)";
					if (gameObject.name == goName) {
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
							selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
						selectedPlayer.GetComponent<Player> ().inventory.RemoveAt (j);
						break;
					}
				}
				Destroy (gameObject);
			}
		}
		selectedPlayer.GetComponent<Player> ().usingDrugs = true;
		Debug.Log ("Using Thing");
	}

	public void ButtonPerekis(){
		if (selectedPlayer.GetComponent<Player> ().moves >= 1) {
			for (int i = 0; i < slots.Length; i++) {
				if (slots [i].transform == transform.parent) {
					selectedPlayer.GetComponent<Inventory> ().isFull [i] = false;
					for (int j = 0; j < selectedPlayer.GetComponent<Player> ().inventory.Count; j++) {
						string goName = selectedPlayer.GetComponent<Player> ().inventory [j].thingPrefab.name + "(Clone)";
						if (gameObject.name == goName) {
							selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
								selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
							selectedPlayer.GetComponent<Player> ().inventory.RemoveAt (j);
							break;
						}
					}
					Destroy (gameObject);
				}
			}
			selectedPlayer.GetComponent<Player> ().currentHP = Mathf.Clamp (selectedPlayer.GetComponent<Player> ().currentHP + 1, 1, 5);
			Debug.Log ("You restored 1 heart");
			selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			Debug.Log ("Using Thing");
		}
	}

	public void ButtonRedBull(){
		if (selectedPlayer.GetComponent<Player> ().moves >= 1) {
			for (int i = 0; i < slots.Length; i++) {
				if (slots [i].transform == transform.parent) {
					selectedPlayer.GetComponent<Inventory> ().isFull [i] = false;
					for (int j = 0; j < selectedPlayer.GetComponent<Player> ().inventory.Count; j++) {
						string goName = selectedPlayer.GetComponent<Player> ().inventory [j].thingPrefab.name + "(Clone)";
						if (gameObject.name == goName) {
							selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
								selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
							selectedPlayer.GetComponent<Player> ().inventory.RemoveAt (j);
							break;
						}
					}
					Destroy (gameObject);
				}
			}
			selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves + 5;
			Debug.Log ("You added 5 moves");
			Debug.Log ("Using Thing");
		}
	}

	public void ButtonSnickers(){
		for (int i = 0; i < slots.Length; i++) {
			if (slots [i].transform == transform.parent) {
				selectedPlayer.GetComponent<Inventory> ().isFull [i] = false;
				for (int j = 0; j < selectedPlayer.GetComponent<Player> ().inventory.Count; j++) {
					string goName = selectedPlayer.GetComponent<Player> ().inventory [j].thingPrefab.name + "(Clone)";
					if (gameObject.name == goName) {
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
							selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
						selectedPlayer.GetComponent<Player> ().inventory.RemoveAt (j);
						break;
					}
				}
				Destroy (gameObject);
			}
		}
		selectedPlayer.GetComponent<Player> ().maxMoves = selectedPlayer.GetComponent<Player> ().maxMoves + 1;
		Debug.Log ("You added 1 moves to your maximum moves");
		Debug.Log ("Using Thing");
	}

	public void ButtonVodka(){
		if (selectedPlayer.GetComponent<Player> ().moves >= 1) {
			for (int i = 0; i < slots.Length; i++) {
				if (slots [i].transform == transform.parent) {
					selectedPlayer.GetComponent<Inventory> ().isFull [i] = false;
					for (int j = 0; j < selectedPlayer.GetComponent<Player> ().inventory.Count; j++) {
						string goName = selectedPlayer.GetComponent<Player> ().inventory [j].thingPrefab.name + "(Clone)";
						if (gameObject.name == goName) {
							selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
								selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
							selectedPlayer.GetComponent<Player> ().inventory.RemoveAt (j);
							break;
						}
					}
					Destroy (gameObject);
				}
			}
			selectedPlayer.GetComponent<Player> ().currentHP = Mathf.Clamp (selectedPlayer.GetComponent<Player> ().currentHP + 1, 1, 5);
			Debug.Log ("You restored 1 heart");
			selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			Debug.Log ("Using Thing");
		}
	}

	public void ButtonKnife(){
		selectedPlayer.GetComponent<Player> ().weaponType = 1;
		Debug.Log ("Using Knife");
	}

	public void ButtonAxe(){
		selectedPlayer.GetComponent<Player> ().weaponType = 2;
		Debug.Log ("Using Axe");
	}

	public void ButtonBat(){
		selectedPlayer.GetComponent<Player> ().weaponType = 3;
		Debug.Log ("Using Bat");
	}

	public void ButtonGlock(){
		selectedPlayer.GetComponent<Player> ().weaponType = 4;
		Debug.Log ("Using Glock");
	}

	public void ButtonAK47(){
		selectedPlayer.GetComponent<Player> ().weaponType = 5;
		Debug.Log ("Using AK-47");
	}

	public void ButtonShotgun(){
		selectedPlayer.GetComponent<Player> ().weaponType = 6;
		Debug.Log ("Using Shotgun");
	}

	public void ButtonRifle(){
		selectedPlayer.GetComponent<Player> ().weaponType = 7;
		Debug.Log ("Using Rifle");
	}

	//Проверка находится ли игрок в машине
	bool PlayerInCar(){
		GameObject[] players;
		players = boardClass.players;
		bool inCar = false;
		for (int i = 0; i < players.Length; i++) {
			if (selectedPlayer = players [i]) {
				inCar = gameEndClass.inCar [i];
				break;
			}
		}
		if (inCar == true) {
			return true;
		} 
		else {
			return false;
		}
	}
}
