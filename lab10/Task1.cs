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
        protected int StartTime;
        protected int FinishTime;

        protected Group(int startTime, int finishTime, Group successor = null)
        {
            Successor = successor;
            FinishTime = finishTime;
            StartTime = startTime;
        }

        public Group Successor { protected get; set; }
        abstract public void DoWork(DateTime time);
    }

    class EarlyGroup : Group
    {
        public EarlyGroup(int startTime, int finishTime, Group successor = null) : base(startTime, finishTime,
            successor)
        {
        }

        public override void DoWork(DateTime time)
        {
            if (time.Hour >= StartTime && time.Hour < FinishTime - 1)
                Console.WriteLine($"Early Group takes work on {time.Hour} hour");
            else if (Successor != null)
            {
                Console.WriteLine((FinishTime - time.Hour < 1)
                    ? "Early Group leaves work for next group"
                    : $"Early Group can't do work in {time.Hour} hour");
                Successor.DoWork(time);
            }
            else
                throw new ApplicationException("ChainOfResponsibility object " +
                                               "exhausted all successors without call being handled.");
        }
    }

    class AfternoonGroup : Group
    {
        public AfternoonGroup(int startTime, int finishTime, Group successor = null) : base(startTime, finishTime,
            successor)
        {
        }

        public override void DoWork(DateTime time)
        {
            if (time.Hour >= StartTime && time.Hour < FinishTime - 1)
                Console.WriteLine($"Afternoon Group takes work on {time.Hour} hour");
            else if (Successor != null)
            {
                Console.WriteLine((FinishTime - time.Hour < 1)
                    ? "Afternoon Group leaves work for next group"
                    : $"Afternoon Group can't do work in {time.Hour} hour");
                Successor.DoWork(time);
            }
            else
                throw new ApplicationException("ChainOfResponsibility object " +
                                               "exhausted all successors without call being handled.");
        }
    }

    class EveningGroup : Group
    {
        public EveningGroup(int startTime, int finishTime, Group successor = null) : base(startTime, finishTime,
            successor)
        {
        }

        public override void DoWork(DateTime time)
        {
            if (time.Hour >= StartTime || time.Hour < FinishTime - 1)
                Console.WriteLine($"Evening Group takes work on {time.Hour} hour");
            else if (Successor != null)
            {
                Console.WriteLine((FinishTime - time.Hour < 1)
                    ? "Evening Group leaves work for next group"
                    : $"Evening Group can't do work in {time.Hour} hour");
                Successor.DoWork(time);
            }
            else
                throw new ApplicationException("ChainOfResponsibility object " +
                                               "exhausted all successors without call being handled.");
        }
    }
}