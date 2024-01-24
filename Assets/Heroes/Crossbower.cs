using Assets.BattleTypes;

namespace Assets.Heroes;

public class Crossbower : Distant
{
    public Crossbower(string name, (int X, int Y) position) : base(name, position)
    {
        Range = 3;
        HeroType = HeroType.Crossbower;
    }
}
