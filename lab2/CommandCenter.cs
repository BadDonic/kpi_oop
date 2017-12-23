using System;

namespace lab2
{
    public class CommandCenter : Building
    {
        private static CommandCenter instance;

        public static CommandCenter Create(float intRect, string image, float maxHealth, string material,
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
            GasPerSecond = gasPerSecond;
            GoldPerSecond = goldPerSecond;
        }

        public override void Update(float time)
        {
            Console.WriteLine("Increase Gold");
        }

        public override Unit CreateUnit()
        {
            return new Archer("", "archer.png", 1000, 100, 4, 30, "Winner");
        }

        public int GoldPerSecond { get; set; }

        public int GasPerSecond { get; set; }
    }
}