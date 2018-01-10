using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;

namespace lab5
{
    [DataContract]
    public class Unit: INotifyPropertyChanged
    {
        [DataMember]
        private string name;
        [DataMember]
        private double speed;
        [DataMember]
        private int damage;
        [DataMember]
        private int health;

        public Unit(string name, double speed, int damage, int health)
        {
            Name = name;
            Speed = speed;
            Damage = damage;
            Health = health;
        }

        public string Name { get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public double Speed { get => speed;
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }
        public int Damage { get => damage;
            set
            {
                damage = value;
                OnPropertyChanged("Damage");
            }
        }
        public int Health { get => health;
            set
            {
                health = value;
                OnPropertyChanged("Health");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
