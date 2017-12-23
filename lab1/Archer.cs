using System;

namespace lab1
{
    public class Archer : Unit
    {
        private int arrowNumbers;

        public Archer()
        {
            Console.WriteLine("Archer default constructor");
            UnitType = "Archer";
        }

        public Archer(float intRect, string image, int maxHealth, float damage, float speed, int arrowNumbers,
            string bowName) : base(intRect, image, maxHealth, damage, speed)
        {
            Console.WriteLine("Archer constructor with param");
            this.arrowNumbers = arrowNumbers;
            this.BowName = bowName;
            UnitType = "Archer";
        }

        public override void update(float time)
        {
            Attack(this);
        }

        public int ArrowNumbers
        {
            get => arrowNumbers;
            set
            {
                if (value > 0) arrowNumbers = value;
            }
        }

        public string BowName { get; set; }
    }
}