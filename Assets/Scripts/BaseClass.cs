using GBJAM7.Types;
using UnityEngine;
public class BaseClass : Structure
{
    public string Name { get; private set; }
    public float Life { get; private set; }
    public int Def { get; private set; }
    public float Atk { get; private set; }
    public float AtkSpeed { get; private set; }
    public float Magic { get; private set; }
    public WeaponType Weapon { get; private set; }
    public BaseClass(string name, float life, int def, float attack, float magic, float atkSpd, WeaponType weapon) : base(life, def, attack, magic)
    {
        Name = name == "" ? "Defender" : name;
        Life = life;
        Def = def;
        Atk = attack;
        Magic = magic;
        Weapon = weapon;
        AtkSpeed = atkSpd;
    }
    public BaseClass(float life, int def, float attack, float magic, float atkSpd, WeaponType weapon) : base(life, def, attack, magic)
    {
        Life = life;
        Def = def;
        Atk = attack;
        Magic = magic;
        Weapon = weapon;
        AtkSpeed = atkSpd;
    }
    public BaseClass(string name, float life, int def, float attack, float atkSpd, WeaponType weapon) : base(life, def, attack)
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
    public BaseClass(string name, float life, int def, float attack, float atkSpd) : base(life, def, attack)
    {
        Life = life;
        Def = def;
        Atk = attack;
        AtkSpeed = atkSpd;
    }
    public BaseClass(string name, float life, int def) : base(life, def)
    {
        Life = life;
        Def = def;
    }
    public override void Damage(float amount, int def)
    {
        float totalDamage;
        totalDamage = Mathf.Abs((def * 0.4f) - amount);
        Life -= totalDamage;
    }
   
    public override void Healing(float amount)
    {
       Life += amount;
    }
    public override void DisplayStats()
    {
        infoScript.Display(Life,Def,Atk,Magic,AtkSpeed);
    }
}
