using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System;
using System.Runtime.CompilerServices;
using System.Data.Entity;
using System.Windows;

namespace WpfApp2
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;
        IEnumerable<Phone> phones;
        IEnumerable<Employee> employees;
        IEnumerable<Department> departments;
        IEnumerable<Order> orders;
        public IEnumerable<Phone> Phones
        {
            get => phones;
            set
            {
                phones = value;
                OnPropertyChanged(nameof(Phones));
            }
        }
        public IEnumerable<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
        public IEnumerable<Department> Departments
        {
            get => departments;
            set
            {
                departments = value;
                OnPropertyChanged(nameof(Departments));
            }
        }
        public IEnumerable<Order> Orders
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }
        public ApplicationViewModel()
        {
            db = new ApplicationContext();
            db.Phones.Load();
            Phones = db.Phones.Local.ToBindingList();
            db.Employees.Load();
            Employees = db.Employees.Local.ToBindingList();
            db.Departments.Load();
            Departments = db.Departments.Local.ToBindingList();


        }

        internal RelayCommand AddCommand1
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand((o) =>
                {

                    DialogWindow1 dialogWindow =  new DialogWindow1(new Phone("","",0));                           
                    
                    if (dialogWindow.ShowDialog() == true)
                    {
                        
                        db.Phones.Add( dialogWindow.Phone);
                        db.SaveChanges();
                    }
                }));
            }
        }
        internal RelayCommand AddCommand2
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand((o) =>
                {

                    DialogWindow1 dialogWindow = new DialogWindow1(new Employee());

                    if (dialogWindow.ShowDialog() == true)
                    {

                        db.Employees.Add(dialogWindow.Employee);
                        db.SaveChanges();
                    }
                }));
            }
        }
        internal RelayCommand EditCommand1
        {
            get
            {
                return editCommand ?? (editCommand = new RelayCommand((selectedItem) =>
                {
                    if (selectedItem == null) return;

                    Phone phone = selectedItem as Phone;
                    DialogWindow1 dialogWindow = new DialogWindow1(phone);

                    if (dialogWindow.ShowDialog() == true)
                    {
                        phone = db.Phones.Find(dialogWindow.Phone.Id);
                        if (phone != null)
                        {
                            phone = dialogWindow.Phone;
                            db.Entry(phone).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }));
            }
        }
            internal RelayCommand DeleteCommand1
            {
                get => deleteCommand ?? (deleteCommand = new RelayCommand((selectedItem) =>
                {
            if (selectedItem == null) return;
            Phone phone = selectedItem as Phone;
            if (MessageBox.Show($"Delete {phone.ToString()} from DataBase?", "Deleting?", MessageBoxButton.OKCancel) != MessageBoxResult.OK) return;

            db.Phones.Remove(phone);
            db.SaveChanges();
        }));
            }

    void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
