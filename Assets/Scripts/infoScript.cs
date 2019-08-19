
using UnityEngine;
using TMPro;

public class infoScript : MonoBehaviour {

	

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		
	}

	public static void Display(Structure str)
	{
		
		Debug.Log(str.StrLife);
		Debug.Log(str.StrAttack);
		Debug.Log(str.StrDefense);
		Debug.Log(str.StrMagic);
	}
}
