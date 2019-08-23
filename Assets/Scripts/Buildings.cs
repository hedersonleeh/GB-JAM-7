using System;
using System.Collections;
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
    private bool attacking;
    private Animator animator;
    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private Transform LaunchPos;
    [SerializeField] private Transform secondLaunchPos;
    private bool inRange;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask whaIsEnemy;

    public BaseClass Stacs { get { return building; } }
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
                building = new BaseClass(buildingName, life, def, atk, attackSpeed);
                break;
        }
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
                        weaponPrefab.GetComponent<Weapon>().building = this;
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
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Comprobator"))
        {
          Debug.Log("DESTRUCTION");
          Destroy(gameObject);
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
