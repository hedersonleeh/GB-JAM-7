using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour {

		// Use this for initialization
	void Awake () {
		Screen.SetResolution(160*4,144*4,false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
