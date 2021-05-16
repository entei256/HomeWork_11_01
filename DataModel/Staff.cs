using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.DataModel
{
    interface Staff
    {
        private static uint id = 0;
        public uint ID { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
    }
}
