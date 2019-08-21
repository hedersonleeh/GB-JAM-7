
using GBJAM7.Types;
using UnityEngine;


public class Character : MonoBehaviour
{
    [SerializeField] private CharacterType typeOfCharacter;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private string characterName;
    [SerializeField] private float life;
    [SerializeField] private int def;
    [SerializeField] private float atk;
    [SerializeField] private float magic;
    [SerializeField]private float attackSpeed;


    BaseClass player;
    // Use this for initialization
    void Start()
    {
        switch (typeOfCharacter)
        {
            case CharacterType.Player:
                player = new BaseClass(characterName, life, def, atk, magic,attackSpeed, WeaponType.Sword);
                break;

            case CharacterType.Builder:
                player = new BaseClass(characterName, life, def, WeaponType.Nothing);
                break;

            case CharacterType.Archers:
                player = new BaseClass(characterName, life, def, atk, magic,attackSpeed, WeaponType.Bow);
                break;

            case CharacterType.Warrios:
                player = new BaseClass(characterName, life, def, atk, magic,attackSpeed, WeaponType.Sword);
                break;

            case CharacterType.Wizards:
                player = new BaseClass(characterName, life, def, atk, magic,attackSpeed, WeaponType.Wand);
                break;
        }
    }
     public void Attack(float attackDmg,float attackRange,Animator animator)
    {
        if(Physics2D.Raycast(transform.position,Vector2.right,attackRange,whatIsEnemy))
        {
            Structure str = GetComponent<Structure>();
            animator.SetTrigger("Attack");
            float dmgTotal =Mathf.Abs(str.StrDefense*0.6f-attackDmg); 
            str.Damage(dmgTotal);
        }
    }
    public void Death(Animator animator)
    {
        animator.Play("Death");
        Destroy(gameObject,2f);
    }

    /* public void UpdateStats()
    {
        characterName = player.Name;
        life = player.Life;
        def = player.Def;
        atk = magic;
    }*/
}
