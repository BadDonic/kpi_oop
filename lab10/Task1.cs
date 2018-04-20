using System;

namespace lab10
{
/*                    Task№ 1
На певному заводі цілодобово працюють 3 зміни. І зміна – з 6.00 до
15.00, ІІ зміна – з 14.00 до 23.00 та ІІІ зміна – з 22.00 до 7.00. Якщо
завдання робітникам певної зміни надходить менш, ніж за годину до
закінчення зміни, вони передають його на виконання наступній зміні. За
допомогою шаблону проектування реалізувати механізм обробки
завдань робітниками описаного заводу.
*/
    abstract class Group
    {
        public Group Successor { protected get; set; }
        abstract public void DoWork(DateTime time);
    }

    class EarlyGroup : Group
    {
        public override void DoWork(DateTime time)
        {
            if (time.Hour >= 6 && time.Hour < 14)
                Console.WriteLine($"Early Group takes work in {time.Hour}");
            else if (Successor != null)
            {
                if (time.Hour < 15) Console.WriteLine("Early Group leave work for Afternoon Group");
                Successor.DoWork(time);
            }
            else
                throw new ApplicationException("ChainOfResponsibility object " +
                                               "exhausted all successors without call being handled.");
        }
    }

    class AfternoonGroup : Group
    {
        public override void DoWork(DateTime time)
        {
            if (time.Hour >= 14 && time.Hour < 22)
                Console.WriteLine($"Afternoon Group takes work in {time.Hour}");
            else if (Successor != null)
            {
                if (time.Hour < 15) Console.WriteLine("Afternoon Group leave work for Evening Group");
                Successor.DoWork(time);
            }
            else
                throw new ApplicationException("ChainOfResponsibility object " +
                                               "exhausted all successors without call being handled.");
        }
    }

    class EveningGroup : Group
    {
        public override void DoWork(DateTime time)
        {
            if (time.Hour >= 22 && time.Hour < 6)
                Console.WriteLine($"Evening Group takes work in {time.Hour}");
            else if (Successor != null)
            {
                if (time.Hour < 15) Console.WriteLine("Evening Group leave work for Early Group");
                Successor.DoWork(time);
            }
            else
                throw new ApplicationException("ChainOfResponsibility object " +
                                               "exhausted all successors without call being handled.");
        }
    }
}