using System;
using System.IO;

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
            const string text =
                "За допомогою шаблона проектування реалізувати декілька\nрізноманітних способів зберігання тексту до файлу. " +
                "Перший спосіб –\nзвичайний: зберігаємо текст без внесення жодних змін. Другий спосіб –\nвидаляємо всі зайві " +
                "пробіли з тексту перед збереженням. Третій спосіб –\nзастосовуємо кодування тексту (або архівацію). В залежності" +
                " від\nналаштування програми забезпечити збереження тексту до файлу\nнайбільш доцільним способом.";
            const string path = "/home/daniel/Programming/kpi_oop/lab9/Resources/";
            OutputSystem system = new OutputSystem(new DefaultSave());
            system.SaveDataToFile(path + "default.txt", text);
            system.SaveToFile = new SaveWithoutSpaces();
            system.SaveDataToFile(path + "without_space.txt", text);
            system.SaveToFile = new EncryptSave();
            system.SaveDataToFile(path + "ecrypt.txt", text);
            Console.WriteLine("------------ DefaultSave ------------");
            Console.WriteLine(File.ReadAllText(path + "default.txt"));
            Console.WriteLine("------------ SaveWithoutSpaces ------------");
            Console.WriteLine(File.ReadAllText(path + "without_space.txt"));
            Console.WriteLine("------------ Encrypt Save ------------");
            Console.WriteLine(File.ReadAllText(path + "ecrypt.txt"));
        }
    }
}