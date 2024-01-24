namespace Assets.BattleTypes;

public abstract class Bearer : Hero
{
    public Bearer(string name, (int X, int Y) position) : base(name, position)
    {
        Priority = 0;
    }
}
