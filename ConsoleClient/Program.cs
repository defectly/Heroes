using Assets;
using ConsoleClient;
using Tools;

internal class Program
{
    public static Team darkness = new Team(TeamSide.Darkness);
    public static Team heaven = new Team(TeamSide.Heaven);
    public static List<Hero> allTeam = darkness.Heroes.Concat(heaven.Heroes).ToList();
    private static void Main(string[] args)
    {
        var darkness = new Team(TeamSide.Darkness);
        var heaven = new Team(TeamSide.Heaven);

        int step = 0;
        while (true)
        {
            View.view();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(darkness.SortByPriority()[i] + " | " + heaven.SortByPriority()[i]);
            }
            Console.WriteLine();
            Console.WriteLine();

            char[,] field = new char[10, 10];

            foreach (var _hero in darkness.Heroes)
            {
                field[_hero.Position.X - 1, _hero.Position.Y - 1] = _hero.ToString()[0];
            }

            foreach (var _hero in heaven.Heroes)
            {
                field[_hero.Position.X - 1, _hero.Position.Y - 1] = _hero.ToString()[0];
            }
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[j, i] + " | ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("=================");

            if (!darkness.CanFight())
            {
                Console.WriteLine("Heaven won");
                break;
            }
            else if (!heaven.CanFight())
            {
                Console.WriteLine("Darkness won");
                break;
            }

            try
            {
                darkness.SortByPriority().ForEach(hero =>
                {
                    hero.Step(darkness.Heroes, heaven.Heroes);
                });

                heaven.SortByPriority().ForEach(hero =>
                {
                    hero.Step(heaven.Heroes, darkness.Heroes);
                });
            }
            catch { }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(darkness.SortByPriority()[i] + " | " + heaven.SortByPriority()[i]);
            }
            Console.WriteLine();
            Console.WriteLine();

            step++;
            Console.WriteLine("step: " + step);
        }
    }
}