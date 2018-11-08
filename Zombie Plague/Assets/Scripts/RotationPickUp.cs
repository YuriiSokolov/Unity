using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPickUp : MonoBehaviour {

	void Update () {
		gameObject.transform.Rotate (0f, 100f * Time.deltaTime, 0f);
	}
}
