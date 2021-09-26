using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddOrChangeStaff.xaml
    /// </summary>
    public partial class AddOrChangeStaff : Window
    {
        public DataModel.Staff CurrentStaff { get; set; }

        public AddOrChangeStaff()
        {
            InitializeComponent();
        }

        public AddOrChangeStaff(DataModel.Staff OldStaff) : base()
        {
            CurrentStaff = newStaff;
        }
    }
}
