using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMEnu : MonoBehaviour {

	bool isActive = true;
	GameObject menu;

	void Start(){
		menu = GameObject.Find ("Menu");
		menu.SetActive(!isActive);
	}

	void Update(){
		if(Input.GetButtonDown("Cancel")){
			isActive = !isActive;
		}
		menu.SetActive (!isActive);
	}
}
