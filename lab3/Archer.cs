using System;

namespace lab3
{
    public class Archer : Unit
    {
        private int arrowNumbers;

        public Archer()
        {
            Console.WriteLine("Archer default constructor");
            UnitType = "Archer";
        }

        public Archer(string Name, string image, int maxHealth, int damage, int speed, int arrowNumbers,
            string bowName) : base(Name, image, maxHealth, speed, damage)
        {
            Console.WriteLine("Archer constructor with param");
            this.arrowNumbers = arrowNumbers;
            BowName = bowName;
            UnitType = "Archer";
        }

        public override void Update(float time)
        {
            Jump();
            SitDown();
        }

        public int ArrowNumbers
        {
            get { return arrowNumbers; }
            set
            {
                if (value > 0) arrowNumbers = value;
            }
        }

        public string BowName { get; set; }
    }
}