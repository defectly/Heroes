using Assets.BattleTypes;

namespace Assets.Heroes;

public class Sniper : Distant
{
    public Sniper(string name, (int X, int Y) position) : base(name, position)
    {
        Range = 4;
    }
}
