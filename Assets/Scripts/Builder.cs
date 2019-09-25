using TMPro;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private GameObject commandPanel;
    [SerializeField] private Character[] characters;
    [SerializeField] private Buildings[] buildings;
    [SerializeField] private Transform[] objectsPos;
    [SerializeField] private Transform[] uiOptions;
    [SerializeField] private GameObject pointer;
    [SerializeField] private Character player;
    [SerializeField] private PlayerController controller;
    [SerializeField] TMP_Text charactersText;
    [SerializeField] TMP_Text buildingsText;
    [SerializeField] TMP_Text lifeText;
    [SerializeField] TMP_Text defText;
    [SerializeField] TMP_Text atkText;


    private int i = 0;
    private int characterCounter = 0;

    private int buildingsCounter = 0;
    private bool pressedV;
    private bool pressedH;

    public string currentNameOfObject { get; private set; }
    private void Start()
    {
        player.Interacting = false;
    }
    private void Update()
    {
        if (controller != null)
        {
            PlayerInteract();

            if (player.Interacting)
            {
                MoveInVertical();
                switch (i)
                {
                    case 0:
                        {
                            MoveInHorizontal(characters, ref characterCounter);
                            UpdateText(characters[characterCounter]);
                            charactersText.text = string.Concat(characters[characterCounter].name + " $",
                                                                 (characters[characterCounter].Price));
                            if (controller.Buttom_A && Money.SpendMoney(characters[characterCounter].Price))
                            {
                                Vector3 offset = new Vector3(transform.position.x, transform.position.y, 0);
                                Instantiate(characters[characterCounter].gameObject, offset, Quaternion.identity);

                            }
                            break;
                        }
                    case 1:
                        {
                            MoveInHorizontal(buildings, ref buildingsCounter);
                            UpdateText(buildings[buildingsCounter]);
                            buildingsText.text = string.Concat(buildings[buildingsCounter].name, " $",
                                                                (buildings[buildingsCounter].BuildingPrice));
                            if (controller.Buttom_A && ChecksBuildings.CanBuild && Money.SpendMoney(buildings[buildingsCounter].BuildingPrice))
                            {
                                Instantiate(buildings[buildingsCounter],
                                                         new Vector2(transform.position.x,
                                                          buildings[buildingsCounter].transform.position.y),
                                                          Quaternion.identity);
                            }
                            break;
                        }
                }
            }
        }
    }
    private void MoveInHorizontal(object[] options, ref int counter)
    {
        if (controller.Horizontal < 0 && !pressedH)
        {
            counter = counter - 1 < 0 ? options.Length - 1 : --counter;
            pressedH = true;
        }
        if (controller.Horizontal > 0 && !pressedH)
        {
            counter = counter + 1 >= options.Length ? 0 : ++counter;
            pressedH = true;
        }
        else if (controller.Horizontal == 0)
        {
            pressedH = false;
        }
    }

    private void MoveInVertical()
    {

        if (controller.Vertical < 0 && !pressedV)
        {
            i = i + 1 >= uiOptions.Length ? 0 : ++i;
            pressedV = true;
        }
        if (controller.Vertical > 0 && !pressedV)
        {
            i = i - 1 < 0 ? uiOptions.Length - 1 : --i;
            pressedV = true;
        }
        else if (controller.Vertical == 0)
        {
            pressedV = false;
        }
        pointer.transform.position = uiOptions[i].transform.position;
    }
    
    void UpdateText(Character baseClass)
    {
        atkText.text = Mathf.RoundToInt(baseClass.Atk).ToString("D3");
        defText.text = Mathf.RoundToInt(baseClass.Def).ToString("D3");
        lifeText.text = Mathf.RoundToInt(baseClass.Life).ToString("D3");
        currentNameOfObject = baseClass.name;
    }
    void UpdateText(Buildings baseClass)
    {
        atkText.text = Mathf.RoundToInt(baseClass.Atk).ToString("D3");
        defText.text = Mathf.RoundToInt(baseClass.Def).ToString("D3");
        lifeText.text = Mathf.RoundToInt(baseClass.Life).ToString("D3");
        currentNameOfObject = baseClass.name;
    }
    private void PlayerInteract()
    {
        if (controller.Buttom_Select)
        {
            player.Interacting = true;
        }
        if (controller.Buttom_B)
        {
            player.Interacting = false;
        }
        commandPanel.SetActive(player.Interacting);

    }
}

