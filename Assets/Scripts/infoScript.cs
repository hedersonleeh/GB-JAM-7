
using UnityEngine;
using TMPro;

public class infoScript : MonoBehaviour {

	

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		
	}
	public static void Display(float life,int def,float attack,float magic,float atkSpd)
	{
		Debug.Log(life);
		Debug.Log(def);
		Debug.Log(attack);
		Debug.Log(magic);
		Debug.Log(atkSpd);
	}public static void Display(float life,int def,float attack,float magic)
	{
		Debug.Log(life);
		Debug.Log(def);
		Debug.Log(attack);
		Debug.Log(magic);
	}
	public static void Display(float life,int def)
	{
		Debug.Log(life);
		Debug.Log(def);
	}
}










