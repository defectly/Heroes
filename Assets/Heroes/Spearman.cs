using Assets.BattleTypes;

namespace Assets.Heroes;

public class Spearman : Distant
{
    public int _ammo = 1;

    public override int Ammo
    {
        get => _health;
        set
        {
            if (value < 0)
                _ammo = 0;
            else if (value > 1)
                _ammo = 1;
        }
    }

    public Spearman(string name, (int X, int Y) position) : base(name, position)
    {
        Range = 2;
    }
}
