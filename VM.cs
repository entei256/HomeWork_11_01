using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    class VM
    {
        //Основная коллекция
        public ObservableCollection<DataModel.Deportament> Deportaments { get; set; } = new ObservableCollection<DataModel.Deportament>();

        //Конструктор
        public VM()
        {
            testData(Deportaments);
        }

        #region Комманды UI
        private BingCommand addStaff;

        #endregion

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

    //Класс для реализации комманд
    public class BingCommand : ICommand
    {
        private Action<object> execute;  
        private Func<object, bool> canExecute; 

        //Конструктор
        public BingCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }


        //Событие изменения команды.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        //Определение надо выполнять комманду или нет.
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        //Выполнение комманды
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
