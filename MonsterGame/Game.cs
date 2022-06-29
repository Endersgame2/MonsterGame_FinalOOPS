using System;

namespace MonsterGame
{
    public class Game
    {
        public Hero Hero { get; set; }
        public int NumberOfGames { get; set; }
        public int NumberOfWins { get; set; }
        public int NumberOfDraws { get; set; }
        public int NumberOfLosses
        {
            get
            {
                return NumberOfGames - NumberOfWins - NumberOfDraws;
            }
        }
        internal void Start()
        {
            byte choice;
            var heroName = UserInteraction.GetName();
            Hero = Factory.PrepareHero(heroName);
            do
            {
                choice = UserInteraction.GetChoice();
                switch (choice)
                {
                    case 1:
                        UserInteraction.ShowStatistics(this);
                        break;
                    case 2:
                        BeginInventoryManagement();
                        break;
                    case 3:
                        Monster monster = Factory.PrepareRandomMonster();
                        Fight fight = new Fight(Hero, monster);
                        UserInteraction.DisplayFightStart(monster);
                        while (true)
                        {
                            var isDamageDealtByHero = fight.HeroTurn(); // Hero's turn first, so hero always has advantage
                            bool isDamageDealtByMonster;
                            if (monster.CurrentHealth > 0)
                            {
                                isDamageDealtByMonster = fight.MonsterTurn();
                                if (Hero.CurrentHealth <= 0)
                                {
                                    fight.Lose();
                                    break;
                                }
                            }
                            else
                            {
                                NumberOfWins++;
                                fight.Win();
                                break;
                            }
                            if (!isDamageDealtByHero && !isDamageDealtByMonster) // Epic fight till the end of time, so draw
                            {
                                NumberOfDraws++;
                                UserInteraction.NotifyDraw();
                                break;
                            }
                        }
                        NumberOfGames++;
                        Factory.ResetHero(Hero);
                        break;
                    case 4:
                        throw new NotImplementedException();
                    default:
                        UserInteraction.InvalidChoice();
                        break;
                }

            } while (choice != 4);

        }

        private void BeginInventoryManagement()
        {
            byte choice;
            do
            {
                var equippedItems = Hero.ShowInventory();
                choice = UserInteraction.ShowInventory(equippedItems);
                if (choice == 1)
                {
                    Hero.EquipWeapon(UserInteraction.GetEquipmentOption(WeaponList.List) - 1);
                    UserInteraction.DisplayEquipmentEquipped(Hero.EquippedWeapon.Name);
                }
                else if (choice == 2)
                {
                    Hero.EquipArmor(UserInteraction.GetEquipmentOption(ArmorList.List) - 1);
                    UserInteraction.DisplayEquipmentEquipped(Hero.EquippedArmor.Name);
                }
            }
            while (choice != 0);

        }
    }
}