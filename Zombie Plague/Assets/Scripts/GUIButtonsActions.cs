using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIButtonsActions : MonoBehaviour {

	public GameObject cacheInventory;
	bool isActive = true;
	GameObject board;
	Board boardClass;
	Player selectedPlayer;
	GameEnd gameEndClass;
	int currentHp;
	int moves;

	public Image[] hearts;
	public Sprite heartSprite;
	public Sprite emptyHeartSprite;
	public Text countMoves;
	public float humanPlayerTime = 90.0f;
	public float zombiePlayerTime = 360.0f;
	public Text minutesCount;
	public Text secondsCount;
	public Text maxWeight;
	public Text currentWeight;

	void Start(){
		board = GameObject.FindWithTag ("GameBoard");
		boardClass = board.GetComponent<Board>();
		gameEndClass = board.GetComponent<GameEnd> ();
	}

	void Update(){
		selectedPlayer = boardClass.selectedPlayer.GetComponent<Player> ();
		currentHp = selectedPlayer.currentHP;
		moves = selectedPlayer.moves;
		if (selectedPlayer.moves == 0) {
			cacheInventory.SetActive (false);
		}
		if (selectedPlayer.isZombiePlayer == false) {
			humanPlayerTime = humanPlayerTime - Time.deltaTime;
			TimeCountDown (humanPlayerTime);
		} 
		else {
			zombiePlayerTime = zombiePlayerTime - Time.deltaTime;
			TimeCountDown (zombiePlayerTime);
		}
		HeartsCount ();
		MovesCount ();
		BagInfo ();
	}

	public void ButtonSearch(){
		cacheInventory.SetActive (isActive);
		isActive = !isActive;
	}

	public void ButtonX(){
		cacheInventory.SetActive (isActive);
		isActive = !isActive;
	}

	public void ButtonMenu(){
		Application.LoadLevel (0);
	}

	void HeartsCount(){
		for (int i = 0; i < hearts.Length; i++) {
			if (i < (currentHp - 1)) {
				hearts [i].sprite = heartSprite;
			} 
			else {
				hearts [i].sprite = emptyHeartSprite;
			}
			if (selectedPlayer.isZombiePlayer == false) {
				hearts [i].enabled = true;
			} 
			else {
				hearts [i].enabled = false;
			}
		}
	}

	void MovesCount(){
		countMoves.text = moves.ToString ();
	}

	//Функция для кнопки EndRound
	public void EndRoundBtn(){
		boardClass.endRound = !boardClass.endRound;
		if (isActive == true) {
			isActive = !isActive;
			cacheInventory.SetActive (isActive);
		}
	}

	//Управления таймером
	public void TimeCountDown(float currentTime){
		int minutes = Mathf.FloorToInt (currentTime / 60);
		int seconds = Mathf.RoundToInt (currentTime % 60);

		if (seconds == 60) {
			seconds = 0;
			minutes += 1;
		}

		minutesCount.text = minutes.ToString ();
		secondsCount.text = seconds.ToString ("00");

		if (currentTime < 0) {
			boardClass.endRound = true;
		}
	}

	//Зайти в машину
	public void EnterTheCar(){
		GameObject player;
		GameObject[] players;
		players = boardClass.players;
		player = boardClass.selectedPlayer;
		if (selectedPlayer.moves >= 2) {
			for (int i = 0; i < players.Length; i++) {
				if (player == players [i]) {
					gameEndClass.inCar [i] = true;
					player.SetActive (false);
					break;
				}
			}
			selectedPlayer.moves = selectedPlayer.moves - 2;
		} 
		else {
			Debug.Log ("You don't have 2 moves");
		}
	}

	//Выйти с машины
	public void GetOffTheCar(){
		GameObject player;
		player = boardClass.selectedPlayer;
		if (selectedPlayer.moves >= 2) {
			player.SetActive (true);
			selectedPlayer.moves = selectedPlayer.moves - 2;
		} 
		else {
			Debug.Log ("You don't have 2 moves");
		}
	}

	//Уехать
	public void ToLeave(){
		gameEndClass.leave = true;
	}

	//Отображение веса инвентаря
	void BagInfo(){
		maxWeight.text = selectedPlayer.maxInventoryWeight.ToString ();
		currentWeight.text = selectedPlayer.currentInventoryWeight.ToString ();
	}
}
