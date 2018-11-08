using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour {
	public float positionV;
	public float positionH;
	public int maxMoves = 4;
	public int moves = 4;
	public bool isSelected = false;
	public int maxHp = 5;
	public int currentHP = 5;
	public int maxInventoryWeight = 5;
	public int currentInventoryWeight = 0;
	public bool isZombiePlayer = false;
	public List<Thing> inventory;
	public int weaponType = 0; // 0 - без оружия, 
	public bool usingDrugs = false;
}
