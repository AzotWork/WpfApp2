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

            
        }
        //void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    PhoneWindow phoneWindow = new PhoneWindow(new Phone());
        //    if(phoneWindow.ShowDialog()==true)
        //    {
        //        Phone phone = phoneWindow.Phone;
        //        db.Phones.Add(phone);
        //        db.SaveChanges();
        //    }
        //}
        //void Edit_Click(object sender, RoutedEventArgs e)
        //{
        //    if (phonesList.SelectedItem == null) return;

        //    Phone phone = phonesList.SelectedItem as Phone;
        //    PhoneWindow phoneWindow = new PhoneWindow(phone);

        //    if(phoneWindow.ShowDialog() == true)
        //    {
        //        phone = db.Phones.Find(phoneWindow.Phone.Id);
        //        if(phone!=null)
        //        {
        //            phone.Company = phoneWindow.Phone.Company;
        //            phone.Title = phoneWindow.Phone.Title;
        //            phone.Price = phoneWindow.Phone.Price;
        //            db.Entry(phone).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //    }
        //}
        //void Delete_Click(object sender, RoutedEventArgs e)
        //{
        //    if (phonesList.SelectedItem == null) return;
        //    Phone phone = phonesList.SelectedItem as Phone;
        //    db.Phones.Remove(phone);
        //    db.SaveChanges();
        //}
    }
}
