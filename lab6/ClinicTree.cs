using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security;

namespace lab6
{
    abstract class ClinicComponent
    {
        protected string Name;
        protected int SickPeoples;
        
        public ClinicComponent(string name)
        {
            this.Name = name;
        }
        
        public abstract void Display(int depth);

        public abstract int GetSickPeoplesInfo();

        public abstract void ConductMedExam(string name);
        
        public virtual void Add(ClinicComponent clinicComponent){}
 
        public virtual void Remove(ClinicComponent clinicComponent) {}
        
    }
    
    class Composite : ClinicComponent
    {
        private readonly List<ClinicComponent> _children = new List<ClinicComponent>();
        private readonly Doctor _headDoctor;
        
        public Composite(string name, Doctor headDoctor) : base(name)
        {
            SickPeoples = 0;
            _headDoctor = headDoctor;
        }

        public override void Add(ClinicComponent clinicComponent)
        {
            _children.Add(clinicComponent);
        }
        public override void Remove(ClinicComponent clinicComponent)
        {
            _children.Remove(clinicComponent);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String(' ', depth) + Name + " (HeadDoctor - " + _headDoctor.Name + "(" + _headDoctor.GetSickPeoplesInfo() + ") | Sick Peoples = " + SickPeoples + " )");
            foreach (ClinicComponent component in _children)
                component.Display(depth + 2);
        }
        
        public override int GetSickPeoplesInfo()
        {
            SickPeoples = _headDoctor.GetSickPeoplesInfo();
            foreach (ClinicComponent component in _children)
                SickPeoples += component.GetSickPeoplesInfo();
            return SickPeoples;
        }
        
        public override void ConductMedExam(string name)
        {
            foreach (ClinicComponent component in _children)
                component.ConductMedExam(name);
            _headDoctor.ConductMedExam(name);
        }
    }

    class Doctor : ClinicComponent
    {
        public Doctor(string name, int sickPeoples) : base(name)
        {
            SickPeoples = sickPeoples;
        }
        
        public new string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String(' ', depth) + "Doctor: " + base.Name + "(" + SickPeoples + ")");
        }

        public override int GetSickPeoplesInfo()
        {
            return SickPeoples;
        }

        public override void ConductMedExam(string name)
        {
            SickPeoples++;
            Console.WriteLine("Doctor " + Name + " conduct a med exam for " + name);
        }
    }
}