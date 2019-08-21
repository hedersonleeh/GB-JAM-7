using GBJAM7.Types;
using UnityEngine;

public class Buildings : MonoBehaviour
{

    private BaseClass building;
    [SerializeField] private string buildingName;
    [SerializeField] private BuildingType type;
    [SerializeField] private float life;
    [SerializeField] private int def;
    [SerializeField] private float atk;
    [SerializeField] private float attackSpeed;

    void Start()
    {
        switch (type)
        {
            case BuildingType.House:
            case BuildingType.BuildersHouse:
            case BuildingType.Gate:
			case BuildingType.Castle:
                {
                    building = new BaseClass(buildingName, life, def);
                    break;
                }
           default:
                building = new BaseClass(buildingName, life, def,atk,attackSpeed);
                break;
            

            
	    }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
