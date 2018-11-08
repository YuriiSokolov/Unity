using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
	public void OnePC(){
		Application.LoadLevel (1);
	}
	public void Multiplayer(){
	}
	public void Settings(){
	}
	public void Exit(){
		Application.Quit();
	}
	public void BtnMenu(){
		Application.LoadLevel (0);
	}
}
