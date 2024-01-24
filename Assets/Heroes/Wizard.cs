using Assets.BattleTypes;

namespace Assets.Heroes;

public class Wizard : Magic
{
    public Wizard(string name, (int X, int Y) position) : base(name, position)
    {
        HeroType = HeroType.Wizard;
    }
}
