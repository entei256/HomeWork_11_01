using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.DataModel
{
    class Intern : Staff
    {
        override public double Salary
        {
            get
            {
                return 500;      //возвараем оплату за месяц.
            }
        }

        //Не нашел другого выхода кроме как сделать такую заглушку для конструктора
        public Intern(Deportament deportament) : base(deportament) { }
    }
}
