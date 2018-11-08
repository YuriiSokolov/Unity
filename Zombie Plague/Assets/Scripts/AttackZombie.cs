using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackZombie : MonoBehaviour {

	public GameObject board;
	Board boardClass;
	GameObject selectedPlayer;
	List<GameObject> zombies;
	GameObject selectedZombie;
	public Weapon[] weapons;
	public int weaponRadius;
	public int weaponEfficiency;

	void Start(){
		//board = GameObject.FindWithTag ("GameBoard");
		boardClass = board.GetComponent<Board>();
	}

	void Update(){
		selectedPlayer = boardClass.selectedPlayer;
		zombies = boardClass.zombies;
		weaponRadius = weapons [PlayerWeaponType ()].radius;
		weaponEfficiency = weapons [PlayerWeaponType ()].efficiency;
	}

	void OnMouseUp(){
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			Debug.Log ("Zombie");
			SelectedZombie ();
			Debug.Log ("Distance = " + Distance ());
			if (selectedPlayer.GetComponent<Player> ().isZombiePlayer == false) {
				AttackSelectedZombie ();	
			} else {
				Debug.Log ("You don't have 2 moves");
			}
		}
	}

	int Distance(){
		int distance = 0;
		float playerPosX = selectedPlayer.transform.position.x;
		float playerPosZ = selectedPlayer.transform.position.z;
		float zombiePosX = gameObject.transform.position.x;
		float zombiePosZ = gameObject.transform.position.z;

		distance = Mathf.Abs ((int)(playerPosX - zombiePosX)) + Mathf.Abs ((int)(playerPosZ - zombiePosZ));

		return distance;
	}

	void AttackSelectedZombie(){
		int chanceToAttack = Random.Range (1, 13);
		int weaponId = PlayerWeaponType ();

		if (selectedPlayer.GetComponent<Player> ().moves > 1) {
			if (chanceToAttack <= (4 - weaponEfficiency) && InAttackRadius () == true) {
				Debug.Log ("Oops");
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 2;
			} else if (chanceToAttack < (11 - weaponEfficiency) && InAttackRadius () == true) {
				PushZombie ();
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			} else if (chanceToAttack >= (11 - weaponEfficiency) && InAttackRadius () == true) {
				KillZombie ();
				selectedPlayer.GetComponent<Player> ().moves = selectedPlayer.GetComponent<Player> ().moves - 1;
			} else {
				Debug.Log ("Distance > " + (2 + weaponRadius));
			}
		}
	}

	bool InAttackRadius(){
		if (Distance () <= (2 + weaponRadius)) {
			return true;
		}
		else {
			return false;
		}
	}

	int PlayerWeaponType(){
		int playerWeaponType = 0;

		for (int i = 0; i < weapons.Length; i++) {
			if (weapons [i].weaponType == selectedPlayer.GetComponent<Player> ().weaponType) {
				playerWeaponType = i;
				break;
			}
		}

		return playerWeaponType;
	}

	void SelectedZombie (){
		for (int i = 0; i < zombies.Count; i++) {
			if (zombies [i].name == gameObject.transform.parent.name) {
				selectedZombie = zombies [i];
				break;
			}
		}
	}

	void PushZombie(){
		float playerPosX = selectedPlayer.transform.position.x;
		float playerPosZ = selectedPlayer.transform.position.z;
		float zombiePosX = transform.position.x;
		float zombiePosZ = transform.position.z;
		List<Vector3> blockedTile = boardClass.BlockedTile ();

		if (playerPosX == zombiePosX) {
			Vector3 newZombiePos = new Vector3 (zombiePosX, 0, Mathf.Clamp(zombiePosZ + 1.0f, 0, 23.0f));
			int flag = 0;
			for (int i = 0; i < blockedTile.Count; i++) {
				if (newZombiePos == blockedTile [i]) {
					flag++;
					break;
				}
			}
			if (flag == 0) {
				selectedZombie.transform.position = newZombiePos;
				selectedZombie.GetComponent<Zombie> ().zPositionV = newZombiePos.x;
				selectedZombie.GetComponent<Zombie> ().zPositionH = newZombiePos.z;
				Debug.Log ("You push zombie");
			} else {
				Debug.Log (newZombiePos + "Obstacle prevented pushing zombie!!!");
			}
		}
		else if(playerPosZ == zombiePosZ) {
			Vector3 newZombiePos = new Vector3 (Mathf.Clamp(zombiePosX  + 1.0f, 0f, 19.0f), 0, zombiePosZ);
			int flag = 0;
			for (int i = 0; i < blockedTile.Count; i++) {
				if (newZombiePos == blockedTile [i]) {
					flag++;
					break;
				}
			}
			if (flag == 0) {
				selectedZombie.transform.position = newZombiePos;
				selectedZombie.GetComponent<Zombie> ().zPositionV = newZombiePos.x;
				selectedZombie.GetComponent<Zombie> ().zPositionH = newZombiePos.z;
				Debug.Log ("You push zombie");
			} else {
				Debug.Log (newZombiePos + "Obstacle prevented pushing zombie!!!");
			}
		}
		else if(Vector3.Distance(selectedPlayer.transform.position, transform.position) < 1.8f){
			Vector3 newZombiePos = new Vector3 (Mathf.Clamp(zombiePosX  + 1.0f, 0f, 19.0f), 0, Mathf.Clamp(zombiePosZ + 1.0f, 0, 23.0f));
			int flag = 0;
			for (int i = 0; i < blockedTile.Count; i++) {
				if (newZombiePos == blockedTile [i]) {
					flag++;
					break;
				}
			}
			if (flag == 0) {
				selectedZombie.transform.position = newZombiePos;
				selectedZombie.GetComponent<Zombie> ().zPositionV = newZombiePos.x;
				selectedZombie.GetComponent<Zombie> ().zPositionH = newZombiePos.z;
				Debug.Log ("You pushed zombie");
			} else {
				Debug.Log (newZombiePos + "Obstacle prevented pushing zombie!!!");
			}
		}
	}

	void KillZombie(){
		for (int i = 0; i < zombies.Count; i++) {
			if (zombies [i].name == gameObject.transform.parent.name) {
				zombies [i].SetActive (false);
				zombies.RemoveAt (i);
				break;
			}
		}
		Debug.Log ("You killed zombie");
	}
}
