using System;
using System.Collections.Generic;
using System.IO;

namespace lab8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("///////////////// Task1 /////////////////");
            FileList list = new FileList("/home/daniel/Programming/kpi_oop/lab8/");
            FileList cloneList = (FileList)list.Clone();
            Console.WriteLine("///CLONE///");
            cloneList.ToDisplay();
            FileList cloneListWithMove = (FileList) list.CloneWithMove("/home/daniel/Programming/kpi_oop/lab8/bin");
            Console.WriteLine("/// ClONE WITH MOVE ///");
            cloneListWithMove.ToDisplay();
            Console.WriteLine("///////////////// Task2 /////////////////");
            Manager manager = new Manager("Daniel");
            Ticket ticket1 = manager.OrderTicket(TicketType.Entrance, 700);
            Ticket ticket2 = manager.OrderTicket(TicketType.Default, 1500);
            Ticket ticket3 = manager.OrderTicket(TicketType.VIP, 1500);
            Console.WriteLine(ticket1 + $" Price: {ticket1.CountPrice()}");
            Console.WriteLine(ticket2 + $"Price: {ticket2.CountPrice()}");
            Console.WriteLine(ticket3 + $"Price: {ticket3.CountPrice()}");
        }
    }
}