using System;
using System.Runtime.CompilerServices;

namespace lab7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("///////////////// Task1 /////////////////");
            Client client1 = new Client("Daniel", false);            
            Client client2 = new Client("Vlados", true);
            ProxyBankSystem bank = new ProxyBankSystem();
            bank.GetTransactionList(client1);
            bank.GetTransactionList(client2);
            Console.WriteLine("///////////////// Task2 /////////////////");
            RegistrationSystem system = new RegistrationSystem();
            system.SignUp("Ivan", "Petrov", "Kiev", 18, "dzenik@gmail.com",
                "Frynse 105", "OOP", "MysiPysi", "123");
            RegistrationFacade facade = new RegistrationFacade(system);
            facade.SignUp("Ivan", "Petrov", "OOP", "MysiPysi", "123");
        }
    }
}