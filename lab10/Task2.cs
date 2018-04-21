using System;
using System.Collections.Generic;

namespace lab10
{
/*                    Task№ 2
Для роботи з даними у інформаційній системі передбачена можливість
виконання таких дій над елементами масиву записів: «додати»,
«видалити», «редагувати». Для ініціювання виконання кожної з цих
команд передбачений окремий пункт меню з відповідною назвою. За
допомогою шаблону проектування реалізувати обробку зазначених
вище команд у порядку, визначеному користувачем.
*/
    class Database
    {
        private List<string> DataList;

        public Database(List<string> dataList)
        {
            DataList = dataList;
        }

        public void Add(string data)
        {
            DataList.Add(data);
            Console.WriteLine($"Add new data to list:{data}");
        }

        public void Rewrite(string prev, string newData)
        {
            if (DataList.Contains(prev))
            {
                DataList[DataList.IndexOf(prev)] = newData;
                Console.WriteLine($"Replace Prev:{prev} on New:{newData}");
            }
            else
                Console.WriteLine($"Can not found this data:{prev}");
        }

        public void Remove(string removeData)
        {
            if (DataList.Contains(removeData))
            {
                DataList.Remove(removeData);
                Console.WriteLine($"Remove: {removeData}");
            }
            else
                Console.WriteLine($"Can not found this data:{removeData}");
        }
    }
}