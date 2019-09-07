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

                    if (rb.position.y >= -.25f)
                    {
                        if (rb.velocity.y > 0)
                            transform.rotation = Quaternion.Euler(0, 0, -45);
                        else if (rb.velocity.y < 0)
                            transform.rotation = Quaternion.Euler(0, 0, 45);
                    }

                    rb.gravityScale = .3f;
                    if (!once)
                    {
                        once = true;
                        if (character != null)
                            rb.AddForce(new Vector2(character.transform.right.x * -speed * 10 * Time.deltaTime, Vector2.up.y * 10 * speed * Time.deltaTime));
                        else
                        {
                            rb.AddForce(new Vector2(transform.right.x * -speed * 10 * Time.deltaTime, Vector2.up.y * 10 * speed * Time.deltaTime));
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
                    //    if (other.gameObject.GetComponent<Enemy>() != null)
                    Destroy(gameObject);
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

