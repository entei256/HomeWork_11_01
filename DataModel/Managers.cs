using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.DataModel
{
    class Managers : Staff
    {

        override public double Salary
        {
            get
            {
                double resoult = 0;  
                if ((Deportament.Staffs == null && Deportament.Deportaments == null) ||
                    (Deportament.Staffs.Count <= 0 && Deportament.Deportaments.Count <= 0))
                    return resoult;
                if (Deportament.Staffs != null || Deportament.Staffs.Count >= 0)
                {
                    foreach (var staff in Deportament.Staffs)
                    {
                        if (staff is Managers) //TO-DO: переписать на сравнение с текущий экземпляром.
                            continue;
                        resoult += ((Staff)staff).Salary;
                    }
                }

                if (Deportament.Deportaments != null || Deportament.Deportaments.Count >= 0)
                {
                    foreach (var dep in Deportament.Deportaments)
                    {
                        resoult += dep.AllSalary;
                    }
                }
                if (resoult * 0.15 > 1300) resoult = resoult * 0.15;  //Если 15% от всех зарплат больше 1300, то возвращаем.
                else resoult = 1300;  //Иначе передаем минимальную оплату.
                return resoult;      //возвараем оплату за месяц.
            }
        }

        public Managers(Deportament deportament) : base(deportament) 
        {
            //this.Deportament.ThereManager = true;  //Делаем так что в каждом депортаменте только 1 менеджер.
            this.FirstName = "Manager";
            this.LastName = ID.ToString();
        }

        public override string GetName()
        {
            return String.Format("Начальник {0}:{1} {0}",Deportament.Name,LastName,FirstName);
        }
    }

}
