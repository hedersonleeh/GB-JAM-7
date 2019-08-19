
public abstract class Structure
{
    private float life;
    private int defense;
    private float attack;
    private float magic;

    public float StrLife { get { return life; } }

    public int StrDefense { get { return defense; } }
    public float StrAttack { get { return attack; } }

    public float StrMagic { get { return magic; } }

    public Structure(float life, int def, float attack, float magic)
    {
        this.life = life;
        this.defense = def;
        this.attack = attack;
        this.magic = magic;
    }
    public Structure(float life, int def)
    {
        this.life = life;
        this.defense = def;
    }
    public abstract float Damage(float amount);
    public abstract float Healing(float amount);
    public abstract void DisplayStats();
}

