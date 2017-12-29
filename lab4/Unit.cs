using System;
using System.Collections.Generic;
using System.Xml;

namespace lab4
{
    public class Unit : Entity, IAttack<Unit>, IMove
    {
        public event AttackHandle AttackEvent;
        private static List<Unit> list = new List<Unit>();
        protected int damage;
        public int Damage
        {
            get { return damage; }
            set
            {
                if (value > 0 && value < 100)    
                    damage = value;
            }
        }

        public int AttackSpeed { get; set; }
        public int Speed { get; set; }
        public bool IsAttack { get; set; }
        public string Name { get; set; }
        protected bool isMove;
        protected bool isRun;
        public string UnitType { get; set; }
        
        public bool IsMove
        {
            get { return isMove; }
            set { Speed = !value ? 0 : 100; }
        }

        public bool IsRun
        {
            get { return isRun; }
            set
            {
                if (!value)
                    Speed -= 100;
                else
                    Speed += 100;
            }
        }

        public Unit()
        {
            Speed = 2;
            IsMove = false;
            classOfEntity = "Unit";
            UnitType = "";
        }

        public Unit(string name, string image, int maxHealth, int speed, int damage) : base(0, image,
            maxHealth)
        {
            Speed = speed;
            Damage = damage;
            isRun = false;
            Name = name;
            IsMove = false;
            classOfEntity = "Unit";
            UnitType = "";
            foreach (var obj in list)
            {
                obj.AttackEvent += CheckAttack;
                AttackEvent += obj.CheckAttack;
            }
            list.Add(this);
        }

        public override void Update(float time)
        {
            if (IsMove && IntRect > 1000) IntRect += Speed * time;
            else IsMove = false;
        }

        public void Attack(Unit target)
        {
            AttackEventArgs args = new AttackEventArgs(target, Damage);
            if (AttackEvent != null)
                AttackEvent(this, args);
        }

        public void CheckAttack(Unit attacker, AttackEventArgs args)
        {
            if (args.Target == this)
            {
                CurrentHealth -= args.Damage;
                if (CurrentHealth <= 0)
                {
                    Console.WriteLine("{0} am dead", Name);
                    return;
                }
                Console.WriteLine("This unit({0}) attack me({1}) and hit {2} damage", attacker.Name, Name, args.Damage);
                Console.WriteLine("Current Health = {0}", CurrentHealth);
                Attack(attacker);
                Damage++;
            }
        }

        public void MakeCriticalHit(Unit target)
        {
            target.CurrentHealth -= 2 * Damage;
        }

        public void Jump()
        {
            Console.WriteLine("Jump");
        }

        public void SitDown()
        {
            Console.WriteLine("Sit Down");
        }
    }
}
