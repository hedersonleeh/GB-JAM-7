using GBJAM7.Types;
using UnityEngine;

public class Weapon : MonoBehaviour

{
    public Character character;
    Rigidbody2D rb;
    [SerializeField] WeaponType types;
    [SerializeField] float lifeTime = 2f;
    [SerializeField] float speed = 2f;

    private bool once = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        switch (types)
        {
            case WeaponType.Bow:
                {
                    if (lifeTime <= 0)
                    {
						Destroy(gameObject);
                    }
                    else
                    {
                        {
                            rb.gravityScale = .3f;
                            if (!once)
                            {
                                Debug.Log("pass");
                                once = true;
                                rb.AddForce(new Vector2(character.transform.right.x * -speed * 10 * Time.deltaTime, Vector2.up.y * 10 * speed * Time.deltaTime));
                            }
                            lifeTime -= Time.deltaTime;
                        }
                    }
                    break;
                }
            case WeaponType.Axe:
            case WeaponType.Dagger:
            case WeaponType.Sword:
            default:
                break;

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (types)
        {
            case WeaponType.Bow:
                {
                    if (other.gameObject.CompareTag("Enemy"))
                    {
                        Destroy(gameObject);
                    }
                    break;
                }
			case WeaponType.Axe:
            case WeaponType.Dagger:
            case WeaponType.Sword:
            default:
                break;
        }

    }
}

