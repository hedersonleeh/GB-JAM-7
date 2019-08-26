using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressStartToMenu : MonoBehaviour {

	public PlayerController controller;
	
	// Update is called once per frame
	void Update () {
		if(controller.Buttom_Start)
		SceneScript.ChangeScene("MenuScene");
	}
}
