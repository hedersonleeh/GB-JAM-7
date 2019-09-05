using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneScript : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
        Money.money = 0;
    }
}
