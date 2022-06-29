using System;

namespace MonsterGame
{
    public class Factory
    {

        internal static Hero PrepareHero(string name)
        {
            var hero = new Hero()
            {
                Name = name,
            };
            ResetHero(hero);
            return hero;
        }

        internal static Monster PrepareRandomMonster()
        {
            var monsters = new Monster[]
            {
                new Monster()
                {
                    Name = "Shao Kahn",
                    Strength = 150,
                    Defense = 20,
                    OriginalHealth = 1000,
                    CurrentHealth = 1000
                },
                new Monster()
                {
                    Name = "Shang Tsung",
                    Strength = 140,
                    Defense = 200,
                    OriginalHealth = 800,
                    CurrentHealth = 800
                },
                new Monster()
                {
                    Name = "Shinnok",
                    Strength = 20,
                    Defense = 1000,
                    OriginalHealth = 2000,
                    CurrentHealth = 2000
                },
                new Monster()
                {
                    Name = "Onaga",
                    Strength = 10,
                    Defense = 10,
                    OriginalHealth = 40000,
                    CurrentHealth = 40000
                },
                new Monster()
                {
                    Name = "Goro",
                    Strength = 400,
                    Defense = 400,
                    OriginalHealth = 300,
                    CurrentHealth = 300
                }
            };
            Random random = new Random();
            return monsters[random.Next(0, 3)];
        }

        internal static void ResetHero(Hero hero)
        {
            hero.BaseStrength = 30;
            hero.BaseDefense = 30;
            hero.OriginalHealth = 500;
            hero.CurrentHealth = 500;
        }
    }
}
