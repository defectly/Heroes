using Assets.BattleTypes;

namespace Assets.Heroes;

public class Priest : Magic
{
    public Priest(string name, (int X, int Y) position) : base(name, position)
    {
    }
}
