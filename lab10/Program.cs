using System;

namespace lab10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("///////////////// Task1 /////////////////");
            EveningGroup eveningGroup = new EveningGroup(22, 7);
            AfternoonGroup afternoonGroup = new AfternoonGroup(14, 23, eveningGroup);
            EarlyGroup earlyGroup = new EarlyGroup(6, 15, afternoonGroup);
            eveningGroup.Successor = earlyGroup;
            earlyGroup.DoWork(DateTime.Now);
            Console.WriteLine("///////////////// Task2 /////////////////");
        }
    }
}