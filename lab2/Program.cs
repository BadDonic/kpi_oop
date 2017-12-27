using System;
using System.Collections.Generic;

namespace lab2
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Unit unit1 = new Unit("Dima","", 100, 20, 10);
                Unit unit2 = new Unit("Ivan","", 200, 20, 20);
                unit1.Attack(unit2);
                Unit unit3 = new Unit("Monster","", 100, 20, 5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}
