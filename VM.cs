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
        }

        private void testData(ObservableCollection<DataModel.Deportament> deportaments)
        {
            var ran = new Random().Next(1, 10);
            for (int i = 0; i <= ran;i++)
            {
                deportaments.Add(new DataModel.Deportament());

                for (int ranStafCount = new Random().Next(1,10); ranStafCount >= deportaments[i].Staffs.Count;)
                {
                    int ranStafType = new Random().Next(1, 4);
                    switch (ranStafType)
                    {
                        case 1:
                            deportaments[i].AddStaff(new DataModel.Managers(deportaments[i]));
                            break;
                        case 2:
                            deportaments[i].AddStaff(new DataModel.Personal(deportaments[i]));
                            break;
                        case 3:
                            deportaments[i].AddStaff(new DataModel.Intern(deportaments[i]));
                            break;
                    }
                }
                int rand = new Random().Next(1, 100);
                if (rand > 85)
                    testData(deportaments[i].Deportaments);
            }
            
        }
    }
}
