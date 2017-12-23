using System;

namespace lab1
{
    public class Unit : Entity
    {
        private float direction;

        public Unit()
        {
            Console.WriteLine("Unit default constructor");
            Damage = 10;
            Speed = 2;
            IsMove = false;
            classOfEntity = "Unit";
            UnitType = "";
        }

        public Unit(float intRect, string image, int maxHealth, float damage, float speed) : base(intRect, image,
            maxHealth)
        {
            Console.WriteLine("Unit constructor with param");
            this.Damage = damage;
            this.Speed = speed;
            IsMove = false;
            direction = intRect;
            classOfEntity = "Unit";
            UnitType = "";
        }

        public virtual void update(float time)
        {
            if (IsMove && direction - IntRect > 1000) IntRect += Speed * time;
            else IsMove = false;
        }

        public void Attack(Entity entity)
        {
            entity.CurrentHealth -= Damage;
        }

        public void Attack(Entity entity1, Entity entity2)
        {
            entity1.CurrentHealth -= Damage;
            entity2.CurrentHealth -= Damage;
        }

        public float Speed { get; set; }

        public float Damage { get; set; }

        public bool IsMove { get; set; }

        public float Direction
        {
            get => direction;
            set
            {
                direction = value;
                IsMove = true;
            }
        }
    
        public string UnitType { get; set; }
    }
}
