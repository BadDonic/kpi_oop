using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace lab3
{
    public enum Type{
        Archer, Sword, Slave, Mag, Runner, Zombie
    }
    
    [Serializable]
    [DataContract]
    public class Unit : Entity, IAttack<Unit>, IComparable<Unit>, IMove
    {
        public event AttackHandle AttackEvent;
//        public Action<float> SayCurrentHealth;
//        public Func<float, float> buff;
        [DataMember]
        protected int damage;
        [DataMember]
        public int Damage
        {
            get { return damage; }
            set
            {
                if (value > 0 && value < 100)    
                    damage = value;
            }
        }
        [DataMember]
        public int AttackSpeed { get; set; }
        [DataMember]
        public int Speed { get; set; }
        [DataMember]
        public bool IsAttack { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        protected bool isMove;
        [DataMember]
        protected bool isRun;
        [DataMember]
        public Type Type{ get; set; }
        [DataMember]        
        public bool IsMove { get; set; }
        [DataMember]
        public bool IsRun { get; set; }

        public Unit()
        {
            Speed = 2;
            IsMove = false;
            classOfEntity = "Unit";
            Type = Type.Slave;
        }

        public Unit(string name, string image, int maxHealth, int speed, int damage, Type type) : base(0, image,
            maxHealth)
        {
            Speed = speed;
            Damage = damage;
            isRun = false;
            Name = name;
            IsMove = false;
            classOfEntity = "Unit";
            Type = type;
        }

        public override void Update(float time)
        {
//            if (buff != null) CurrentHealth = buff(CurrentHealth);
//            SayCurrentHealth?.Invoke(CurrentHealth);
        }

        public void Attack(Unit target)
        {
            AttackEventArgs args = new AttackEventArgs(target, Damage);
            AttackEvent?.Invoke(this, args);
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
        
        public override string ToString()
        {
            return $"UnitType: {Type}| Name: {Name}| Damage: {Damage}| Speed: {Speed}| ( {CurrentHealth} | {MaxHealth} )| Life: {IsLife}\n";
        }

        public int CompareTo(Unit unit)
        {
            int compare = Type.CompareTo(unit.Type);
            if (compare != 0) return compare;
            compare = string.CompareOrdinal(Name, unit.Name);
            if (compare != 0) return compare;
            compare = Speed.CompareTo(unit.Speed);
            if (compare != 0) return compare;
            compare = Damage.CompareTo(unit.Damage);
            return compare;
        }
    }
}
