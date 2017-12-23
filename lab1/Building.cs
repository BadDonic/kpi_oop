using System;

namespace lab1
{
    public class Building : Entity
    {
        private int population;
        private float curTime;
        private bool isCreating;

        private Building()
        {
            Console.WriteLine("Building default constructor");
            classOfEntity = "Building";
        }

        public Building(float intRect, string image, float maxHealth, string material, int population,
            float creatingTime) : base(intRect, image, maxHealth)
        {
            Console.WriteLine("Building constructor with param");
            this.Material = material;
            this.population = population;
            this.CreatingTime = creatingTime;
            curTime = creatingTime;
            isCreating = false;
            classOfEntity = "Building";
        }

        public override void Update(float time)
        {
            if (isCreating) CreateUnit();
        }

        public virtual Unit CreateUnit()
        {
            return new Unit();
        }

        public string Material { get; set; }

        public int Population { get => population; set {if (value > 0) population = value;} }

        public float CreatingTime { get; set; }

        public string TypeOfBuilding { get; set; }
    }
}