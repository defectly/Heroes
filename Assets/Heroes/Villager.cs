using Assets.BattleTypes;

namespace Assets.Heroes;

public class Villager : Bearer
{
    public Villager(string name, (int X, int Y) position) : base(name, position)
    {
        HeroType = HeroType.Villager;
    }

    public override void Step(List<Hero> mates, List<Hero> enemies)
    {
        foreach (var hero in mates.Where(mate => mate.BattleType == BattleType.Distant))
        {
            ((Distant)hero).Ammo += 1;
        }
    }
}
