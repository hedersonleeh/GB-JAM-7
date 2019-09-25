
using System.Collections;
using GBJAM7.Types;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    public static int ctr = 0;
    private BaseClass building;
    [SerializeField] private string buildingName;
    [SerializeField] private BuildingType type;
    [SerializeField] private float life;
    [SerializeField] private int def;
    [SerializeField] private float atk;
    [SerializeField] private float attackSpeed;
    [SerializeField] private int buildingPrice;
    private bool attacking;
    private Animator animator;
    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private Transform LaunchPos;
    [SerializeField] private Transform secondLaunchPos;
    private bool inRange;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask whaIsEnemy;

    public BaseClass Stacs { get { return building; } }

    public float Life { get { return life; } }

    public int Def { get { return def; } }
    public float Atk { get { return atk; } }

    public int BuildingPrice { get { return buildingPrice; } }
    RaycastHit2D ray;
    private bool once = false;

    void Awake()
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
                //    ctr++;
                building = new BaseClass(buildingName, life, def, atk, attackSpeed);
                break;
        }
    }
    private void OnEnable()
    {
        ctr++;
    }
    private void OnDestroy()
    {
        if (ctr < 0)
            ctr = 0;
        else
            ctr--;
        if (FindObjectOfType<AudioManager>() != null)
            FindObjectOfType<AudioManager>().Play("BuildingDead");
    }
    private void FixedUpdate()
    {
        switch (type)
        {
            case BuildingType.House:
            case BuildingType.BuildersHouse:
            case BuildingType.Gate:
            case BuildingType.Castle:
                break;
            case BuildingType.Tower:
                {
                    if (Physics2D.Raycast(new Vector2(transform.position.x, -0.18f), -transform.right, distance, whaIsEnemy))
                    {
                        inRange = true;
                        Attack();
                    }
                    else
                    {
                        inRange = false;
                    }
                    break;
                }

        }

    }
    public void Attack()
    {
        if (!attacking && inRange)
        {
            StartCoroutine(AttackCooldown());
            // animator.SetTrigger("Attack");
            switch (type)
            {
                case BuildingType.Tower:
                    {
                        Instantiate(weaponPrefab, LaunchPos.transform.position, Quaternion.identity);
                        Instantiate(weaponPrefab, secondLaunchPos.transform.position, Quaternion.identity);
                        break;
                    }

                case BuildingType.House:
                case BuildingType.BuildersHouse:
                case BuildingType.Gate:
                case BuildingType.Castle:
                default:
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            building.Damage(enemy.Stacs.StrAttack, def);
            building.DisplayStats();
        }
    }

    private void LateUpdate()
    {
        if (building.Life <= 0)
            if (!once)
            {
                once = true;
                Death();
                //Animator.SetTrigger("Death");
            }

    }
    public void Death()
    {
        Destroy(gameObject);
        // animator.Play("Death");
    }
    IEnumerator AttackCooldown()
    {
        attacking = true;
        yield return new WaitForSeconds(attackSpeed);
        attacking = false;
    }

}
