namespace lab4
{
    public class Archer : Unit
    {
        private int arrowNumbers;

        //TODO G12 - Балласт
//        public Archer()
//        {
//
//        }

        public Archer(string Name, string image, int maxHealth, int damage, int speed, int arrowNumbers,
            string bowName) : base(Name, image, maxHealth, speed, damage)
        {
            this.arrowNumbers = arrowNumbers;
            BowName = bowName;
            UnitType = "Archer";
        }

        public override void Update(float time)
        {
            Jump();
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