using System;

namespace lab9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("///////////////// Task1 /////////////////");
            ClientCard card = new ClientCard();
            card.Pay(1000);
            card.Pay(5000);
            card.Pay(1000);
            card.Pay(5000);
            card.Pay(1000);
            Console.WriteLine("///////////////// Task2 /////////////////");
        }
    }
}