using Assets.BattleTypes;

namespace Assets.Heroes;

public class Bandit : Melee
{
    public Bandit(string name, (int X, int Y) position) : base(name, position)
    {
        HeroType = HeroType.Bandit;
    }
}
