using System;
using System.Collections.Generic;

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
            Database database = new Database(new List<string>());
            AddCommand addCommand = new AddCommand(database, "data");
            EditCommand editCommand = new EditCommand(database, "lab", "data");
            RemoveCommand removeCommand = new RemoveCommand(database, "data");
            Invoker invoker = new Invoker(addCommand);
            invoker.Execute();
            invoker.Command = editCommand;
            invoker.Execute();
            editCommand.Prev = "data";
            editCommand.NewData = "lab";
            invoker.Execute();
            invoker.Command = removeCommand;
            invoker.Execute();
            removeCommand.Data = "lab";
            invoker.Execute();
        }
    }
}