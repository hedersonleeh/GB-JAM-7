using GBJAM7.Types;
using UnityEngine;
public class BaseClass : Structure
{
    public string Name { get; private set; }
    public float Life
    {
        get
        {
            return Life;
        }
        private set
        {
           Life = Mathf.Clamp(value, 0, 100);
        }
    }
    public int Def { get; private set; }
    public float Atk { get; private set; }
    public float AtkSpeed { get; private set; }
    public float Magic { get; private set; }
    public WeaponType Weapon { get; private set; }
    public BaseClass(string name, float life, int def, float attack, float magic,float atkSpd, WeaponType weapon) : base(life, def, attack, magic)
    {
        Name = name == "" ? "Defender" : name;
        Life = life;
        Def = def;
        Atk = attack;
        Magic = magic;
        Weapon = weapon;
        AtkSpeed = atkSpd;
    }
    public BaseClass(float life, int def, float attack, float magic,float atkSpd, WeaponType weapon) : base(life, def, attack, magic)
    {
        Life = life;
        Def = def;
        Atk = attack;
        Magic = magic;
        Weapon = weapon;
        AtkSpeed = atkSpd;
    }
    public BaseClass(string name, float life,int def,float attack,float atkSpd,WeaponType weapon) : base(life, def,attack)
    {
        Life = life;
        Def = def;
        Atk = attack;
        Weapon = weapon;
        AtkSpeed = atkSpd;
    }
    public BaseClass(string name, float life, int def, WeaponType weapon) : base(life, def)
    {
        Life = life;
        Def = def;
        Weapon = weapon;
    }
    public BaseClass(string name, float life, int def,float attack,float atkSpd) : base(life, def,attack)
    {
        Life = life;
        Def = def;
        Atk = attack;
        AtkSpeed = atkSpd;
    }
     public BaseClass(string name, float life, int def ) : base(life, def)
    {
        Life = life;
        Def = def;
    }
    public override float Damage(float amount)
    {
        return Life -= amount;
    }
    public override float Healing(float amount)
    {
        return Life += amount;
    }
    public override void DisplayStats()
    {
        infoScript.Display(this);
    }
}
