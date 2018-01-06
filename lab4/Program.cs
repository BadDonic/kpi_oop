using System;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace lab4
{
    internal static class Program
    {
         public static WeakReference CreateWeakRef()
        {
            return new WeakReference(new Unit("WeakUnit", "", 100, 100, 10));
        }
        static void Main(string[] args)
        {
            try
            {
                Unit unit1 = new Unit("Unit1", "", 100, 100, 10);
                Squad<Unit> units = new Squad<Unit>();
                units.Add(unit1);
                units.Add(new Unit("Unit2", "", 200, 300, 20));
                Console.WriteLine("Memory used before collection:    {0:N0}", GC.GetTotalMemory(false));                
                
                GC.Collect();
                GC.WaitForPendingFinalizers();
               
                Console.WriteLine("Memory used after full collection:   {0:N0}", GC.GetTotalMemory(true));

                GC.Collect();
                GC.WaitForPendingFinalizers();


                WeakReference weakRef = CreateWeakRef();
                Console.WriteLine("WeakRef is alive : " + weakRef.IsAlive);

                GC.Collect();
                GC.WaitForPendingFinalizers();

                
                Console.WriteLine("WeakRef is alive : " + weakRef.IsAlive);

                units.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                Console.WriteLine("Units does not exist: " + units.IsListExist());
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
