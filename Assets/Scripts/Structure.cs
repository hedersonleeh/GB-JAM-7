
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
    public Structure(float life, int def, float attack)
    {
        this.life = life;
        this.defense = def;
        this.attack = attack;
    }
    public Structure(float life, int def)
    {
        this.life = life;
        this.defense = def;
    }

    protected Structure()
    {
    }

    public abstract void Damage(float amount,int def);
    public abstract void Healing(float amount);
    public abstract void DisplayStats();
}

