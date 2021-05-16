using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfApp1.DataModel
{
    class Deportament
    {
        private static uint id;            //Счетчик ID
        public uint ID { get; set; }
        public DateTime DateTime { get; set; }
        public ObservableCollection<Deportament> Deportaments { get; set; }      //Коллекция дочерних депортаментов. 
        public ObservableCollection<Staff> Staffs { get; set; }                  //Коллекция сотруднико. TO-DO: переопределить тип после создании структуры сотрудников.
        public int CountStaff 
        { 
            get 
            { 
                if (Staffs == null)
                    return 0;
                return Staffs.Count;                
            } 
        }                        //Число сотрудников

        public Deportament()
        {
            id++;                      //увеличиваем счетчик.
            this.ID = id;               //Записываем ID текущего экземпляра.
            this.DateTime = DateTime.Now;  //При создании экземпляра, добовляем текущую дату.
            Deportaments = new ObservableCollection<Deportament>();
            Staffs = new ObservableCollection<Staff>();
        }
    }
}
