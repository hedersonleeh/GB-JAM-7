using GBJAM7.Types;
public class Human : Structure
{
    public string Name { get; private set; }
    public float Life { get; private set; }
    public int Def { get; private set; }
    public float Atk { get; private set; }
    public float Magic { get; private set; }
    public WeaponType Weapon { get; private set; }
    public Human(string name, float life, int def, float attack, float magic, WeaponType weapon) : base(life, def, attack, magic)
    {
        Name = name == "" ? "Defender":name;
        Life = life;
        Def = def;
        Atk = attack;
        Magic = magic;
        Weapon = weapon;

    }
    public Human(float life, int def, float attack, float magic, WeaponType weapon) : base(life, def, attack, magic)
    {
        Life = life;
        Def = def;
        Atk = attack;
        Magic = magic;
        Weapon = weapon;

    }
    public Human(string name, float life, int def, WeaponType weapon) : base(life, def)
    {
        Life = life;
        Def = def;
        Weapon = weapon;

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
