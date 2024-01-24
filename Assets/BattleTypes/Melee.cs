namespace Assets.BattleTypes;

public abstract class Melee : Hero
{
    public Melee(string name, (int X, int Y) position) : base(name, position)
    {
        Priority = 2;
        Range = 1;
    }

    public override void Step(List<Hero> mates, List<Hero> enemies)
    {
        if (IsDead)
            return;

        var info = GetNearestEnemy(Position, enemies);

        if (info.Distance > Range)
        {
            base.Step(mates, enemies);
            return;
        }

        Attack(info.Enemy);
    }
}
