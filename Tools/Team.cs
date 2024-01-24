using Assets;
using Assets.Heroes;

namespace Tools;

public class Team
{
    private static Random _random = new();
    private static List<string> _names;
    public TeamSide Side { get; private set; }
    public List<Hero> Heroes { get; private set; } = new();

    public Team(TeamSide side)
    {
        _names ??= File.ReadAllLines(@"C:\Users\rikar\Desktop\names.txt").ToList();
        Side = side;
        GenerateTeam();
    }

    public List<Hero> SortByPriority()
    {
        return Heroes.OrderBy(hero => hero.Priority).ToList();
    }

    public bool IsAnyALive()
    {
        return Heroes.Any(hero => hero.IsDead == false);
    }

    private void GenerateTeam()
    {
        for (int i = 1; i <= 10; i++)
        {
            Heroes.Add(CreateHero(_random.Next(1, 8), 
                _names[_random.Next(1, _names.Count - 1)],
                ((Side == TeamSide.Darkness ? 1 : 10), i)));
        }
    }

    private static Hero CreateHero(int number, string name, (int X, int Y) position)
    {
        return number switch
        {
            1 => new Villager(name, position),
            2 => new Bandit(name, position),
            3 => new Priest(name, position),
            4 => new Wizard(name, position),
            5 => new Spearman(name, position),
            6 => new Crossbower(name, position),
            7 => new Sniper(name, position),
            _ => throw new NotImplementedException()
        };
    }
}