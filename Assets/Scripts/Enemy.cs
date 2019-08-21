using GBJAM7.Types;
using UnityEngine;

public class Enemy : MonoBehaviour {

private BaseClass enemy;
    [SerializeField] private string enemyName;
    [SerializeField] private EnemyType type;
    [SerializeField] private WeaponType weapon;
    [SerializeField] private float life;
    [SerializeField] private int def;
    [SerializeField] private float atk;
    [SerializeField] private float attackSpeed;

	// Use this for initialization
	void Start ()
	{
		switch (type)
		{
			case EnemyType.Skull:
			{
				enemy = new BaseClass(enemyName,life,def,atk,attackSpeed,WeaponType.Nothing);
				break;
			}
			case EnemyType.Goblin:
			{
				enemy = new BaseClass(enemyName,life,def,atk,attackSpeed,WeaponType.Dagger);
				break;
			}
			case EnemyType.Troll:
			{
				enemy = new BaseClass(enemyName,life,def,atk,attackSpeed,WeaponType.Axe);
				break;
			}
			case EnemyType.Gigant:
			{
				enemy = new BaseClass(enemyName,life,def,atk,attackSpeed,WeaponType.Nothing);
				break;
			}
		}
	}
	
}
