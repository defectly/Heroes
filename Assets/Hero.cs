using Assets.BattleTypes;
using System.ComponentModel;

namespace Assets;

public abstract class Hero(string name, (int X, int Y) position) : IHero
{
    public string Name { get; protected set; } = name;
    public HeroType HeroType { get; protected set; }
    public BattleType BattleType { get; protected set; }
    public virtual int Range { get; protected set; }

    public bool IsDead { get; protected set; } = false;

    protected int _health = 100;

    public int Health
    {
        get => _health;
        set
        {
            if (value < 0)
                _health = 0;
            else if (value > 100)
                _health = 100;
        }
    }

    public int Priority { get; protected set; }

    protected (int X, int Y) _position = position;

    public (int X, int Y) Position
    {
        get => _position;

        protected set
        {
            if (value.X < 0)
                value.X = 0;
            else if (value.X > 10)
                value.X = 10;

            if (value.Y < 0)
                value.Y = 0;
            else if (value.Y > 10)
                value.Y = 10;

            _position = value;
        }
    }

    public int damage { get; protected set; } = 10;

    public void ChangeHealth(int points, bool isHealing = false)
    {
        if (isHealing)
            Health += points;
        else
            Health -= points;

        if (Health <= 0)
            IsDead = true;
    }

    public virtual void Step(List<Hero> mates, List<Hero> enemies)
    {
        var info = GetNearestEnemy(Position, enemies);

        if (info.Distance < Range)
            return;

        (int X, int Y) distance = ((Position.X - info.Enemy.Position.X), (Position.Y - info.Enemy.Position.Y));

        if (distance.X > distance.Y)
        {
            (int X, int Y) newPosition = (MovePosition(distance.X), distance.Y);
            if (mates.Any(mate => mate.Position == newPosition))
                return;
        }
        else
        {
            (int X, int Y) newPosition = (distance.X, MovePosition(distance.Y));
            if (mates.Any(mate => mate.Position == newPosition))
                return;
        }
    }

    protected int MovePosition(int direction)
    {
        if (direction < 0)
            return direction + 1;
        else
            return direction - 1;
    }

    protected static (float Distance, Hero Enemy) GetNearestEnemy((int X, int Y) selfPosition, List<Hero> enemies)
    {
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
        enemy.ChangeHealth(damage);
    }

    public override string ToString()
    {
        return $"{HeroType}, {Name}, {Health}, [{Position.X}, {Position.Y}]";
    }
}
