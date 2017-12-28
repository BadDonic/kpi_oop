using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace lab3
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Unit unit1 = new Unit("Dima", "", 100, 100, 10, Type.Archer);
            Unit unit2 = new Unit("Monster", "", 200, 300, 20, Type.Slave);
//            unit1.SayCurrentHealth = (health) =>
//            {
//                Console.WriteLine("C_u_r_r_e_n_t Health = {0}", health);
//            };
//            unit2.SayCurrentHealth = (health) =>
//            {
//                Console.WriteLine("C|u|r|r|e|n|t Health = {0}", health);
//            };
//            unit1.buff = PossitiveBuff;

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


            //create new system
            Squad<Unit> squad = new Squad<Unit>("Daniel");

            squad.Add(unit2);
            squad.Add(unit1);
            Console.WriteLine("\n\nSquad:\n");
            squad.GetAllInfo();
            squad.Sort();
            
            Console.WriteLine("\n\nAfter Sort:\n");
            squad.GetAllInfo();
            
            Console.WriteLine($"GET from collection through name(Dima)\n{squad["Dima"]}");
            Console.WriteLine($"GET THE FASTEST UNIT\n{squad.GetFastestUnit()}");
            
            XmlSerializer formatter = new XmlSerializer(typeof(Unit));
                
            using (FileStream fs = new FileStream("unit.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, unit1);
 
                Console.WriteLine("Объект сериализован XML");
            }
 
            // десериализация
            using (FileStream fs = new FileStream("unit.xml", FileMode.OpenOrCreate))
            {
                Unit newUnit = (Unit)formatter.Deserialize(fs);
 
                Console.WriteLine("Объект десериализован XML");
                Console.WriteLine(newUnit);
            }
            
            Unit[] arr = new Unit[2];
            arr[0] = unit1;
            arr[1] = unit2;
            
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Unit[]));
 
            using (FileStream fs = new FileStream("units.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, arr);
                Console.WriteLine("Объекты сериализованы JSON");
            }
 
            using (FileStream fs = new FileStream("units.json", FileMode.OpenOrCreate))
            {
                Unit[] res = (Unit[])jsonFormatter.ReadObject(fs);
                Console.WriteLine("Объекты десериализованы JSON");
                foreach (Unit it in res)
                {
                    Console.WriteLine(it);
                }
            }
        }


        public static float PossitiveBuff(float currentHealth)
        {
            Console.WriteLine("BUFF + 5");
            return currentHealth + 5;
        }
    }
}
