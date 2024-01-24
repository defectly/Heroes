namespace Assets;

public interface IHero
{
    void Step(List<Hero> mates, List<Hero> enemies);
}