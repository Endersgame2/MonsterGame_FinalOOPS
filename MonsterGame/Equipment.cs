namespace MonsterGame
{
    public class Equipment
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public override string ToString()
        {
            return Name + " (" + Power + ")";
        }
    }
}