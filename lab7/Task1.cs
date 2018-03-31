using System;
using System.Runtime.Remoting.Channels;

namespace lab7
{
    interface IBankSystem
    {
        void GetTransactionList(Client client);
    }

    public class BankSystem : IBankSystem
    {
        public void GetTransactionList(Client client)
        {
            Console.WriteLine($"{client.Name}'s transaction list");
        }
    }

//Proxy Object
    public class ProxyBankSystem : IBankSystem
    {
        private static IBankSystem _system;
        public ProxyBankSystem() {}
        public void GetTransactionList(Client client)
        {
            if (client.IsPremium)
            {
                if (_system == null)
                    _system = new BankSystem();
                _system.GetTransactionList(client);
                return;
            }
            Console.WriteLine($"This operation is Forbidden for {client.Name}");
        }
    }

    public class Client
    {
        public string Name { get; set; }
        public bool IsPremium { get; set; }

        public Client(string name, bool isPremium)
        {
            Name = name;
            IsPremium = isPremium;
        }
    }
}