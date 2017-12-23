using System;
using System.Collections.Specialized;

namespace lab1
{
    public class Entity
    {
        protected string classOfEntity;

        static Entity()
        {
            Console.WriteLine("Static Entity Constructor");
            EntityCounter = 0;
        }

        public Entity()
        {
            Console.WriteLine("Default Entity Constructor");
            CurrentHealth = MaxHealth = 100;
            IsLife = true;
            Image = "image.png";
            IntRect = 0;
            classOfEntity = "";
            AddEntity();
        }

        public Entity(float intRect, string image, float maxHealth)
        {
            Console.WriteLine("Entity Constructor with param");
            this.IntRect = intRect;
            this.Image = image;
            CurrentHealth = this.MaxHealth = maxHealth;
            IsLife = true;
            AddEntity();
            classOfEntity = "";
        }

        private static void AddEntity()
        {
            EntityCounter++;
        }

        public static int EntityCounter { get; private set; }

        public virtual void Update(float time)
        {

        }

        public float IntRect { get; set; }

        public string Image { get; set; }

        public float MaxHealth { get; set; }

        public float CurrentHealth { get; set; }

        public bool IsLife { get; set; }
    }
}
