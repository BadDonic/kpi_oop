using System;
using System.Collections.Generic;
using System.Dynamic;

namespace lab6
{
    public enum MedicineType
    {
        antibiotic, anti_inflammatory, stomach
    }
    class Medicine
    {
        protected string _name;
        protected double _price;
        protected string _expirationDate;
        protected MedicineType _type;

        public Medicine(){}
        
        public Medicine(string name, double price, string expirationDate, MedicineType type)
        {
            _name = name;
            _price = price;
            _expirationDate = expirationDate;
            _type = type;
        }

        public virtual void Show_Info()
        {
            Console.WriteLine("Name: " + _name + "| Price: " + _price + "| Date: " + "| Type: " + _type);
        }

        public virtual void CheckInList(List<Medicine> list)
        {
            foreach (Medicine med in list)
            {
                if (med._name == _name)
                {
                    Console.WriteLine("Find!!!");
                    Show_Info();
                }
            }
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public MedicineType Type
        {
            get => _type;
            set => _type = value;
        }
    }

    abstract class Decorator : Medicine
    {
        protected Medicine medicine;

        public override void CheckInList(List<Medicine> list)
        {
            medicine?.CheckInList(list);
        }

        public override void Show_Info()
        {
            medicine?.Show_Info();
        }

        public Decorator(Medicine medicine)
        {
            this.medicine = medicine;
        }
    }

    class ImportMedicine : Decorator
    {
        private string _sertificate;

        public ImportMedicine(Medicine med, string sertificate) : base(med)
        {
            _sertificate = sertificate;
        }
        
        public override void Show_Info()
        {
            Console.WriteLine("This medicine (" + _name + ") is Sertificated by " + _sertificate);
            base.Show_Info();
        }

        public override void CheckInList(List<Medicine> list)
        {
            foreach (var med in list)
            {
                if (med.Name != _name) continue;
                Console.WriteLine("Find!!!");
                Show_Info();
                bool exist = false;
                Console.Write("Analogs: ");
                foreach (var it in list)
                {
                    if (it.Type != Type || it.Name == Name) continue;
                    Console.WriteLine();
                    it.Show_Info();
                    exist = true;

                }
                if (!exist)
                    Console.Write("Nothing"); 
                return;
            }
        }
    }

}