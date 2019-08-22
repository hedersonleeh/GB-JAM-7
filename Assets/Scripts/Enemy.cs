using GBJAM7.Types;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{

    private BaseClass enemy;
    [SerializeField] private string enemyName;
    [SerializeField] private EnemyType type;
    [SerializeField] private WeaponType weapon;
    [SerializeField] private float life;
    [SerializeField] private int def;
    [SerializeField] private float atk;
    [SerializeField] private float attackSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] Animator animator;
    private bool once = false;

    public BaseClass Stacs { get { return enemy; } }



    // Use this for initialization
    void Start()
    {

        switch (type)
        {
            case EnemyType.Skull:
                {
                    enemy = new BaseClass(enemyName, life, def, atk, attackSpeed, WeaponType.Nothing);
                    break;
                }
            case EnemyType.Goblin:
                {
                    enemy = new BaseClass(enemyName, life, def, atk, attackSpeed, WeaponType.Dagger);
                    break;
                }
            case EnemyType.Troll:
                {
                    enemy = new BaseClass(enemyName, life, def, atk, attackSpeed, WeaponType.Axe);
                    break;
                }
            case EnemyType.Gigant:
                {
                    enemy = new BaseClass(enemyName, life, def, atk, attackSpeed, WeaponType.Nothing);
                    break;
                }
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }
    private void LateUpdate()
    {
        if (enemy.Life <= 0)
            if (!once)
            {
                once = true;
                Death();
                //Animator.SetTrigger("Death");
            }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        {
            if (other.gameObject.CompareTag("Weapon"))
            {
                Character character = other.gameObject.GetComponent<Weapon>().character;
                rb.AddForce(new Vector2(other.transform.right.x *character.Stacs.StrAttack, Vector2.up.y * 2));
                enemy.Damage(character.Stacs.StrAttack, def);
                enemy.DisplayStats();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            if (other.gameObject.CompareTag("Weapon"))
            {
                Character character = other.gameObject.GetComponent<Weapon>().character;
                rb.AddForce(new Vector2(other.transform.right.x * character.Stacs.Atk, Vector2.up.y * 10));
                enemy.Damage(character.Stacs.StrAttack, def);
                enemy.DisplayStats();
            }
        }

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
           
            Character character = other.gameObject.GetComponentInParent<Character>();
            rb.AddForce(new Vector2(other.transform.right.x * -10, Vector2.up.y * 10));
            enemy.Damage(character.Stacs.StrMagic, def);
            enemy.DisplayStats();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}