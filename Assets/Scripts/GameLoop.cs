using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    //[SerializeField]CinemachineVirtualCamera camera;
    private static bool gameOver;
    [SerializeField] string NextScene;
    [SerializeField] Character Player;
    [SerializeField] Buildings Castle;

    public static bool GameOver { get { return gameOver; } }
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Castle.Stacs.Life <= 0)
        {
            Invoke("ChangeScene", 5f);
            gameOver = true;
        }
    }
    private void LateUpdate()
    {
        if (Player.Stacs.Life <= 0)
        {
           Invoke("SpawnPlayer",2f);
        }
    }

    private void SpawnPlayer()
    {
        Player.gameObject.transform.position = SpawnPoint.transform.position;
        Player.Stacs.Healing(100);
        Player.isAlive = true;
        Player.gameObject.SetActive(true);
    }

    void ChangeScene()
    {
	SceneScript.ChangeScene(NextScene);
	    }
}
