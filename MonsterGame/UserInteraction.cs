using System;

namespace MonsterGame
{
    internal class UserInteraction
    {
        internal static byte GetChoice()
        {
            Console.WriteLine("\n### MAIN MENU ###\n");
            Console.WriteLine("1 - Display Statistics");
            Console.WriteLine("2 - Display Inventory");
            Console.WriteLine("3 - Fight!");
            Console.WriteLine("4 - Manage Coins");
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "3" || input == "4")
                {
                    return Convert.ToByte(input);
                }
                InvalidChoice();
            }
        }

        internal static string GetName()
        {
            Console.WriteLine("Name: ");
            return Console.ReadLine();
        }

        internal static void DisplayAttackResult(int attackDmg, int healthBefore, int currentHealth)
        {
            Console.WriteLine("Damage: " + attackDmg);
            Console.WriteLine("Health Before: " + healthBefore);
            Console.WriteLine("Health Now: " + (currentHealth > 0 ? currentHealth.ToString() : "zero"));
        }

        internal static void DisplayFightStart(Monster monster)
        {
            Console.WriteLine("\nStarting fight with monster: ");
            Console.WriteLine("Name: " + monster.Name);
            Console.WriteLine("Strength: " + monster.Strength);
            Console.WriteLine("Defense: " + monster.Defense);
            Console.WriteLine("Health: " + monster.OriginalHealth + "\n");
        }

        internal static void DisplayEquipmentEquipped(string name)
        {
            Console.WriteLine(name + " equipped");
        }

        internal static byte GetEquipmentOption(Equipment[] bag)
        {
            Console.WriteLine("\n---Pick item---");
            for (var i = 0; i < bag.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + bag[i].ToString());
            }
            while (true)
            {
                var input = Console.ReadLine();
                if (IsValidEquiment(bag.Length, input))
                    return Convert.ToByte(input);
                InvalidChoice();
            }
        }

        internal static void DisplayNoDamage()
        {
            Console.WriteLine("Attack is ineffective");
        }

        internal static void DisplayMonsterAttack()
        {
            Console.WriteLine("Monster's attack result:");
        }

        internal static void DisplayFightEnd(string name)
        {
            Console.WriteLine(name + " won the fight");
        }

        internal static byte ShowInventory(Tuple<Weapon, Armor> equippedItems)
        {
            if (equippedItems.Item1 != null)
            {
                Console.WriteLine("Weapon equipped: " + equippedItems.Item1);
            }
            else
            {
                Console.WriteLine("No weapon equipped");
            }
            if (equippedItems.Item2 != null)
            {
                Console.WriteLine("Armor equipped: " + equippedItems.Item2);
            }
            else
            {
                Console.WriteLine("No armor equipped");
            }
            Console.WriteLine("1 - Equip Weapon");
            Console.WriteLine("2 - Equip Armor");
            Console.WriteLine("0 - Back to main menu");
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "0")
                {
                    return Convert.ToByte(input);
                }
                InvalidChoice();
            }
        }

        private static bool IsValidEquiment(int length, string input)
        {
            bool success = byte.TryParse(input, out byte number);
            if (!success)
            {
                return false;
            }
            return number > 0 && number <= length;
        }

        internal static void ShowStatistics(Game game)
        {
            Console.WriteLine("Total fights: " + game.NumberOfGames);
            Console.WriteLine("Victories: " + game.NumberOfWins);
            Console.WriteLine("Losses: " + game.NumberOfLosses);
        }

        internal static void NotifyDraw()
        {
            Console.WriteLine("Fight is a draw");
        }

        internal static void InvalidChoice()
        {
            Console.WriteLine("Please pick a correct option from the menu");
        }
    }
}