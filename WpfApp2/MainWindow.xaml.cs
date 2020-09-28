using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public string SelectedTabItemName { get; set; }
        ApplicationViewModel applicationViewModel;
        public MainWindow()
        {

            InitializeComponent();
            
            applicationViewModel = new ApplicationViewModel();
            DataContext = applicationViewModel;

            AddButton1.Command = applicationViewModel.AddCommand1;
            EditButton1.Command = applicationViewModel.EditCommand1;
            DeleteButton1.Command = applicationViewModel.DeleteCommand1;

            AddButton2.Command = applicationViewModel.AddCommandEmployee;
            EditButton2.Command = applicationViewModel.EditCommandEmployee;
            DeleteButton2.Command = applicationViewModel.DeleteCommandEmployee;

            AddButton3.Command = applicationViewModel.AddCommand3;
            EditButton3.Command = applicationViewModel.EditCommand3;
            DeleteButton3.Command = applicationViewModel.DeleteCommand3;

            AddButton4.Command = applicationViewModel.AddCommand4;
            EditButton4.Command = applicationViewModel.EditCommand4;
            DeleteButton4.Command = applicationViewModel.DeleteCommand4;
        }
        
    }
}
