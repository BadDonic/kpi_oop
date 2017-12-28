using System;
using System.Collections.Generic;

namespace lab3
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Unit unit1 = new Unit("Dima", "", 100, 20, 10);
            Unit unit2 = new Unit("Monster", "", 200, 20, 20);
            unit1.SayCurrentHealth = (health) =>
            {
                Console.WriteLine("C_u_r_r_e_n_t Health = {0}", health);
            };
            unit2.SayCurrentHealth = (health) =>
            {
                Console.WriteLine("C|u|r|r|e|n|t Health = {0}", health);
            };
            unit1.buff = PossitiveBuff;
            
            unit2.AttackEvent += (attacker, eventArgs) =>
                {
                    Console.WriteLine("Lambda methods");
                    Unit target = eventArgs.Target;
                    target.CurrentHealth -= eventArgs.Damage;
                    if (target.CurrentHealth <= 0)
                    {
                        Console.WriteLine("{0} am dead", target.Name);
                        return;
                    }
                    Console.WriteLine("This unit({0}) attack me({1}) and hit {2} damage", attacker.Name, target.Name,
                        eventArgs.Damage);
                    target.Update(10);
                    target.Attack(attacker);
                };
            unit1.AttackEvent += delegate(Unit attacker, AttackEventArgs eventArgs)
            {
                Console.WriteLine("Anonymous methods");
                Unit target = eventArgs.Target;
                target.CurrentHealth -= eventArgs.Damage;
                if (target.CurrentHealth <= 0)
                {
                    Console.WriteLine("{0} am dead", target.Name);
                    return;
                }
                Console.WriteLine("This unit({0}) attack me({1}) and hit {2} damage", attacker.Name, target.Name,
                    eventArgs.Damage);
                target.Update(10);
                target.Attack(attacker);
            };
            unit1.Attack(unit2);
        }

        public static float PossitiveBuff(float currentHealth)
        {
            Console.WriteLine("BUFF");
            return currentHealth + 5;
        }
    }
}
