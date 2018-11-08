using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableTile : MonoBehaviour {

	float tileV;
	float tileH;
	GameObject board;
	Board boardClass;
	GameObject currentTile;

	void Start(){
		board = GameObject.FindWithTag ("GameBoard");
		boardClass = board.GetComponent<Board>();
	}

	void OnMouseUp() {
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			tileV = transform.position.x;
			tileH = transform.position.z;

			if (boardClass.selectedPlayer.GetComponent<Player> ().isZombiePlayer == false) {
				string goName = string.Format ("Cube_{1}_{0}", (boardClass.selectedPlayer.GetComponent<Player> ().positionV + 1).ToString (), 
					               (boardClass.selectedPlayer.GetComponent<Player> ().positionH + 1).ToString ());
				currentTile = GameObject.Find (goName);

				MovesRules (tileV, tileH, currentTile);
			} 
			else {
				string goName = string.Format ("Cube_{1}_{0}", (boardClass.selectedZombie.GetComponent<Zombie> ().zPositionV + 1).ToString (), 
					               (boardClass.selectedZombie.GetComponent<Zombie> ().zPositionH + 1).ToString ());
				currentTile = GameObject.Find (goName);

				ZombieMovesRules (tileV, tileH, currentTile);
			}
		}
	}

	//Подсчёт стоимости действия
	public int MovesCost(GameObject currentTile){
		int movesCost = 0;

		float ctX = currentTile.transform.position.x;
		float ctZ = currentTile.transform.position.z;
		float goX = gameObject.transform.position.x;
		float goZ = gameObject.transform.position.z;

		if (ctX != goX || ctZ != goZ) {
			movesCost = Mathf.Abs((int)(goX - ctX)) + Mathf.Abs((int)(goZ - ctZ));
			if (currentTile.layer == 0 && gameObject.layer == 8 && currentTile.tag == "Window") {
				movesCost++;
			} 
			else if (gameObject.layer == 0 && currentTile.layer == 8 && currentTile.tag == "Window") {
				movesCost++;
			} 
			else if (gameObject.tag == "Fence" && currentTile.tag == "FenceOut") {
				movesCost++;
			} 
			else if (gameObject.tag == "FenceOut" && currentTile.tag == "Fence") {
				movesCost++;
			}
			return movesCost;
		} 
		else {
			return 0;
		}
	}

	//Перемещаем выбраного игрока на выбраную позиции
	void MoveSelectedPlayerTo(float v, float h, GameObject currentTile)
	{
		int tempMoves = boardClass.selectedPlayer.GetComponent<Player>().moves;
		if(MovesCost(currentTile) <= tempMoves && tempMoves != 0)
		{
			boardClass.selectedPlayer.GetComponent<Player> ().positionV = v;
			boardClass.selectedPlayer.GetComponent<Player> ().positionH = h;
			Vector3 newPos = new Vector3 (v, 0, h);
			boardClass.selectedPlayer.transform.position = newPos;
			boardClass.selectedPlayer.GetComponent<Player> ().moves = 
				boardClass.selectedPlayer.GetComponent<Player> ().moves - MovesCost(currentTile);
		}
		else
		{
			Debug.Log ("Your way route is too big");
		}
	}

	//правила передвижения (проверяем можно ли двигатся на выбраную клетку)
	void MovesRules(float v, float h, GameObject currentTile){
		if (boardClass.selectedPlayer.GetComponent<Player> ().moves <= 0) {
			Debug.Log ("Your moves ended");
		} else {
			if (gameObject.tag == "Block") {
				Debug.Log ("Is blocked tile");
			} 
			else {
				// layer == 0 is Default layer layer == 8 is Build layer
				if (currentTile.layer == 0 && gameObject.layer == 8) {
					if (currentTile.tag == "Window" || currentTile.tag == "Door") {
						Debug.Log ("You can move (Window or Door)");
						MoveSelectedPlayerTo (v, h, currentTile);		
					} else {
						Debug.Log ("You can't moves through the wall");
					}
				} else if (gameObject.layer == 0 && currentTile.layer == 8) {
					if (currentTile.tag == "Window" || currentTile.tag == "Door") {
						Debug.Log ("You can move (Window or Door)");
						MoveSelectedPlayerTo (v, h, currentTile);
					} else {
						Debug.Log ("You can't moves through the wall");
					}
				} else {
					Debug.Log ("You can move (not Wall)");
					MoveSelectedPlayerTo (v, h, currentTile);
				}
			}
		}
	}

	//Перемещаем выбраного зомби на выбраную клетку 
	//(функция не отличаются от функции MoveSelectedPlayerTo просто переписано под компонент Zombie вместо Player)
	void ZombieMoveSelectedPlayerTo(float v, float h, GameObject currentTile)
	{
		int tempMoves = boardClass.selectedZombie.GetComponent<Zombie> ().zMoves;
		if(MovesCost(currentTile) <= tempMoves && tempMoves != 0)
		{
			boardClass.selectedZombie.GetComponent<Zombie> ().zPositionV = v;
			boardClass.selectedZombie.GetComponent<Zombie> ().zPositionH = h;
			boardClass.selectedZombie.transform.position = new Vector3 (v, 0, h);
			boardClass.selectedZombie.GetComponent<Zombie> ().zMoves = 
				boardClass.selectedZombie.GetComponent<Zombie> ().zMoves - MovesCost(currentTile);
		}
		else
		{
			Debug.Log ("Your way route is too big");
		}
	}

	//Правила перемещения зомби (правила не отличаются от правил MovesRules просто переписано под компонент Zombie вместо Player)
	void ZombieMovesRules(float v, float h, GameObject currentTile){
		if (boardClass.selectedZombie.GetComponent<Zombie> ().zMoves <= 0) {
			Debug.Log ("Your moves ended");
		} 
		else {
			if (gameObject.tag == "Block") {
				Debug.Log ("Is blocked tile");
			} 
			else {
				// layer == 0 is Default layer layer == 8 is Build layer
				if (currentTile.layer == 0 && gameObject.layer == 8) {
					if (currentTile.tag == "Window" || currentTile.tag == "Door") {
						Debug.Log ("You can move (Window or Door)");
						ZombieMoveSelectedPlayerTo (v, h, currentTile);		
					} 
					else {
						Debug.Log ("You can't moves through the wall");
					}
				} 
				else if (gameObject.layer == 0 && currentTile.layer == 8) {
					if (currentTile.tag == "Window" || currentTile.tag == "Door") {
						Debug.Log ("You can move (Window or Door)");
						ZombieMoveSelectedPlayerTo (v, h, currentTile);
					} 
					else {
						Debug.Log ("You can't moves through the wall");
					}
				} 
				else {
					Debug.Log ("You can move (not Wall)");
					ZombieMoveSelectedPlayerTo (v, h, currentTile);
				}
			}
		}
	}
}

