using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace WpfApp1
{
    class VM
    {
        public ObservableCollection<DataModel.Deportament> Deportaments { get; set; } = new ObservableCollection<DataModel.Deportament>();


        public VM()
        {
            testData(Deportaments);
            //MessageBox.Show("Load Complite!");
        }

        private void testData(ObservableCollection<DataModel.Deportament> deportaments)
        {
            var run = new Random().Next(1, 10);
            for (int i = 0; i <= run;i++)
            {
                deportaments.Add(new DataModel.Deportament());

                for (int y = new Random().Next(1,10); y >= deportaments[i].Staffs.Count;)
                {
                    deportaments[i].AddStaff(new DataModel.Intern(deportaments[i]));
                }
                int rand = new Random().Next(1, 100);
                if (rand > 85)
                    testData(deportaments[i].Deportaments);
            }
            
        }
    }
}
