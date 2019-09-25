using UnityEngine.SceneManagement;
using UnityEngine;
public class Resolution : MonoBehaviour
{

    [SerializeField] private Vector2Int mainResolution;
    private int i;
    public static Vector2Int currentResolution;
    void Awake()
    {

        DontDestroyOnLoad(gameObject);
        currentResolution = mainResolution;
        Screen.SetResolution(mainResolution.x, mainResolution.y, false);
        i = 2;
    }

    void Update()
    {
        if (Input.GetButtonDown("Resolution"))
        {
            if (i > 3)
            {
                i = 1;
                currentResolution = mainResolution;
            }
            Screen.SetResolution(currentResolution.x * Mathf.Clamp(i, 1, 4), currentResolution.y * Mathf.Clamp(i, 1, 4), false);
            i++;
        }
    }
}
