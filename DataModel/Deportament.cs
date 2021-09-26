using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace WpfApp1.DataModel
{
    class Deportament
    {
        private static ulong id;            //Счетчик ID
        public ulong ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Deportament> Deportaments { get; set; }      //Коллекция дочерних депортаментов. 
        public ObservableCollection<Staff> Staffs { get; set; }                  //Коллекция сотрудников.
        public int CountStaff 
        { 
            get 
            { 
                if (Staffs == null)
                    return 0;
                return Staffs.Count;                
            } 
        }                        //Число сотрудников
        public double AllSalary
        {

            get
            {
                double resoult = 0;
                if ((Staffs == null && Deportaments == null) || (Staffs.Count <= 0 && Deportaments.Count <= 0))
                    return 0;
                if (Staffs != null || Staffs.Count > 0)
                {
                    foreach (var staff in Staffs)
                    {
                        resoult += ((Staff)staff).Salary;
                    }
                }

                if (Deportaments != null || Deportaments.Count > 0)
                {
                    foreach (var dep in Deportaments)
                    {
                        resoult += dep.AllSalary;
                    }
                }

                return resoult;
            }
        }                    //Возвращаем общие запраты по депортаменту и дочерним депортаментам.
        public Deportament ParentDeportament { get; set; }


        public Deportament(Deportament parentDeportament = null)
        {
            id++;                      //увеличиваем счетчик.
            this.ID = id;               //Записываем ID текущего экземпляра.
            this.DateTime = DateTime.Now;  //При создании экземпляра, добовляем текущую дату.
            Deportaments = new ObservableCollection<Deportament>();
            Staffs = new ObservableCollection<Staff>();
            this.ParentDeportament = parentDeportament;
        }

        /// <summary>
        /// Добовление сотрудника
        /// </summary>
        /// <param name="staff">Передать обьект для добовления</param>
        public void AddStaff(Staff staff) {
            if (Staffs == null) Staffs = new ObservableCollection<Staff>();      //Если коллекция не создана, создаем ее.

            Staffs.Add(staff);
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="staff">Передать какого сотрудника удалить.</param>
        public void RemoveStaff(Staff staff) {
            if (Staffs == null || Staffs.Count <= 0) return;      //Если коллекция пуста, выходим из метода.



            Staffs.Remove(staff);
        }

        /// <summary>
        /// Изменение сотрудника
        /// </summary>
        /// <param name="changedStaff">Измененный сотрудник</param>
        /// <param name="targetStaff">Изменяемый сотрудник</param>
        public void ChangeStaff(Staff changedStaff,Staff targetStaff) {
            targetStaff = changedStaff;
        }

        /// <summary>
        /// Добовление дочернего депортамента.
        /// </summary>
        /// <param name="deportament">Депортмент для добовления</param>
        public void AddSubDeportamet(Deportament deportament) {
            if (Deportaments == null) Deportaments = new ObservableCollection<Deportament>();
            Deportaments.Add(deportament);
        }

        /// <summary>
        /// Удаление дочернего депортамента
        /// </summary>
        /// <param name="deportament">Депортамент для удаления</param>
        public void RemoveSubDeportamet(Deportament deportament) {
            if (Deportaments == null || Deportaments.Count <= 0) return;
            Deportaments.Remove(deportament);
        }
    }
}
