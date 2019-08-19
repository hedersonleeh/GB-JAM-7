
using GBJAM7.Types;
using UnityEngine;


public class Character : MonoBehaviour
{
    [SerializeField] private CharacterType typeOfCharacter;
    [SerializeField] private string characterName;
    [SerializeField] private float life;
    [SerializeField] private int def;
    [SerializeField] private float atk;
    [SerializeField] private float magic;

    Human player;
    // Use this for initialization
    void Start()
    {
        switch (typeOfCharacter)
        {
            case CharacterType.Player:
                player = new Human(characterName, life, def, atk, magic, WeaponType.Sword);
                break;

            case CharacterType.Builder:
                player = new Human(characterName, life, def, WeaponType.Nothing);
                break;

            case CharacterType.Archers:
                player = new Human(characterName, life, def, atk, magic, WeaponType.Bow);
                break;

            case CharacterType.Warrios:
                player = new Human(characterName, life, def, atk, magic, WeaponType.Sword);
                break;

            case CharacterType.Wizards:
                player = new Human(characterName, life, def, atk, magic, WeaponType.Wand);
                break;
        }
    }
    public void UpdateStats()
    {
        characterName = player.Name;
        life = player.Life;
        def = player.Def;
        atk = magic;
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            player.DisplayStats();
        }

    }
    private void OnDamageTaking()
    {
        player.DisplayStats();
    }





}
