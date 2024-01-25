namespace Assets.BattleTypes;

public abstract class Magic : Hero
{
    public int Mane { get; set; } = 100;

    public Magic(string name, (int X, int Y) position) : base(name, position)
    {
        Priority = 1;
        Range = 2;
    }

    public override void Step(List<Hero> mates, List<Hero> enemies)
    {
        if (IsDead)
            return;

        if (Mane <= 0)
        {
            Mane += 10;
            return;
        }

        var info = GetNearestEnemy(Position, enemies);

        if (info.Distance > Range)
        {
            base.Step(mates, enemies);
            return;
        }

        Attack(info.Enemy);
    }

    protected override void Attack(Hero enemy)
    {
        base.Attack(enemy);
        Mane -= Damage;
    }
}
