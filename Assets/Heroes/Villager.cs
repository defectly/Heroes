using Assets.BattleTypes;

namespace Assets.Heroes;

public class Villager : Bearer
{
    public Villager(string name, (int X, int Y) position) : base(name, position)
    {
        HeroType = HeroType.Villager;
        Range = 1;
    }

    public override void Step(List<Hero> mates, List<Hero> enemies)
    {
        if (IsDead)
            return;

        //var info = GetNearestEnemy(Position, mates.Where(mate => mate.IsDead == false 
        //&& (mate.HeroType == HeroType.Spearman || mate.HeroType == HeroType.Sniper || mate.HeroType == HeroType.Crossbower)).ToList());

        //if (GetDistance(Position, info.Enemy.Position) > Range)
        //{
        //    base.Step(mates, mates);
        //    return;
        //}

        //((Distant)info.Enemy).Ammo += 1;

        foreach (var mate in mates.Where(mate => mate.IsDead == false && mate.BattleType == BattleType.Distant))
        {
            ((Distant)mate).Ammo += 1;
        }
    }
}
