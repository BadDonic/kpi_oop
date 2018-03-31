using System;
using System.Runtime.InteropServices;

namespace lab7
{
    interface IOldRegistration
    {
        void SignUp(string firstName, string lastName, string city, int age, string email,
            string address, string keyword, string login, string password);
    }
    
    interface INewRegistration
    {
        void SignUp(string firstName, string lastName, string keyword, string login, string password);
    }

    class System : IOldRegistration
    {
        public void SignUp(string firstName, string lastName, string city, int age, string email,
            string address, string keyword, string login, string password)
        {
            Console.WriteLine($"SignUp: {firstName} {lastName} {city} {age} {email} {address}" +
                              $" {keyword} {login} {password}");
        }
    }

    class RegistrationAdapter : INewRegistration
    {
        private IOldRegistration _oldSystem;

        public RegistrationAdapter(IOldRegistration system)
        {
            _oldSystem = system;
        }
        
        public void SignUp(string firstName, string lastName, string keyword, string login, string password)
        {
            _oldSystem.SignUp(firstName, lastName, "City", 0, "Email@email.com", "Address", keyword, login, password);
        }
    }
}