namespace Assets.BattleTypes;

public abstract class Melee : Hero
{
    public Melee(string name, (int X, int Y) position) : base(name, position)
    {
        Priority = 2;
        Range = 1;
    }
}
