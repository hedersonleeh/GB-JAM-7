
using System.Collections;
using GBJAM7.Types;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterType typeOfCharacter;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private string characterName;
    [SerializeField] private float life;
    [SerializeField] private int def;
    [SerializeField] private float atk;
    [SerializeField] private float magic;
    [SerializeField] private float attackSpeed;


    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private ParticleSystem magicWeapon;
    [SerializeField] private Transform LaunchPos;
    private Rigidbody2D rb;

    private bool canInteract;
    private bool attacking;
    private bool interacting = false;
    public bool Interacting
    {
        get { return interacting; }
        set { interacting = value; }
    }
    public bool isAlive { get; private set; }

    BaseClass player;
    public BaseClass Stacs { get { return player; } }

    private bool once = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
        switch (typeOfCharacter)
        {
            case CharacterType.Player:
                player = new BaseClass(characterName, life, def, atk, magic, attackSpeed, WeaponType.Sword);
                break;

            case CharacterType.Builder:
                player = new BaseClass(characterName, life, def, WeaponType.Nothing);
                break;

            case CharacterType.Archers:
                player = new BaseClass(characterName, life, def, atk, magic, attackSpeed, WeaponType.Bow);
                break;

            case CharacterType.Warrios:
                player = new BaseClass(characterName, life, def, atk, magic, attackSpeed, WeaponType.Sword);
                break;

            case CharacterType.Wizards:
                player = new BaseClass(characterName, life, def, atk, magic, attackSpeed, WeaponType.Wand);
                break;
        }
    }
    private void Update()
    {
        if (player.Life <= 0)
        {
            if (!once)
            {
                once = true;
                Death();
            }
        }
        else
        {
            if (controller != null)
            {
                if (controller.Buttom_A)
                    if (!canInteract && !attacking)
                    {
                        Attack();
                    }
                    else if (canInteract)
                    {
                        Interacting = true;
                    }
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            rb.AddForce(new Vector2(other.transform.right.x * enemy.Stacs.Atk * 5, Vector2.up.y * 2 * enemy.Stacs.Atk));
            player.Damage(enemy.Stacs.StrAttack, def);
            player.DisplayStats();
        }
    }
    public void Attack()
    {
        StartCoroutine(AttackCooldown());
        // animator.SetTrigger("Attack");
        switch (player.Weapon)
        {
            case WeaponType.Bow:
                {
                    weaponPrefab.GetComponent<Weapon>().character = this;
                    Instantiate(weaponPrefab, LaunchPos.transform.position, Quaternion.identity);
                    break;
                }
                case WeaponType.Wand:
                {
                    magicWeapon.Play();
                    break;
                }
            default:
                {
                    animator.SetTrigger("Attack");
                    break;
                }
        }

    }
    public void Death()
    {
        isAlive = false;
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
