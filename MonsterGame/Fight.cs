namespace MonsterGame
{
    public class Fight
    {
        public Fight(Hero hero, Monster monster)
        {
            Hero = hero;
            Monster = monster;
        }
        public Hero Hero { get; }
        public Monster Monster { get; }
        public bool HeroTurn()
        {
            var healthBefore = Monster.CurrentHealth;
            var attackDmg = (Hero.BaseStrength + Hero.GetWeaponEffect() - Monster.Defense);
            if (attackDmg <= 0)
            {
                attackDmg = 0;
                UserInteraction.DisplayNoDamage();
                return false;
            }
            else
            {
                Monster.CurrentHealth -= attackDmg;
                UserInteraction.DisplayAttackResult(attackDmg, healthBefore, Monster.CurrentHealth);
                return true;
            }
        }
        public bool MonsterTurn()
        {
            UserInteraction.DisplayMonsterAttack();
            var attackDmg = (Monster.Strength - Hero.GetArmorEffect() - Hero.BaseDefense);
            if (attackDmg <= 0)
            {
                attackDmg = 0;
                UserInteraction.DisplayNoDamage();
                return false;
            }
            else
            {
                Hero.CurrentHealth -= attackDmg;
                UserInteraction.DisplayAttackResult(attackDmg, attackDmg + Hero.CurrentHealth, Hero.CurrentHealth);
                return true;
            }
        }
        public void Win()
        {
            UserInteraction.DisplayFightEnd("Hero");
        }
        public void Lose()
        {
            UserInteraction.DisplayFightEnd("Monster");
        }
    }
}
