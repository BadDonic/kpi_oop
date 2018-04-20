using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace lab9
{
/*                     Task№ 2
За допомогою шаблона проектування реалізувати декілька
різноманітних способів зберігання тексту до файлу. Перший спосіб –
звичайний: зберігаємо текст без внесення жодних змін. Другий спосіб –
видаляємо всі зайві пробіли з тексту перед збереженням. Третій спосіб –
застосовуємо кодування тексту (або архівацію). В залежності від
налаштування програми забезпечити збереження тексту до файлу
найбільш доцільним способом.
*/
    class OutputSystem
    {
        public ISaveToFile SaveToFile { private get; set; }

        public OutputSystem(ISaveToFile saveToFile)
        {
            SaveToFile = saveToFile ?? throw new NullReferenceException();
        }

        public void SaveDataToFile(string path, string data)
        {
            SaveToFile.SaveDataToFile(path, data);
        }
    }

    interface ISaveToFile
    {
        void SaveDataToFile(string path, string data);
    }

    class DefaultSave : ISaveToFile
    {
        public void SaveDataToFile(string path, string data)
        {
            File.WriteAllText(path, data);
        }
    }

    class SaveWithoutSpaces : ISaveToFile
    {
        public void SaveDataToFile(string path, string data)
        {
            File.WriteAllText(path, Regex.Replace(data, @"\s+", ""));
        }
    }

    class EncryptSave : ISaveToFile
    {
        public void SaveDataToFile(string path, string data)
        {
            File.WriteAllText(path, Convert.ToBase64String(Encoding.Unicode.GetBytes(data)));
        }
    }
}