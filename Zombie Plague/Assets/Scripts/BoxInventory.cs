using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxInventory : MonoBehaviour {
	public Thing thing;

	GameObject board;
	Board boardClass;
	List<Thing> playerInventory;
	GameObject selectedPlayer;
	public Image[] slots;
	public bool[] isFull;
	int currentInventoryWeight;
	int maxInventoryWeight;
	float posX;
	float posZ;

	void Start(){
		board = GameObject.FindWithTag ("GameBoard");
		boardClass = board.GetComponent<Board>();
		slots = boardClass.slots;
	}

	void Update(){
		playerInventory = boardClass.selectedPlayer.GetComponent <Player> ().inventory;
		selectedPlayer = boardClass.selectedPlayer;
		posX = selectedPlayer.GetComponent<Player> ().positionV;
		posZ = selectedPlayer.GetComponent<Player> ().positionH;
		currentInventoryWeight = selectedPlayer.GetComponent<Player> ().currentInventoryWeight;
		maxInventoryWeight = selectedPlayer.GetComponent<Player> ().maxInventoryWeight;
		isFull = selectedPlayer.GetComponent<Inventory> ().isFull;
		if (posX == gameObject.transform.position.x && posZ == gameObject.transform.position.z) {
			TakeThing ();
		}
	}

	void TakeThing(){
		Debug.Log ("In Trigger");
		Thing thing = gameObject.GetComponent<BoxInventory> ().thing;
		if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
			if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
				playerInventory.Add (thing);
				AddThingToSlot (thing, slots, isFull);
				currentInventoryWeight = currentInventoryWeight + thing.weight;
				selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
				Destroy (gameObject);
			} else {
				Debug.Log ("This thing is too heavy for you.");
			}
		} else {
			Debug.Log ("You inventory is full.");
		}
	}

	void AddThingToSlot (Thing thing, Image[] slots, bool[] isFull){
		for (int i = 0; i < slots.Length; i++) {
			if (isFull [i] != true) {
				isFull [i] = true;
				Instantiate (thing.thingPrefab, slots [i].transform, false);
				break;
			}
		}
	}
}
