
using UnityEngine;
using TMPro;

public class infoScript : MonoBehaviour
{
    [SerializeField] private TMP_Text buildingCounter;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text enemiesText;
    [SerializeField] private TMP_Text AliesText;
    [SerializeField] private SpawnScript spawnEnemies;
    private float Min = 0;

    [Tooltip("Max value that Variable can be to fill Image.")]
    private float Max;

    void Start()
    {
        Max = Buildings.ctr;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!GameLoop.GameOver)
        {
            int percentage = Mathf.RoundToInt(100 * Mathf.Clamp01(Mathf.InverseLerp(Min, Max, Buildings.ctr)));
            buildingCounter.text = string.Concat("Wave: ", SpawnScript.Round.ToString("D2"),
                                                "\nCASTLE  ", percentage, "%");
            moneyText.text = string.Concat("Gold: ", Money.money.ToString("D2"), "$");
            AliesText.text = string.Concat("Allies:  ", Character.ctr.ToString("D2"));
            enemiesText.text = string.Concat("Enemies: ", spawnEnemies.EnemiesPerWave.ToString("D2"));
            gameOverText.text = "";
        }
        else if (GameLoop.GameOver)
        {
            gameOverText.gameObject.SetActive(true);
            buildingCounter.text = moneyText.text = AliesText.text = enemiesText.text = "";
            gameOverText.text = "Game Over\n A Game by Hedersonleeh";
        }
    }
    public static void Display(float life, int def, float attack, float magic, float atkSpd)
    {
    }
    public static void Display(float life, int def, float attack, float magic)
    {

    }
    public static void Display(float life, int def)
    {
    }

}










