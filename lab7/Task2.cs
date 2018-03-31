using System;

namespace lab7
{
    class RegistrationSystem
    {
        public void SignUp(string firstName, string lastName, string city, int age, string email,
            string address, string keyword, string login, string password)
        {
            Console.WriteLine($"SignUp: {firstName} {lastName} {city} {age} {email} {address}" +
                              $" {keyword} {login} {password}");
        }
    }

    class RegistrationFacade
    {
        private RegistrationSystem _system;

        public RegistrationFacade(RegistrationSystem system)
        {
            if (system == null) 
                system = new RegistrationSystem();
            _system = system;
        }
        
        public void SignUp(string firstName, string lastName, string keyword, string login, string password)
        {
            _system.SignUp(firstName, lastName, "City", 0, "Email@email.com", "Address", keyword, login, password);
        }
    }

//    class NewRegistrationSystem : RegistrationSystem
//    {
//        public void SignUp(string firstName, string lastName, string keyword, string login, string password)
//        {
//            base.SignUp(firstName, lastName, "City", 0, "Email@email.com", "Address", keyword, login, password);
//        }
//    }
}