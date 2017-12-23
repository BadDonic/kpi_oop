using System;

namespace lab1
{
    public class CommandCenter : Building
    {
        private static CommandCenter instance = null;

        public static CommandCenter create(float intRect, string image, float maxHealth, string material,
            int population,
            float creatingTime, int goldPerSecond, int gasPerSecond)
        {
            if (instance == null)
                instance = new CommandCenter(intRect, image, maxHealth, material, population,
                    creatingTime, goldPerSecond, gasPerSecond);
            return instance;
        }

        private CommandCenter(float intRect, string image, float maxHealth, string material, int population,
            float creatingTime, int goldPerSecond, int gasPerSecond) : base(intRect, image, maxHealth, material,
            population, creatingTime)
        {
            this.GasPerSecond = gasPerSecond;
            this.GoldPerSecond = goldPerSecond;
        }

        public override void Update(float time)
        {
            Console.WriteLine("Increase Gold");
        }

        public override Unit CreateUnit()
        {
            return new Archer(0, "archer.png", 1000, 100, (float) 1.5, 30, "Winner");
        }

        public int GoldPerSecond { get; set; }

        public int GasPerSecond { get; set; }
    }
}