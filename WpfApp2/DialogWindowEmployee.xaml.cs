using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    
    public partial class DialogWindow2 : Window
    {
        
        
        public Employee Employee { get; private set; }
       
        public DialogWindow2(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            if (employee.Sex == 1) radioButtonM.IsChecked = true;
            if (employee.Sex == 0) radioButtonF.IsChecked = true;
            DataContext = Employee;
            birthDate.SelectedDate =  Convert.ToDateTime(employee.BirthDate).Date;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (radioButtonM.IsChecked == true)
                Employee.Sex = 1;
            else Employee.Sex = 0;

            Employee.BirthDate = birthDate.SelectedDate.Value.Date.ToString("d");
            this.DialogResult = true;
        }
    }
}
