using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Thing{
	public string name;
	public string type;
	public string description;
	public int weight;
	public int radius;
	public Sprite thingSprite;
	public GameObject thingPrefab;
	public int movesCost;
	public bool charged = true;
}
