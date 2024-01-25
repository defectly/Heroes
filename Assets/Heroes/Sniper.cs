using Assets.BattleTypes;

namespace Assets.Heroes;

public class Sniper : Distant
{
    public override int Ammo { get; set; } = 5;

    public Sniper(string name, (int X, int Y) position) : base(name, position)
    {
        Range = 4;
        HeroType = HeroType.Sniper;
    }
}
