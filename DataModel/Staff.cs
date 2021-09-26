using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.DataModel
{
    abstract class Staff
    {
        protected static ulong id;
        public ulong ID { get; set; }
        public uint Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Deportament Deportament { get; set; }
        abstract public double Salary { get; }
        public StaffTypes StaffType { set; get; }

        virtual public string GetName()
        { return String.Format("{0} : {1} {2}", ID, FirstName, LastName); } //Для отображения имени


        public Staff(Deportament deportament,StaffTypes type)
        {
            ID = ++id;
            Deportament = deportament;
            StaffType = type;
        }


    }

    public enum StaffTypes
    {
        Personal,
        Intern,
        Manager
    }
}
