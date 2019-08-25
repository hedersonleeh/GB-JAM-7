
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class infoScript : MonoBehaviour
{
    [SerializeField] TMP_Text buildingCounter;
    [SerializeField] TMP_Text moneyText;
    
    private float Min = 0;

    [Tooltip("Max value that Variable can be to fill Image.")]
    private float Max;

    void Start()
    {
        Max = Buildings.ctr;
    }

    // Update is called once per frame
    void Update()
    {
        buildingCounter.text = string.Concat("Round  ",SpawnScript.Round,"\nCASTLE  ",Mathf.RoundToInt(100*Mathf.Clamp01(Mathf.InverseLerp(Min, Max, Buildings.ctr))),"%");

        moneyText.text =string.Concat("Gold: ","$",Money.money.ToString("D2"),"E: ",Enemy.ctr);
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










