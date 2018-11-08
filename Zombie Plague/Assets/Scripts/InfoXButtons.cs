using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoXButtons : MonoBehaviour {

	GameObject board;
	Board boardClass;
	Inventory playerInventory;
	List<Thing> playerThings;
	GameObject selectedPlayer;

	public GameObject infoPanel;
	public Text weight;
	public Text thingName;
	public Text descriptionText;
	public Text movesCount;
	public bool[] isFull;
	public Image[] slots;
	public GameObject inventoryBox;

	void Start(){
		board = GameObject.FindWithTag ("GameBoard");
		boardClass = board.GetComponent<Board>();
	}

	void Update(){
		playerInventory = boardClass.selectedPlayer.GetComponent<Inventory> ();
		playerThings = boardClass.selectedPlayer.GetComponent<Player> ().inventory;
		isFull = playerInventory.isFull;
		selectedPlayer = boardClass.selectedPlayer;
	}

	public void Info0(){
		if (isFull [0] == true) {
			infoPanel.SetActive (true);
			Transform child = slots [0].transform.GetChild (2);

			for (int i = 0; i < playerThings.Count; i++) {
				string goName = playerThings [i].thingPrefab.name + "(Clone)";

				if (child.name == goName) {
					Debug.Log ("true");
					Thing thing = playerThings [i];
					weight.text = thing.weight.ToString ();
					thingName.text = thing.name;
					descriptionText.text = thing.description;
					movesCount.text = thing.movesCost.ToString ();
				}	
			}				
		}
	}

	public void Info1(){
		if (isFull [1] == true) {
			infoPanel.SetActive (true);
			Transform child = slots [1].transform.GetChild (2);

			for (int i = 0; i < playerThings.Count; i++) {
				string goName = playerThings [i].thingPrefab.name + "(Clone)";

				if (child.name == goName) {
					Debug.Log ("true");
					Thing thing = playerThings [i];
					weight.text = thing.weight.ToString ();
					thingName.text = thing.name;
					descriptionText.text = thing.description;
					movesCount.text = thing.movesCost.ToString ();
				}	
			}	
		}
	}

	public void Info2(){
		if (isFull [2] == true) {
			infoPanel.SetActive (true);
			Transform child = slots [2].transform.GetChild (2);

			for (int i = 0; i < playerThings.Count; i++) {
				string goName = playerThings [i].thingPrefab.name + "(Clone)";

				if (child.name == goName) {
					Debug.Log ("true");
					Thing thing = playerThings [i];
					weight.text = thing.weight.ToString ();
					thingName.text = thing.name;
					descriptionText.text = thing.description;
					movesCount.text = thing.movesCost.ToString ();
				}	
			}	
		}
	}

	public void Info3(){
		if (isFull [3] == true) {
			infoPanel.SetActive (true);
			Transform child = slots [3].transform.GetChild (2);

			for (int i = 0; i < playerThings.Count; i++) {
				string goName = playerThings [i].thingPrefab.name + "(Clone)";

				if (child.name == goName) {
					Debug.Log ("true");
					Thing thing = playerThings [i];
					weight.text = thing.weight.ToString ();
					thingName.text = thing.name;
					descriptionText.text = thing.description;
					movesCount.text = thing.movesCost.ToString ();
				}	
			}	
		}
	}

	public void Info4(){
		if (isFull [4] == true) {
			infoPanel.SetActive (true);
			Transform child = slots [4].transform.GetChild (2);

			for (int i = 0; i < playerThings.Count; i++) {
				string goName = playerThings [i].thingPrefab.name + "(Clone)";

				if (child.name == goName) {
					Debug.Log ("true");
					Thing thing = playerThings [i];
					weight.text = thing.weight.ToString ();
					thingName.text = thing.name;
					descriptionText.text = thing.description;
					movesCount.text = thing.movesCost.ToString ();
				}	
			}	
		}
	}

	public void Info5(){
		if (isFull [5] == true) {
			infoPanel.SetActive (true);
			Transform child = slots [5].transform.GetChild (2);

			for (int i = 0; i < playerThings.Count; i++) {
				string goName = playerThings [i].thingPrefab.name + "(Clone)";

				if (child.name == goName) {
					Debug.Log ("true");
					Thing thing = playerThings [i];
					weight.text = thing.weight.ToString ();
					thingName.text = thing.name;
					descriptionText.text = thing.description;
					movesCount.text = thing.movesCost.ToString ();
				}	
			}	
		}
	}

	public void Info6(){
		if (isFull [6] == true) {
			infoPanel.SetActive (true);
			Transform child = slots [6].transform.GetChild (2);

			for (int i = 0; i < playerThings.Count; i++) {
				string goName = playerThings [i].thingPrefab.name + "(Clone)";

				if (child.name == goName) {
					Debug.Log ("true");
					Thing thing = playerThings [i];
					weight.text = thing.weight.ToString ();
					thingName.text = thing.name;
					descriptionText.text = thing.description;
					movesCount.text = thing.movesCost.ToString ();
				}	
			}
		}
	}

	public void Info7(){
		if (isFull [7] == true) {
			infoPanel.SetActive (true);
			Transform child = slots [7].transform.GetChild (2);

			for (int i = 0; i < playerThings.Count; i++) {
				string goName = playerThings [i].thingPrefab.name + "(Clone)";

				if (child.name == goName) {
					Debug.Log ("true");
					Thing thing = playerThings [i];
					weight.text = thing.weight.ToString ();
					thingName.text = thing.name;
					descriptionText.text = thing.description;
					movesCount.text = thing.movesCost.ToString ();
				}	
			}
		}
	}

	public void ButtonX0(){
		if (isFull [0] == true) {
			Transform child = slots [0].transform.GetChild (2);

			selectedPlayer.GetComponent<Inventory> ().isFull [0] = false;
			for (int j = 0; j < playerThings.Count; j++) {
				string goName = playerThings [j].thingPrefab.name + "(Clone)";
				if (child.name == goName) {
					selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
					GameObject box = Instantiate (inventoryBox, BoxPosition (), inventoryBox.transform.rotation);
					box.GetComponent<BoxInventory> ().thing = playerThings [j];
					playerThings.RemoveAt (j);
					break;
				}
			}
			Destroy (child.gameObject);
		}
	}

	public void ButtonX1(){
		if (isFull [1] == true) {
			Transform child = slots [1].transform.GetChild (2);

			selectedPlayer.GetComponent<Inventory> ().isFull [1] = false;
			for (int j = 0; j < playerThings.Count; j++) {
				string goName = playerThings [j].thingPrefab.name + "(Clone)";
				if (child.name == goName) {
					selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
					GameObject box = Instantiate (inventoryBox, BoxPosition (), inventoryBox.transform.rotation);
					box.GetComponent<BoxInventory> ().thing = playerThings [j];
					playerThings.RemoveAt (j);
					break;
				}
			}
			Destroy (child.gameObject);
		}
	}

	public void ButtonX2(){
		if (isFull [2] == true) {
			Transform child = slots [2].transform.GetChild (2);

			selectedPlayer.GetComponent<Inventory> ().isFull [2] = false;
			for (int j = 0; j < playerThings.Count; j++) {
				string goName = playerThings [j].thingPrefab.name + "(Clone)";
				if (child.name == goName) {
					selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
					GameObject box = Instantiate (inventoryBox, BoxPosition (), inventoryBox.transform.rotation);
					box.GetComponent<BoxInventory> ().thing = playerThings [j];
					playerThings.RemoveAt (j);
					break;
				}
			}
			Destroy (child.gameObject);
		}
	}

	public void ButtonX3(){
		if (isFull [3] == true) {
			Transform child = slots [3].transform.GetChild (2);

			selectedPlayer.GetComponent<Inventory> ().isFull [3] = false;
			for (int j = 0; j < playerThings.Count; j++) {
				string goName = playerThings [j].thingPrefab.name + "(Clone)";
				if (child.name == goName) {
					selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
					GameObject box = Instantiate (inventoryBox, BoxPosition (), inventoryBox.transform.rotation);
					box.GetComponent<BoxInventory> ().thing = playerThings [j];
					playerThings.RemoveAt (j);
					break;
				}
			}
			Destroy (child.gameObject);
		}
	}

	public void ButtonX4(){
		if (isFull [4] == true) {
			Transform child = slots [4].transform.GetChild (2);

			selectedPlayer.GetComponent<Inventory> ().isFull [4] = false;
			for (int j = 0; j < playerThings.Count; j++) {
				string goName = playerThings [j].thingPrefab.name + "(Clone)";
				if (child.name == goName) {
					selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
					GameObject box = Instantiate (inventoryBox, BoxPosition (), inventoryBox.transform.rotation);
					box.GetComponent<BoxInventory> ().thing = playerThings [j];
					playerThings.RemoveAt (j);
					break;
				}
			}
			Destroy (child.gameObject);
		}
	}

	public void ButtonX5(){
		if (isFull [5] == true) {
			Transform child = slots [5].transform.GetChild (2);

			selectedPlayer.GetComponent<Inventory> ().isFull [5] = false;
			for (int j = 0; j < playerThings.Count; j++) {
				string goName = playerThings [j].thingPrefab.name + "(Clone)";
				if (child.name == goName) {
					selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
					GameObject box = Instantiate (inventoryBox, BoxPosition (), inventoryBox.transform.rotation);
					box.GetComponent<BoxInventory> ().thing = playerThings [j];
					playerThings.RemoveAt (j);
					break;
				}
			}
			Destroy (child.gameObject);
		}
	}

	public void ButtonX6(){
		if (isFull [6] == true) {
			Transform child = slots [6].transform.GetChild (2);

			selectedPlayer.GetComponent<Inventory> ().isFull [6] = false;
			for (int j = 0; j < playerThings.Count; j++) {
				string goName = playerThings [j].thingPrefab.name + "(Clone)";
				if (child.name == goName) {
					selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
					GameObject box = Instantiate (inventoryBox, BoxPosition (), inventoryBox.transform.rotation);
					box.GetComponent<BoxInventory> ().thing = playerThings [j];
					playerThings.RemoveAt (j);
					break;
				}
			}
			Destroy (child.gameObject);
		}
	}

	public void ButtonX7(){
		if (isFull [7] == true) {
			Transform child = slots [7].transform.GetChild (2);

			selectedPlayer.GetComponent<Inventory> ().isFull [7] = false;
			for (int j = 0; j < playerThings.Count; j++) {
				string goName = playerThings [j].thingPrefab.name + "(Clone)";
				if (child.name == goName) {
					selectedPlayer.GetComponent<Player> ().currentInventoryWeight = 
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight - selectedPlayer.GetComponent<Player> ().inventory [j].weight;
					GameObject box = Instantiate (inventoryBox, BoxPosition (), inventoryBox.transform.rotation);
					box.GetComponent<BoxInventory> ().thing = playerThings [j];
					playerThings.RemoveAt (j);
					break;
				}
			}
			Destroy (child.gameObject);
		}
	}

	Vector3 BoxPosition(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		Vector3 boxPosition = new Vector3 ();

		int randPos = Random.Range (1, 9);

		switch (randPos) {
		case 1:
			boxPosition = new Vector3 (Mathf.Clamp(posX + 1.0f, 0, 19.0f), 0.6f, posZ);
			break;
		case 2:
			boxPosition = new Vector3 (Mathf.Clamp(posX + 1.0f, 0, 19.0f), 0.6f, Mathf.Clamp(posZ + 1.0f, 0, 23.0f));
			break;
		case 3:
			boxPosition = new Vector3 (Mathf.Clamp(posX + 1.0f, 0, 19.0f), 0.6f, Mathf.Clamp(posZ - 1.0f, 0, 23.0f));
			break;
		case 4:
			boxPosition = new Vector3 (posX, 0.6f, Mathf.Clamp(posZ + 1.0f, 0.6f, 23.0f));
			break;
		case 5:
			boxPosition = new Vector3 (posX, 0.6f, Mathf.Clamp(posZ - 1.0f, 0.6f, 23.0f));
			break;
		case 6:
			boxPosition = new Vector3 (Mathf.Clamp(posX - 1.0f, 0, 19.0f), 0.6f, posZ);
			break;
		case 7:
			boxPosition = new Vector3 (Mathf.Clamp(posX - 1.0f, 0, 19.0f), 0.6f, Mathf.Clamp(posZ + 1.0f, 0, 23.0f));
			break;
		case 8:
			boxPosition = new Vector3 (Mathf.Clamp (posX - 1.0f, 0, 19.0f), 0.6f, Mathf.Clamp (posZ - 1.0f, 0, 23.0f));
			break;
		}

		return boxPosition;
	}
}
