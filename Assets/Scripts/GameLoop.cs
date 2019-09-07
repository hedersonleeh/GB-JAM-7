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
    private bool once;

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
            if (!once)
            {
                once = true;
                Invoke("SpawnPlayer", 2f);
            }
        }
    }

    private void SpawnPlayer()
    {
        Player.gameObject.transform.position = SpawnPoint.transform.position;
        Player.Stacs.Healing(100 + Mathf.Abs(Player.Stacs.Life));
        Player.isAlive = true;
        Player.gameObject.SetActive(true);
        once = false;
    }

    void ChangeScene()
    {
        SceneScript.ChangeScene(NextScene);
    }
}
