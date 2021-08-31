using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.DataModel
{
    class Personal : Staff
    {
        public byte JobHours { get; set; }
        override public double Salary 
        { 
            get 
            {
                return JobHours * 12*30;      //возвараем оплату за месяц.
            } 
        }

        public Personal(Deportament deportament, byte Hours = 8) : base(deportament)
        {
            JobHours = Hours;
            this.FirstName = "Personal";
            this.LastName = ID.ToString();
        }
    }
}
