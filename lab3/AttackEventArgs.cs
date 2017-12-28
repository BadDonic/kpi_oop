using System;

namespace lab3
{
    public delegate void AttackHandle(Unit e, AttackEventArgs args); 
    public class AttackEventArgs : EventArgs
    {
        public Unit Target { get; set; }
        public int Damage { get; set; }
        public AttackEventArgs(Unit target, int damage)
        {
            Target = target;
            Damage = damage;
        }

        public AttackEventArgs() : this(null, 0) {}

    }
}