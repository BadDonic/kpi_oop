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
            System system = new System();
            system.SignUp("Ivan", "Petrov", "Kiev", 18, "dzenik@gmail.com",
                "Frynse 105", "OOP", "MysiPysi", "123");
            RegistrationAdapter adapter = new RegistrationAdapter(system);
            adapter.SignUp("Ivan", "Petrov", "OOP", "MysiPysi", "123");
        }
    }
}