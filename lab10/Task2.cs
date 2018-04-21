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

        public void Edit(string prev, string newData)
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

    abstract class Command
    {
        protected Database _database;

        protected Command(Database database)
        {
            _database = database;
        }

        public abstract void Execute();
    }

    class AddCommand : Command
    {
        public string Data { get; set; }

        public AddCommand(Database database, string data) : base(database)
        {
            Data = data;
        }

        public override void Execute()
        {
            _database.Add(Data);
        }
    }

    class EditCommand : Command
    {
        public string Prev { get; set; }
        public string NewData { get; set; }

        public EditCommand(Database database, string prev, string newData) : base(database)
        {
            Prev = prev;
            NewData = newData;
        }

        public override void Execute()
        {
            _database.Edit(Prev, NewData);
        }
    }

    class RemoveCommand : Command
    {
        public string Data { get; set; }

        public RemoveCommand(Database database, string data) : base(database)
        {
            Data = data;
        }

        public override void Execute()
        {
            _database.Remove(Data);
        }
    }
}