using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookTakeButtons : MonoBehaviour {

	public GameObject cacheInventory;
	public GameObject[] caches;
	public Sprite closedSprite;
	public Sprite nopeSprite;
	GameObject board;
	Board boardClass;
	GameObject selectedPlayer;
	public Image[] thingsImages;
	int currentInventoryWeight;
	float maxInventoryWeight;
	public Image[] slots;
	public bool[] isFull;

	public GameObject infoPanel;
	public Text weight;
	public Text thingName;
	public Text descriptionText;
	public Text movesCount;

	void Start(){
		board = GameObject.FindWithTag ("GameBoard");
		boardClass = board.GetComponent<Board>();
	}

	void Update(){
		selectedPlayer = boardClass.selectedPlayer;
		isFull = selectedPlayer.GetComponent<Inventory> ().isFull;
		currentInventoryWeight = selectedPlayer.GetComponent<Player> ().currentInventoryWeight;
		maxInventoryWeight = selectedPlayer.GetComponent<Player> ().maxInventoryWeight;
		ThingSprites ();
	}

	void ThingSprites(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		if (posX == 1.0f && posZ == 5.0f) {
			for (int i = 0; i < caches [0].GetComponent<Cache> ().isClosed.Length; i++) {
				bool isClosed = caches [0].GetComponent<Cache> ().isClosed [i];
				bool isEmpty = caches [0].GetComponent<Cache> ().isEmpty [i];
				if (isClosed == true && isEmpty == false) {
					thingsImages [i].sprite = closedSprite;
				} 
				else if (isEmpty == true) {
					thingsImages [i].sprite = nopeSprite;
				} 
				else {
					Sprite thingImage = caches [0].GetComponent<Cache> ().inventory [i].thingSprite;
					thingsImages [i].sprite = thingImage;
				}
			}
		}
		if (posX == 2.0f && posZ == 18.0f) {
			for (int i = 0; i < caches [1].GetComponent<Cache> ().isClosed.Length; i++) {
				bool isClosed = caches [1].GetComponent<Cache> ().isClosed [i];
				bool isEmpty = caches [1].GetComponent<Cache> ().isEmpty [i];
				if (isClosed == true && isEmpty == false) {
					thingsImages [i].sprite = closedSprite;
				} 
				else if (isEmpty == true) {
					thingsImages [i].sprite = nopeSprite;
				} 
				else {
					Sprite thingImage = caches [1].GetComponent<Cache> ().inventory [i].thingSprite;
					thingsImages [i].sprite = thingImage;
				}
			}
		}
		if (posX == 17.0f && posZ == 7.0f) {
			for (int i = 0; i < caches [2].GetComponent<Cache> ().isClosed.Length; i++) {
				bool isClosed = caches [2].GetComponent<Cache> ().isClosed [i];
				bool isEmpty = caches [2].GetComponent<Cache> ().isEmpty [i];
				if (isClosed == true && isEmpty == false) {
					thingsImages [i].sprite = closedSprite;
				} 
				else if (isEmpty == true) {
					thingsImages [i].sprite = nopeSprite;
				} 
				else {
					Sprite thingImage = caches [2].GetComponent<Cache> ().inventory [i].thingSprite;
					thingsImages [i].sprite = thingImage;
				}
			}
		}
		if (posX == 10.0f && posZ == 14.0f) {
			for (int i = 0; i < caches [3].GetComponent<Cache> ().isClosed.Length; i++) {
				bool isClosed = caches [3].GetComponent<Cache> ().isClosed [i];
				bool isEmpty = caches [3].GetComponent<Cache> ().isEmpty [i];
				if (isClosed == true && isEmpty == false) {
					thingsImages [i].sprite = closedSprite;
				} 
				else if (isEmpty == true) {
					thingsImages [i].sprite = nopeSprite;
				} 
				else {
					Sprite thingImage = caches [3].GetComponent<Cache> ().inventory [i].thingSprite;
					thingsImages [i].sprite = thingImage;
				}
			}
		}
		if (posX == 14.0f && posZ == 13.0f) {
			for (int i = 0; i < caches [4].GetComponent<Cache> ().isClosed.Length; i++) {
				bool isClosed = caches [4].GetComponent<Cache> ().isClosed [i];
				bool isEmpty = caches [4].GetComponent<Cache> ().isEmpty [i];
				if (isClosed == true && isEmpty == false) {
					thingsImages [i].sprite = closedSprite;
				} 
				else if (isEmpty == true) {
					thingsImages [i].sprite = nopeSprite;
				} 
				else {
					Sprite thingImage = caches [4].GetComponent<Cache> ().inventory [i].thingSprite;
					thingsImages [i].sprite = thingImage;
				}
			}
		}
		if (posX == 17.0f && posZ == 15.0f) {
			for (int i = 0; i < caches [5].GetComponent<Cache> ().isClosed.Length; i++) {
				bool isClosed = caches [5].GetComponent<Cache> ().isClosed [i];
				bool isEmpty = caches [5].GetComponent<Cache> ().isEmpty [i];
				if (isClosed == true && isEmpty == false) {
					thingsImages [i].sprite = closedSprite;
				} 
				else if (isEmpty == true) {
					thingsImages [i].sprite = nopeSprite;
				} 
				else {
					Sprite thingImage = caches [5].GetComponent<Cache> ().inventory [i].thingSprite;
					thingsImages [i].sprite = thingImage;
				}
			}
		}
	}

	public void Look0Btn(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		if (posX == 1.0f && posZ == 5.0f && caches [0].GetComponent<Cache> ().isClosed [0] != false) {
			caches [0].GetComponent<Cache> ().isClosed [0] = false;
			selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
		}
		if (posX == 2.0f && posZ == 18.0f && caches [1].GetComponent<Cache> ().isClosed [0] != false) {
			caches [1].GetComponent<Cache> ().isClosed [0] = false;
			selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
		}
		if (posX == 17.0f && posZ == 7.0f && caches [2].GetComponent<Cache> ().isClosed [0] != false) {
			caches [2].GetComponent<Cache> ().isClosed [0] = false;
			selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
		}
		if (posX == 10.0f && posZ == 14.0f && caches [3].GetComponent<Cache> ().isClosed [0] != false) {
			caches [3].GetComponent<Cache> ().isClosed [0] = false;
			selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
		}
		if (posX == 14.0f && posZ == 13.0f && caches [4].GetComponent<Cache> ().isClosed [0] != false) {
			caches [4].GetComponent<Cache> ().isClosed [0] = false;
			selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
		}
		if (posX == 17.0f && posZ == 15.0f && caches [5].GetComponent<Cache> ().isClosed [0] != false) {
			caches [5].GetComponent<Cache> ().isClosed [0] = false;
			selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
		}
	}

	public void Look1Btn(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		if (posX == 1.0f && posZ == 5.0f && caches [0].GetComponent<Cache> ().isClosed [1] != false) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0) {
				caches [0].GetComponent<Cache> ().isClosed [1] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 2.0f && posZ == 18.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [1].GetComponent<Cache> ().isClosed [1] != false) {
				caches [1].GetComponent<Cache> ().isClosed [1] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 17.0f && posZ == 7.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [2].GetComponent<Cache> ().isClosed [1] != false) {
				caches [2].GetComponent<Cache> ().isClosed [1] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 10.0f && posZ == 14.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [3].GetComponent<Cache> ().isClosed [1] != false) {
				caches [3].GetComponent<Cache> ().isClosed [1] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 14.0f && posZ == 13.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [4].GetComponent<Cache> ().isClosed [1] != false) {
				caches [4].GetComponent<Cache> ().isClosed [1] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 17.0f && posZ == 15.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [5].GetComponent<Cache> ().isClosed [1] != false) {
				caches [5].GetComponent<Cache> ().isClosed [1] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
	}

	public void Look2Btn(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		if (posX == 1.0f && posZ == 5.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [0].GetComponent<Cache> ().isClosed [2] != false) {
				caches [0].GetComponent<Cache> ().isClosed [2] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 2.0f && posZ == 18.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [1].GetComponent<Cache> ().isClosed [2] != false) {
				caches [1].GetComponent<Cache> ().isClosed [2] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 17.0f && posZ == 7.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [2].GetComponent<Cache> ().isClosed [2] != false) {
				caches [2].GetComponent<Cache> ().isClosed [2] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 10.0f && posZ == 14.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [3].GetComponent<Cache> ().isClosed [2] != false ) {
				caches [3].GetComponent<Cache> ().isClosed [2] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 14.0f && posZ == 13.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [4].GetComponent<Cache> ().isClosed [2] != false) {
				caches [4].GetComponent<Cache> ().isClosed [2] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 17.0f && posZ == 15.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [5].GetComponent<Cache> ().isClosed [2] != false) {
				caches [5].GetComponent<Cache> ().isClosed [2] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
	}

	public void Look3Btn(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		if (posX == 1.0f && posZ == 5.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [0].GetComponent<Cache> ().isClosed [3] != false) {
				caches [0].GetComponent<Cache> ().isClosed [3] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 2.0f && posZ == 18.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [1].GetComponent<Cache> ().isClosed [3] != false) {
				caches [1].GetComponent<Cache> ().isClosed [3] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 17.0f && posZ == 7.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [2].GetComponent<Cache> ().isClosed [3] != false) {
				caches [2].GetComponent<Cache> ().isClosed [3] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 10.0f && posZ == 14.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [3].GetComponent<Cache> ().isClosed [3] != false) {
				caches [3].GetComponent<Cache> ().isClosed [3] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 14.0f && posZ == 13.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [4].GetComponent<Cache> ().isClosed [3] != false) {
				caches [4].GetComponent<Cache> ().isClosed [3] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (posX == 17.0f && posZ == 15.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 0 && caches [5].GetComponent<Cache> ().isClosed [3] != false) {
				caches [5].GetComponent<Cache> ().isClosed [3] = false;
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
	}

	public void Take0Btn(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		if (posX == 1.0f && posZ == 5.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [0].GetComponent<Cache> ().isEmpty [0] != true) {
				Thing thing = caches [0].GetComponent<Cache> ().inventory [0];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [0].GetComponent<Cache> ().isClosed [0] = false;
						caches [0].GetComponent<Cache> ().isEmpty [0] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 2.0f && posZ == 18.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [1].GetComponent<Cache> ().isEmpty [0] != true) {
				Thing thing = caches [1].GetComponent<Cache> ().inventory [0];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [1].GetComponent<Cache> ().isClosed [0] = false;
						caches [1].GetComponent<Cache> ().isEmpty [0] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 17.0f && posZ == 7.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [2].GetComponent<Cache> ().isEmpty [0] != true) {
				Thing thing = caches [2].GetComponent<Cache> ().inventory [0];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [2].GetComponent<Cache> ().isClosed [0] = false;
						caches [2].GetComponent<Cache> ().isEmpty [0] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				} 
			}
		}
		if (posX == 10.0f && posZ == 14.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [3].GetComponent<Cache> ().isEmpty [0] != true) {
				Thing thing = caches [3].GetComponent<Cache> ().inventory [0];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [3].GetComponent<Cache> ().isClosed [0] = false;
						caches [3].GetComponent<Cache> ().isEmpty [0] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 14.0f && posZ == 13.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [4].GetComponent<Cache> ().isEmpty [0] != true) {
				Thing thing = caches [4].GetComponent<Cache> ().inventory [0];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [4].GetComponent<Cache> ().isClosed [0] = false;
						caches [4].GetComponent<Cache> ().isEmpty [0] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 17.0f && posZ == 15.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [5].GetComponent<Cache> ().isEmpty [0] != true) {
				Thing thing = caches [5].GetComponent<Cache> ().inventory [0];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [5].GetComponent<Cache> ().isClosed [0] = false;
						caches [5].GetComponent<Cache> ().isEmpty [0] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
	}

	public void Take1Btn(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		if (posX == 1.0f && posZ == 5.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [0].GetComponent<Cache> ().isEmpty [1] != true) {
				Thing thing = caches [0].GetComponent<Cache> ().inventory [1];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [0].GetComponent<Cache> ().isClosed [1] = false;
						caches [0].GetComponent<Cache> ().isEmpty [1] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 2.0f && posZ == 18.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [1].GetComponent<Cache> ().isEmpty [1] != true) {
				Thing thing = caches [1].GetComponent<Cache> ().inventory [1];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [1].GetComponent<Cache> ().isClosed [1] = false;
						caches [1].GetComponent<Cache> ().isEmpty [1] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 17.0f && posZ == 7.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [2].GetComponent<Cache> ().isEmpty [1] != true) {
				Thing thing = caches [2].GetComponent<Cache> ().inventory [1];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [2].GetComponent<Cache> ().isClosed [1] = false;
						caches [2].GetComponent<Cache> ().isEmpty [1] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 10.0f && posZ == 14.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [3].GetComponent<Cache> ().isEmpty [1] != true) {
				Thing thing = caches [3].GetComponent<Cache> ().inventory [1];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [3].GetComponent<Cache> ().isClosed [1] = false;
						caches [3].GetComponent<Cache> ().isEmpty [1] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 14.0f && posZ == 13.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [4].GetComponent<Cache> ().isEmpty [1] != true) {
				Thing thing = caches [4].GetComponent<Cache> ().inventory [1];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [4].GetComponent<Cache> ().isClosed [1] = false;
						caches [4].GetComponent<Cache> ().isEmpty [1] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 17.0f && posZ == 15.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [5].GetComponent<Cache> ().isEmpty [1] != true) {
				Thing thing = caches [5].GetComponent<Cache> ().inventory [1];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [5].GetComponent<Cache> ().isClosed [1] = false;
						caches [5].GetComponent<Cache> ().isEmpty [1] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
	}

	public void Take2Btn(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		if (posX == 1.0f && posZ == 5.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [0].GetComponent<Cache> ().isEmpty [2] != true) {
				Thing thing = caches [0].GetComponent<Cache> ().inventory [2];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [0].GetComponent<Cache> ().isClosed [2] = false;
						caches [0].GetComponent<Cache> ().isEmpty [2] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 2.0f && posZ == 18.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [1].GetComponent<Cache> ().isEmpty [2] != true) {
				Thing thing = caches [1].GetComponent<Cache> ().inventory [2];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [1].GetComponent<Cache> ().isClosed [2] = false;
						caches [1].GetComponent<Cache> ().isEmpty [2] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 17.0f && posZ == 7.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [2].GetComponent<Cache> ().isEmpty [2] != true) {
				Thing thing = caches [2].GetComponent<Cache> ().inventory [2];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [2].GetComponent<Cache> ().isClosed [2] = false;
						caches [2].GetComponent<Cache> ().isEmpty [2] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 10.0f && posZ == 14.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [3].GetComponent<Cache> ().isEmpty [2] != true) {
				Thing thing = caches [3].GetComponent<Cache> ().inventory [2];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [3].GetComponent<Cache> ().isClosed [2] = false;
						caches [3].GetComponent<Cache> ().isEmpty [2] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 14.0f && posZ == 13.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [4].GetComponent<Cache> ().isEmpty [2] != true) {
				Thing thing = caches [4].GetComponent<Cache> ().inventory [2];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [4].GetComponent<Cache> ().isClosed [2] = false;
						caches [4].GetComponent<Cache> ().isEmpty [2] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 17.0f && posZ == 15.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [5].GetComponent<Cache> ().isEmpty [2] != true) {
				Thing thing = caches [5].GetComponent<Cache> ().inventory [2];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [5].GetComponent<Cache> ().isClosed [2] = false;
						caches [5].GetComponent<Cache> ().isEmpty [2] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
	}

	public void Take3Btn(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		if (posX == 1.0f && posZ == 5.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [0].GetComponent<Cache> ().isEmpty [3] != true) {
				Thing thing = caches [0].GetComponent<Cache> ().inventory [3];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [0].GetComponent<Cache> ().isClosed [3] = false;
						caches [0].GetComponent<Cache> ().isEmpty [3] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 2.0f && posZ == 18.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [1].GetComponent<Cache> ().isEmpty [3] != true) {
				Thing thing = caches [1].GetComponent<Cache> ().inventory [3];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [1].GetComponent<Cache> ().isClosed [3] = false;
						caches [1].GetComponent<Cache> ().isEmpty [3] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 17.0f && posZ == 7.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [2].GetComponent<Cache> ().isEmpty [3] != true) {
				Thing thing = caches [2].GetComponent<Cache> ().inventory [3];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [2].GetComponent<Cache> ().isClosed [3] = false;
						caches [2].GetComponent<Cache> ().isEmpty [3] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 10.0f && posZ == 14.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [3].GetComponent<Cache> ().isEmpty [3] != true) {
				Thing thing = caches [3].GetComponent<Cache> ().inventory [3];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [3].GetComponent<Cache> ().isClosed [3] = false;
						caches [3].GetComponent<Cache> ().isEmpty [3] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 14.0f && posZ == 13.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [4].GetComponent<Cache> ().isEmpty [3] != true) {
				Thing thing = caches [4].GetComponent<Cache> ().inventory [3];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [4].GetComponent<Cache> ().isClosed [3] = false;
						caches [4].GetComponent<Cache> ().isEmpty [3] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
		}
		if (posX == 17.0f && posZ == 15.0f) {
			if (selectedPlayer.GetComponent<Player> ().moves > 1 && caches [5].GetComponent<Cache> ().isEmpty [3] != true) {
				Thing thing = caches [5].GetComponent<Cache> ().inventory [3];
				if (currentInventoryWeight < maxInventoryWeight || thing.weight == 0) {
					if (thing.weight <= (maxInventoryWeight - currentInventoryWeight)) {
						caches [5].GetComponent<Cache> ().isClosed [3] = false;
						caches [5].GetComponent<Cache> ().isEmpty [3] = true;
						selectedPlayer.GetComponent<Player> ().inventory.Add (thing);
						AddThingToSlot (thing, slots, isFull);
						currentInventoryWeight = currentInventoryWeight + thing.weight;
						selectedPlayer.GetComponent<Player> ().currentInventoryWeight = currentInventoryWeight;
						selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
					} else {
						Debug.Log ("This thing is too heavy for you.");
					}
				} else {
					Debug.Log ("You inventory is full.");
				}
			}
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

	//Вывод информации об объекте
	public void Thing0Info(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		if (posX == 1.0f && posZ == 5.0f && caches [0].GetComponent<Cache> ().isClosed [0] == false) {
			Thing thing = caches [0].GetComponent<Cache> ().inventory [0];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 2.0f && posZ == 18.0f && caches [1].GetComponent<Cache> ().isClosed [0] == false) {
			Thing thing = caches [1].GetComponent<Cache> ().inventory [0];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 17.0f && posZ == 7.0f && caches [2].GetComponent<Cache> ().isClosed [0] == false) {
			Thing thing = caches [2].GetComponent<Cache> ().inventory [0];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 10.0f && posZ == 14.0f && caches [3].GetComponent<Cache> ().isClosed [0] == false) {
			Thing thing = caches [3].GetComponent<Cache> ().inventory [0];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 14.0f && posZ == 13.0f && caches [4].GetComponent<Cache> ().isClosed [0] == false) {
			Thing thing = caches [4].GetComponent<Cache> ().inventory [0];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 17.0f && posZ == 15.0f && caches [5].GetComponent<Cache> ().isClosed [0] == false) {
			Thing thing = caches [5].GetComponent<Cache> ().inventory [0];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
	}

	public void Thing1Info(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		if (posX == 1.0f && posZ == 5.0f && caches [0].GetComponent<Cache> ().isClosed [1] == false) {
			Thing thing = caches [0].GetComponent<Cache> ().inventory [1];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 2.0f && posZ == 18.0f && caches [1].GetComponent<Cache> ().isClosed [1] == false) {
			Thing thing = caches [1].GetComponent<Cache> ().inventory [1];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 17.0f && posZ == 7.0f && caches [2].GetComponent<Cache> ().isClosed [1] == false) {
			Thing thing = caches [2].GetComponent<Cache> ().inventory [1];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 10.0f && posZ == 14.0f && caches [3].GetComponent<Cache> ().isClosed [1] == false) {
			Thing thing = caches [3].GetComponent<Cache> ().inventory [1];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 14.0f && posZ == 13.0f && caches [4].GetComponent<Cache> ().isClosed [1] == false) {
			Thing thing = caches [4].GetComponent<Cache> ().inventory [1];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 17.0f && posZ == 15.0f && caches [5].GetComponent<Cache> ().isClosed [1] == false) {
			Thing thing = caches [5].GetComponent<Cache> ().inventory [1];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
	}

	public void Thing2Info(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		if (posX == 1.0f && posZ == 5.0f && caches [0].GetComponent<Cache> ().isClosed [2] == false) {
			Thing thing = caches [0].GetComponent<Cache> ().inventory [2];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 2.0f && posZ == 18.0f && caches [1].GetComponent<Cache> ().isClosed [2] == false) {
			Thing thing = caches [1].GetComponent<Cache> ().inventory [2];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 17.0f && posZ == 7.0f && caches [2].GetComponent<Cache> ().isClosed [2] == false) {
			Thing thing = caches [2].GetComponent<Cache> ().inventory [2];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 10.0f && posZ == 14.0f && caches [3].GetComponent<Cache> ().isClosed [2] == false) {
			Thing thing = caches [3].GetComponent<Cache> ().inventory [2];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 14.0f && posZ == 13.0f && caches [4].GetComponent<Cache> ().isClosed [2] == false) {
			Thing thing = caches [4].GetComponent<Cache> ().inventory [2];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 17.0f && posZ == 15.0f && caches [5].GetComponent<Cache> ().isClosed [2] == false) {
			Thing thing = caches [5].GetComponent<Cache> ().inventory [2];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
	}

	public void Thing3Info(){
		float posX = selectedPlayer.GetComponent<Player> ().positionV;
		float posZ = selectedPlayer.GetComponent<Player> ().positionH;
		if (posX == 1.0f && posZ == 5.0f && caches [0].GetComponent<Cache> ().isClosed [3] == false) {
			Thing thing = caches [0].GetComponent<Cache> ().inventory [3];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 2.0f && posZ == 18.0f && caches [1].GetComponent<Cache> ().isClosed [3] == false) {
			Thing thing = caches [1].GetComponent<Cache> ().inventory [3];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 17.0f && posZ == 7.0f && caches [2].GetComponent<Cache> ().isClosed [3] == false) {
			Thing thing = caches [2].GetComponent<Cache> ().inventory [3];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 10.0f && posZ == 14.0f && caches [3].GetComponent<Cache> ().isClosed [3] == false) {
			Thing thing = caches [3].GetComponent<Cache> ().inventory [3];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 14.0f && posZ == 13.0f && caches [4].GetComponent<Cache> ().isClosed [3] == false) {
			Thing thing = caches [4].GetComponent<Cache> ().inventory [3];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
		if (posX == 17.0f && posZ == 15.0f && caches [5].GetComponent<Cache> ().isClosed [3] == false) {
			Thing thing = caches [5].GetComponent<Cache> ().inventory [3];
			infoPanel.SetActive (true);
			weight.text = thing.weight.ToString();
			thingName.text = thing.name;
			descriptionText.text = thing.description;
			movesCount.text = thing.movesCost.ToString();
		}
	}

	public void ButtonInfoX(){
		infoPanel.SetActive (false);
	}
}
