using Assets.BattleTypes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assets;

public abstract class Hero(string name, (int X, int Y) position) : IHero
{
    public string Name { get; protected set; } = name;
    public HeroType HeroType { get; protected set; }
    public BattleType BattleType { get; protected set; }
    public virtual int Range { get; protected set; }

    public bool IsDead { get; protected set; } = false;

    public int Health { get; set; } = 100;

    public int Priority { get; protected set; }

    protected (int X, int Y) _position = position;

    public (int X, int Y) Position
    {
        get => _position;

        protected set
        {
            if (value.X < 1)
                value.X = 1;
            else if (value.X > 10)
                value.X = 10;

            if (value.Y < 1)
                value.Y = 1;
            else if (value.Y > 10)
                value.Y = 10;

            _position = value;
        }
    }

    public int Damage { get; protected set; } = 10;

    public void ChangeHealth(int points, bool isHealing = false)
    {
        if (isHealing)
        {
            Health += points;
            if (Health > 100)
                Health = 100;
        }
        else
        {
            Health -= points;
            if (Health < 0)
                Health = 0;
        }

        if (Health <= 0)
            IsDead = true;
    }

    public virtual void Step(List<Hero> mates, List<Hero> enemies)
    {
        var info = GetNearestEnemy(Position, enemies);

        var nextPosition = NextPosition(Position, info.Enemy.Position);

        if (!mates.Any(mate => mate.Position == nextPosition && mate.IsDead == false))
            Position = nextPosition;
    }

    protected (int X, int Y) NextPosition((int X, int Y) selfPosition, (int X, int Y) enemyPosition)
    {
        var difference = GetPositionDifference(selfPosition, enemyPosition);
        var nextPosition = Position;

        if (difference.X < 0)
            nextPosition = (nextPosition.X + 1, nextPosition.Y);
        else if(difference.X > 0)
            nextPosition = (nextPosition.X - 1, nextPosition.Y);
        else if(difference.Y < 0)
            nextPosition = (nextPosition.X, nextPosition.Y + 1);
        else if(difference.Y > 0)
            nextPosition = (nextPosition.X, nextPosition.Y - 1);

        return nextPosition;
    }

    protected (int X, int Y) Move((int X, int Y) selfPosition, double degree)
    {
        (int X, int Y) position;

        if (degree <= 45 && degree > 315)
            position = (selfPosition.X + 1, selfPosition.Y);
        else if (degree <= 135 && degree > 45)
            position = (selfPosition.X, selfPosition.Y + 1);
        else if (degree <= 225 && degree > 135)
            position = (selfPosition.X - 1, selfPosition.Y);
        else
            position = (selfPosition.X, selfPosition.Y - 1);

        return position;
    }

    protected static double FixAngle(double angle)
    {
        var newAngle = angle;

        if (angle < 0)
        {
            newAngle = angle + (2 * Math.PI);
        }
        if (angle > Math.PI)
        {
            newAngle = 2 * Math.PI - angle;
        }
        return newAngle;
    }

    protected static bool IsPositionOccupied(List<Hero> mates, (int X, int Y) position)
    {
        return mates.Any(mate => mate.Position == position && mate.IsDead == false);
    }

    protected static (int X, int Y) GetPositionDifference((int X, int Y) selfPosition, (int X, int Y) enemyPosition)
    {
        return (selfPosition.X - enemyPosition.X, selfPosition.Y - enemyPosition.Y);
    }

    protected static (float Distance, Hero Enemy) GetNearestEnemy((int X, int Y) selfPosition, List<Hero> enemies)
    {
        enemies = enemies.Where(enemy => enemy.IsDead == false).ToList();

        float distance = enemies.Min(enemy => GetDistance(selfPosition, enemy.Position));
        Hero enemy = enemies.First(enemy => GetDistance(selfPosition, enemy.Position) == distance);

        return (distance, enemy);
    }

    protected static float GetDistance((int X, int Y) selfPosition, (int X, int Y) enemyPosition)
    {
        return (float)Math.Sqrt(Math.Pow(enemyPosition.X - selfPosition.X, 2) + Math.Pow(enemyPosition.Y - selfPosition.Y, 2));
    }

    protected virtual void Attack(Hero enemy)
    {
        enemy.ChangeHealth(Damage);
    }

    public override string ToString()
    {
        return $"{HeroType}, {Name}, {Health}, [{Position.X}, {Position.Y}]";
    }
}
