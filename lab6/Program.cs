using System;
using System.Collections.Generic;

namespace lab6
{
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine("---Part1---\n");
            Medicine med1 = new Medicine("med1", 100,"02.02.2019", MedicineType.antibiotic);
            Medicine med2 = new Medicine("med2", 60,"02.03.2119", MedicineType.anti_inflammatory);
            Medicine med3 = new Medicine("med3", 30,"12.12.2219", MedicineType.stomach);

            Medicine impMed1 = new ImportMedicine(new Medicine("Import Med1", 200,"04.22.2029", MedicineType.antibiotic), "MIT");
            Medicine impMed2 = new ImportMedicine(new Medicine("Import Med2", 90,"09.09.2079", MedicineType.stomach), "KPI");
            List<Medicine> list = new List<Medicine>{med1, med2, med3, impMed2, impMed1};

            foreach (Medicine it in list)
            {
                it.Show_Info();
            }
            
            med1.CheckInList(list);
            impMed1.CheckInList(list);
            
            Console.WriteLine("\n---Part2---\n");
            Composite clinic = new Composite("KPI-Clinic", new Doctor("Ivanovich", 100));
            Composite department1 = new Composite("Psyholog...", new Doctor("Petrovich", 78));
            Composite department2 = new Composite("Xiryrgicheskoe", new Doctor("Blekovich", 50));
    
            clinic.Add(department1);
            clinic.Add(department2);
            
            Doctor doctor1 = new Doctor("Daniel", 20);
            Doctor doctor2 = new Doctor("Viktoria", 10);
            Doctor doctor3 = new Doctor("Vadim", 5);
            department1.Add(doctor1);
            department1.Add(doctor2);
            department2.Add(doctor3);
            
            clinic.GetSickPeoplesInfo();
            clinic.Display(0);
            clinic.ConductMedExam("Oleh");
            clinic.Display(0);
        }
    }
}