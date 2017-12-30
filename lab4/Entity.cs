using System;
using System.Collections.Specialized;

namespace lab4
{
    [Serializable]
    //TODO Відокремлення суперкласу
    public abstract class Entity
    {
        protected string classOfEntity;

        static Entity()
        {
            EntityCounter = 0;
        }

        public Entity()
        {
            CurrentHealth = MaxHealth = 100;
            IsLife = true;
            Image = "image.png";
            IntRect = 0;
            classOfEntity = "";
            AddEntity();
        }

        public Entity(float intRect, string image, float maxHealth)
        {
            IntRect = intRect;
            Image = image;
            CurrentHealth = MaxHealth = maxHealth;
            IsLife = true;
            AddEntity();
            classOfEntity = "";
        }

        private static void AddEntity()
        {
            EntityCounter++;
        }

        public static int EntityCounter { get; private set; }

        public abstract void Update(float time);

        public float IntRect { get; set; }

        public string Image { get; set; }

        public float MaxHealth { get; set; }
        private float currentHealth;

        public float CurrentHealth
        {
            get
            {
                if (currentHealth < 0) IsLife = false;
                return currentHealth;
            }
            set { currentHealth = value; }
    }

        public bool IsLife { get; set; }
    }
}