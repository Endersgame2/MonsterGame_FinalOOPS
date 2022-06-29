using System;

namespace MonsterGame
{
    public class Hero : Character
    {
        public int BaseStrength { get; set; }
        public int BaseDefense { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public Tuple<Weapon, Armor> ShowInventory()
        {
            return new Tuple<Weapon, Armor>(EquippedWeapon, EquippedArmor);
        }
        public void EquipWeapon(int index)
        {
            EquippedWeapon = WeaponList.List[index];
        }

        internal int GetWeaponEffect()
        {
            return EquippedWeapon != null ? EquippedWeapon.Power : 0;
        }

        public void EquipArmor(int index)
        {
            EquippedArmor = ArmorList.List[index];
        }

        internal int GetArmorEffect()
        {
            return EquippedArmor != null ? EquippedArmor.Power : 0;
        }
        public Tuple<string, int, int, int, int> ShowStats() // Function is not used
        {
            return new Tuple<string, int, int, int, int>(Name, BaseStrength, BaseDefense, OriginalHealth, CurrentHealth);
        }
    }
}
