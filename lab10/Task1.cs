using System;

namespace lab10

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
    protected int StartHour;
    protected int FinishHour;

    protected Group(int startHour, int finishHour, Group successor = null)
    {
        StartHour = startHour;
        FinishHour = finishHour;
        Successor = successor;
    }

    public Group Successor { protected get; set; }
    abstract public void DoWork(DateTime time);
}

class EarlyGroup : Group
{
    public EarlyGroup(int startHour, int finishHour, Group successor = null) : base(startHour, finishHour, successor)
    {
    }

    public override void DoWork(DateTime time)
    {
        if (time.Hour >= StartHour && time.Hour < FinishHour - 1)
            Console.WriteLine("Early Group is doing work");
        else if (Successor != null)
            Successor.DoWork(time);
        else
            throw new ApplicationException("ChainOfResponsibility object " +
                                           "exhausted all successors without call being handled.");
    }
}