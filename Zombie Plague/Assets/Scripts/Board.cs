using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Board : MonoBehaviour {
	public GameObject selectedPlayer;
	public GameObject selectedZombie;
	public GameObject[] players;
	public GameObject[] allPlayers;
	public List<GameObject> zombies;
	public GameObject[] allZombies;
	Vector3[] playersPositions;
	public Thing[] allThings;
	public Thing[] specialThings;
	public GameObject searchButton;
	public bool endRound = false;
	GameObject gui;
	GUIButtonsActions classGUI;
	public GameObject pickUp;
	public GameObject zPickUp;
	public Image[] slots;
	List<Thing> inventory;
	public bool[] isFull;
	public List<GameObject> attackedHumans;
	//bool inventoryLoad = false;

	void Start(){
		playersPositions = new [] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 1f), 
			new Vector3(1f, 0f, 0f), new Vector3(1f, 0f, 1f) };

		gui = GameObject.Find ("GUI");
		classGUI = gui.GetComponent<GUIButtonsActions> ();

		attackedHumans = new List<GameObject> ();

		//Human players spawn
		players = GenPlayers(4, allPlayers);
		ActivatedPlayers (players, playersPositions);
		selectedPlayer = SelectPlayer(players);

		//Spawn first six zombies
		zombies = GenFirstZombies (allZombies);
		FirstZombiesSpawn (players, zombies);
		ActivatedZombies (zombies);
		selectedZombie = SelectZombie (zombies);
		Instantiate (zPickUp, selectedZombie.transform, false);
		GenCacheInventory (allThings, specialThings);
	}

	void Update(){
		if (selectedPlayer.GetComponent<Player> ().moves == 0 || endRound == true) {
			endRound = false;
			do {
				PassTheMove (selectedPlayer, players);
				selectedPlayer = SelectPlayer (players);
			} while(selectedPlayer.GetComponent<Player> ().currentHP <= 1);
		}
		ActiveSearchButton (selectedPlayer);
		if (selectedPlayer.GetComponent<Player> ().moves == zombies.Count + 1) {
			attackedHumans.Clear ();
			StartRoundSpawnZombie (zombies, allZombies, players);
		}
		if (selectedPlayer == players [players.Length - 1]) {
			if (selectedZombie.GetComponent<Zombie> ().zMoves == 0) {
				GameObject temp = selectedZombie;
				selectedZombie = SelectZombie (zombies);
				Destroy (temp.transform.GetChild (1).gameObject);
				Instantiate (zPickUp, selectedZombie.transform, false);
				ZombiePassTheMove (selectedZombie, zombies);
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			}
		}
		if (players [players.Length - 1].GetComponent<Player> ().moves == 0) {
			Destroy (selectedZombie.transform.GetChild (1).gameObject);
			selectedZombie = zombies [0];
			Instantiate (zPickUp, selectedZombie.transform, false);
		}
		//isFull = selectedPlayer.GetComponent<Inventory>().isFull;
		//inventory = selectedPlayer.GetComponent<Player> ().inventory;
		//AddThingsToSlot (inventory, slots, isFull);
	}

	/*void DestroyDeadPlayers(GameObject[] players){
		for (int i = 0; i < players.Length; i++) {
			if (players [i].GetComponent<Player> ().currentHP == 0) {
				players [i].SetActive (false);
			}
		}
	}*/

	//Генерируем игроков
	GameObject[] GenPlayers(int countPlayers, GameObject[] allPlayers){
		GameObject[] players;
		players = new GameObject[countPlayers];
		List<int> randomPlayerNum;
		randomPlayerNum = RandomPlayerNum (allPlayers.Length, 0, allPlayers.Length);

		for (int i = 0; i < players.Length; i++) {
			players [i] = allPlayers [randomPlayerNum[i]];
		}

		players [players.Length - 1].GetComponent<Player> ().isZombiePlayer = true;

		return players;
	}

	//Активируем игроков на карте
	void ActivatedPlayers(GameObject[] players, Vector3[] playerPositions){
		for (int i = 0; i < players.Length; i++) {
			if (players [i].GetComponent<Player> ().isZombiePlayer != true) {
				players [i].SetActive (true);
				players [i].transform.position = playerPositions [i];
				players [i].GetComponent<Player> ().positionV = players [i].transform.position.x;
				players [i].GetComponent<Player> ().positionH = players [i].transform.position.z;
			}
		}
	}

	//Выбираем игрока
	GameObject SelectPlayer(GameObject[] players){
		for (int i = 0; i < players.Length; i++) {
			if (players [i].GetComponent<Player> ().isSelected == true) {
				Instantiate (pickUp, players [i].transform, false);
				return players [i];
			}
		}
		players [0].GetComponent<Player>().isSelected = true;
		Instantiate (pickUp, players[0].transform, false);
		return players[0];
	}

	//Генерируем индексы моделей игроков
	List<int> RandomPlayerNum(int size, int min, int max){
		List<int> randomPlayerNum = new List<int>();

		while (randomPlayerNum.Count < 4) {
			for (int i = 0; i < size; i++) {
				randomPlayerNum.Add (Random.Range (min, max));
			}

			randomPlayerNum = randomPlayerNum.Distinct ().ToList ();
		}

		return randomPlayerNum;
	}

	//Передаёт ход слежущему игроку
	void PassTheMove(GameObject selectedPlayer, GameObject[] players){
		int temp = 0;
		for (int i = 0; i < players.Length; i++) {
			if (selectedPlayer == players [i]) {
				temp = i;
				break;
			}
		}
		players [temp].GetComponent<Player> ().isSelected = false;
		players [temp].GetComponent<Player> ().weaponType = 0;
		isFull = players [temp].GetComponent<Inventory> ().isFull;

		//Очищаем слоты инвентаря для следующего пользователя
		for (int i = 0; i < slots.Length; i++) {
			if (isFull [i] == true) {
				isFull [i] = false;
				if (slots [i].transform.childCount > 0) {
					Destroy (slots [i].transform.GetChild (2).gameObject);
				}
			}
		}
		Destroy (players [temp].transform.GetChild (1).gameObject);
		if (players [(temp + 1) % players.Length].GetComponent<Player>().isZombiePlayer == false) {
			if (players [(temp + 1) % players.Length].GetComponent<Player> ().usingDrugs == false) {
				players [(temp + 1) % players.Length].GetComponent<Player> ().moves = 
					players [(temp + 1) % players.Length].GetComponent<Player> ().currentHP - 1;
			} 
			else {
				players [(temp + 1) % players.Length].GetComponent<Player> ().moves = 
					players [(temp + 1) % players.Length].GetComponent<Player> ().maxMoves;
			}
			classGUI.humanPlayerTime = 60f;
		} 
		else {
			players [(temp + 1) % players.Length].GetComponent<Player> ().moves = zombies.Count + 1; // +1 это костыль так как нехватает хода 1 зомби
			classGUI.zombiePlayerTime = 360f;
		}
		isFull = players [(temp + 1) % players.Length].GetComponent<Inventory> ().isFull;
		inventory = players [(temp + 1) % players.Length].GetComponent<Player> ().inventory;

		AddThingsToSlot(inventory, slots, isFull);
		players [(temp + 1) % players.Length].GetComponent<Player> ().isSelected = true; 
	}

	//Генерирует первых 6 зомби
	List<GameObject> GenFirstZombies(GameObject[] allZombies){
		List<GameObject> zombies;
		zombies = new List<GameObject> ();
		for (int i = 0; i < 6; i++){
			zombies.Add(allZombies[i]);
		}
		return zombies;
	}

	//Активирует 1 зомби на карте
	void ActivateZombie(GameObject zombie){
		zombie.SetActive (true);
	}

	//Функция нужна для активации сразу нескольких зомби
	void ActivatedZombies(List<GameObject> zombies){
		for(int i = 0; i < zombies.Count; i++){
			ActivateZombie (zombies[i]);
		}
	}

	//Присваиваем первым 6 зомби их координаты
	void FirstZombiesSpawn(GameObject[] players, List<GameObject> zombies){
		zombies [0].transform.position = Sector (players, zombies, 0, 9, 0, 7);
		zombies [1].transform.position = Sector (players, zombies, 0, 9, 8, 15);
		zombies [2].transform.position = Sector (players, zombies, 0, 9, 16, 23);
		zombies [3].transform.position = Sector (players, zombies, 10, 19, 0, 7);
		zombies [4].transform.position = Sector (players, zombies, 10, 19, 8, 15);
		zombies [5].transform.position = Sector (players, zombies, 10, 19, 16, 23);

		for (int i = 0; i < zombies.Count; i++) {
			zombies [i].GetComponent<Zombie> ().zPositionV = zombies [i].transform.position.x;
			zombies [i].GetComponent<Zombie> ().zPositionH = zombies [i].transform.position.z;
		}
	}

	//Спавним зомби в начале раунда Игрока Зомби
	void StartRoundSpawnZombie(List<GameObject> zombies, GameObject[] allZombies, GameObject[] players){
		int flags = 0;

		if (zombies.Count != allZombies.Length) {
			for (int i = 0; i < allZombies.Length; i++) {
				for (int j = 0; j < zombies.Count; j++) {
					if (allZombies [i] != zombies [j]) {
						continue;
					} 
					else {
						flags++;
						break;
					}
				}
				if (flags == 0) {
					zombies.Add (allZombies [i]);
					AddPosForNewZombie (zombies [zombies.Count - 1], players);
					zombies [zombies.Count - 1].GetComponent<Zombie> ().zPositionV = 
						zombies [zombies.Count - 1].transform.position.x;
					zombies [zombies.Count - 1].GetComponent<Zombie> ().zPositionH = 
						zombies [zombies.Count - 1].transform.position.z;
					ActivateZombie (zombies [zombies.Count - 1]);
					break;
				} 
				else {
					flags = 0;
				}
			}
		}
	}

	//Присваиваем позицию новому Зомби
	void AddPosForNewZombie(GameObject zombie, GameObject[] players){
		int sector = 0;

		sector = Random.Range (1, 6);

		switch (sector) {
		case 1:
			zombie.transform.position = Sector (players, zombies, 0, 9, 0, 7);
			break;
		case 2:
			zombie.transform.position = Sector (players, zombies, 0, 9, 8, 15);
			break;
		case 3:
			zombie.transform.position = Sector (players, zombies, 0, 9, 16, 23);
			break;
		case 4: 
			zombie.transform.position = Sector (players, zombies, 10, 19, 0, 7);
			break;
		case 5:
			zombie.transform.position = Sector (players, zombies, 10, 19, 8, 15);
			break;
		case 6:
			zombie.transform.position = Sector (players, zombies, 10, 19, 16, 23);
			break;
		default:
			zombie.transform.position = Sector (players, zombies, 0, 9, 0, 7);
			break;
		}
	}

	//Функция спавна 1 зомби
	void SpawnZombie(GameObject zombie, Vector3 pos){
		zombie.transform.position = pos;
	}

	//Правила спавна зомби
	void ZombieSpawnRules(GameObject[] players, GameObject zombie, Vector3 zombiePos){
		int flags = 0;
		for(int i = 0; i < players.Length; i++){
			if(Vector3.Distance(players[i].transform.position, zombiePos) > 4){ // Растояние между игроком и новым зомби должно быть > 4
				flags = flags++;
			}
		}
		if(flags == players.Length){
			SpawnZombie(zombie, zombiePos);
		}
	}

	//Возвращает true если позиция спавна зомби дальше на 4 метра чем позиции всех игроков
	bool IsPlayerPos(GameObject[] players, Vector3 position){
		int flags = 0;
		for (int i = 0; i < players.Length; i++) {
			if(Vector3.Distance(players[i].transform.position, position) > 4) {
				flags = flags++;
			}
		}
		if (flags > 0) {
			return false;
		} 
		else {
			return true;
		}
	}
	//Возвращает true если это позиция Зомби
	public bool IsZombiePos(List<GameObject> zombies, Vector3 position){
		int flags = 0;
		for (int i = 0; i < zombies.Count; i++) {
			if(zombies[i].transform.position == position) {
				flags = flags++;
				break;
			}
		}
		if (flags == 0) {
			return true;
		} 
		else {
			return false;
		}
	}

	//Генерирует посицию в заданом секторе
	Vector3 Sector(GameObject[] players, List<GameObject> zombies, int minX, int maxX, int minZ, int maxZ){
		Vector3 posInVector;
		List<Vector3> blockedTile;
		blockedTile = BlockedTile ();
		int flag = 0;
		do {
			posInVector = new Vector3 ((float)Random.Range (minX, maxX), 0f, (float)Random.Range (minZ, maxZ));
			for(int i = 0; i < blockedTile.Count; i++){
				if(posInVector == blockedTile[i] && IsPlayerPos(players, posInVector) == true && IsZombiePos(zombies ,posInVector) == true){
					flag = flag++;
				}
			}
		} while(flag != 0);
		return posInVector;
	}

	//Список заблокированых позиций
	public List<Vector3> BlockedTile(){
		List<Vector3> blockedTile;
		blockedTile = new List<Vector3> ();
		for (int i = 1; i <= 24; i++) {
			for (int j = 1; j <= 20; j++) {
				GameObject tempTile;
				string tileName = string.Format ("Cube_{0}_{1}", i, j);
				tempTile = GameObject.Find (tileName);
				if (tempTile.tag == "Block") {
					blockedTile.Add (tempTile.transform.position);
				}
			}
		}

		return blockedTile;
	}

	//Функция выбора зомби
	GameObject SelectZombie(List<GameObject> zombies){
		for (int i = 0; i < zombies.Count; i++) {
			if (zombies [i].GetComponent<Zombie> ().isSelected == true) {
				return zombies [i];
			}
		}
		zombies [0].GetComponent<Zombie> ().isSelected = true;
		return zombies [0];
	}

	//Функция передачи хода следущему зомби
	void ZombiePassTheMove(GameObject selectedZombie, List<GameObject> zombies){
		int temp = 0;
		for (int i = 0; i < zombies.Count; i++) {
			if (selectedZombie == zombies [i]) {
				temp = i;
				break;
			}
		}
		zombies [temp].GetComponent<Zombie> ().isSelected = false;
		zombies [(temp + 1) % zombies.Count].GetComponent<Zombie> ().zMoves = 2;
		zombies [(temp + 1) % zombies.Count].GetComponent<Zombie> ().isSelected = true; 
	}
		
	//Добавляем предметы в хранилища
	void GenCacheInventory(Thing[] allThings, Thing[]  specialThings){
		GameObject[] caches;
		caches = new GameObject[6];

		for (int i = 0; i < caches.Length; i++) {
			string cacheNum = string.Format ("Cache{0}", i);
				caches [i] = GameObject.Find (cacheNum);
		}

		for (int i = 0; i < caches.Length; i++) {
			int countTnings = caches [i].GetComponent<Cache> ().countThings;
			for (int j = 0; j < countTnings; j++) {
				Thing thing = allThings [Random.Range (0, allThings.Length)];
				caches [i].GetComponent<Cache> ().inventory.Add (thing);
			}
		}

		int random = Random.Range (1, 4);

		if (random == 1) {
			caches [5].GetComponent<Cache> ().inventory [3] = specialThings [0];
			caches [4].GetComponent<Cache> ().inventory [3] = specialThings [1];
			caches [3].GetComponent<Cache> ().inventory [3] = specialThings [1];
		}
		if (random == 2) {
			caches [5].GetComponent<Cache> ().inventory [3] = specialThings [1];
			caches [4].GetComponent<Cache> ().inventory [3] = specialThings [1];
			caches [3].GetComponent<Cache> ().inventory [3] = specialThings [0];
		}
		if (random == 3) {
			caches [5].GetComponent<Cache> ().inventory [3] = specialThings [1];
			caches [4].GetComponent<Cache> ().inventory [3] = specialThings [0];
			caches [3].GetComponent<Cache> ().inventory [3] = specialThings [1];
		}
	}

	//Активация кнопки поиска возле ящиков с лутом
	void ActiveSearchButton(GameObject selectedPlayer){
		float xPos = selectedPlayer.transform.position.x;
		float zPos = selectedPlayer.transform.position.z;

		if ((xPos == 1.0f && zPos == 5.0f) || (xPos == 2.0f && zPos == 18.0f) ||
		    (xPos == 17.0f && zPos == 7.0f) || (xPos == 10.0f && zPos == 14.0f) ||
		    (xPos == 14.0f && zPos == 13.0f) || (xPos == 17.0f && zPos == 15.0f)) {
			searchButton.SetActive (true);
		} 
		else {
			searchButton.SetActive (false);
		}
	}

	//Довавляем вещь в слот инвентаря
	public void AddThingsToSlot(List<Thing> inventory, Image[] slots, bool[] isFull){
		if (inventory.Count > 0) {
			for (int i = 0; i < slots.Length; i++) {
				if (i < inventory.Count) {
					if (isFull [i] != true) {
						isFull [i] = true;
						GameObject thing = inventory [i].thingPrefab;
						Instantiate (thing, slots [i].transform, false);
					}
				} 
			}
		}
	}
}
