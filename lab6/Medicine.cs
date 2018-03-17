using System;
using System.Collections.Generic;

namespace lab6
{
    public enum MedicineType
    {
        TYPE1, TYPE2, TYPE3
    }
    public class Medicine
    {
        private string _name;
        private double _price;
        private string _expirationDate;
        private MedicineType _type;
        public Medicine(string name, MedicineType type, double price, string expirationDate)
        {
            Name = name;
            Price = price;
            ExpirationDate = expirationDate;
            Type = type;
        }

        public MedicineType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string ExpirationDate
        {
            get { return _expirationDate; }
            set { _expirationDate = value; }
        }
    }

}