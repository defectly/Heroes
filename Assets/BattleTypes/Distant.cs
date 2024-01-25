namespace Assets.BattleTypes;

public abstract class Distant : Hero
{
    public virtual int Ammo { get; set; } = 5;

    public Distant(string name, (int X, int Y) position) : base(name, position)
    {
        Priority = 3;
    }

    public override void Step(List<Hero> mates, List<Hero> enemies)
    {
        if (IsDead || Ammo <= 0)
            return;

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
        Ammo -= 1;
    }
}
