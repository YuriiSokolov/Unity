using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour {

	float vertical;
	float horizontal;
	float heightBtn;
	float rotateCamXBtn;
	float rotateCamYBtn;

	public Transform startPosition;

	public float camSpeed = 5.0f;
	public float rotateSpeed = 3.0f;
	float camRotationY;
	float camRotationX;
	float camRotationXmin = 0;
	float camRotationXmax = 90.0f;

	float v, h;
	float height;
	float tempHeight;
	float minHeight = 4.0f;
	float maxHeight = 20.0f;


	void Start () {
		transform.position = new Vector3(startPosition.position.x, startPosition.position.y, startPosition.position.z);
		height = startPosition.position.y;
		tempHeight = height;
		camRotationX = 90f;
		camRotationY = 0f;
	}
	

	void Update () {
		vertical = Input.GetAxis ("Vertical");
		horizontal = Input.GetAxis ("Horizontal");
		heightBtn = Input.GetAxis ("Mouse ScrollWheel");
		rotateCamYBtn = Input.GetAxis ("Rotate Camera Y");
		rotateCamXBtn = Input.GetAxis ("Rotate Camera X");

		//=====================================[Меняем позицию камеры]=====================================================
		//Смена координаты x 
		if (vertical > 0)
			v += 1.0f;
		else if (vertical < 0)
			v -= 1.0f;
		else v = 0;
		//Смена коордитаны z
		if (horizontal > 0)
			h += 1.0f;
		else if (horizontal < 0)
			h -= 1.0f;
		else h = 0;
		//Смена высоты (y)
		if(heightBtn > 0){
			if (height < maxHeight) tempHeight +=1;
		}
		if(heightBtn < 0){
			if (height > minHeight) tempHeight -=1; 
		}
		tempHeight = Mathf.Clamp(tempHeight, minHeight, maxHeight);
		height = Mathf.Lerp(height, tempHeight, Time.deltaTime);
		//Меняем нашу позициию
		Vector3 direction = new Vector3(h,v,0);
		transform.Translate(direction * camSpeed * Time.deltaTime); // смещаем наши координаты на 5;
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8, 28), height, Mathf.Clamp(transform.position.z, -8, 36)); // смещаем объект на новые координаты

		//==============================[Вращение камеры]==========================================
		//Вращение вокруг оси y
		if(rotateCamYBtn > 0) camRotationY -= rotateSpeed;
		if(rotateCamYBtn < 0) camRotationY += rotateSpeed;
		camRotationY = Mathf.Clamp(camRotationY, -360f, 360f);
		//Вращение вокруг оси x
		if(rotateCamXBtn > 0) camRotationX -= rotateSpeed;
		if(rotateCamXBtn < 0) camRotationX += rotateSpeed;
		camRotationX = Mathf.Clamp(camRotationX, camRotationXmin, camRotationXmax);
		//Вращаем камеру
		transform.rotation = Quaternion.Euler(camRotationX, camRotationY, 0);
	}
}
