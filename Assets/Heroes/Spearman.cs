using Assets.BattleTypes;

namespace Assets.Heroes;

public class Spearman : Distant
{
    public override int Ammo { get; set; } = 1;

    public Spearman(string name, (int X, int Y) position) : base(name, position)
    {
        Range = 2;
        HeroType = HeroType.Spearman;
    }
}
