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
        RelayCommand addCommand1, addCommand2, addCommand3, addCommand4;
        RelayCommand editCommand1, editCommand2, editCommand3, editCommand4;
        RelayCommand deleteCommand1, deleteCommand2, deleteCommand3, deleteCommand4;
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
            db.Orders.Load();
            Orders = db.Orders.Local.ToBindingList();

        }

        internal RelayCommand AddCommand1
        {
            get
            {
                return  addCommand1 ??(addCommand1 = new RelayCommand((o) =>
                {

                    DialogWindow1 dialogWindow =  new DialogWindow1(new Phone());                           
                    
                    if (dialogWindow.ShowDialog() == true)
                    {
                        
                        db.Phones.Add( dialogWindow.Phone);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, " Заполни все поля");
                        }
                    }
                }));
            }
        }
        internal RelayCommand AddCommandEmployee
        {
            get
            {
                return addCommand2 ?? (addCommand2 = new RelayCommand((o) =>
                {

                    DialogWindow2 dialogWindow = new DialogWindow2(new Employee());

                    if (dialogWindow.ShowDialog() == true)
                    {

                        db.Employees.Add(dialogWindow.Employee);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, " Заполни все поля");
                        }
                    }
                }));
            }
        }
        internal RelayCommand AddCommand3
        {
            get
            {
                return addCommand3 ?? (addCommand3 = new RelayCommand((o) =>
                {

                    DialogWindow3 dialogWindow = new DialogWindow3(new Department());

                    if (dialogWindow.ShowDialog() == true)
                    {

                        db.Departments.Add(dialogWindow.Department);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, " Заполни все поля");
                        }
                    }
                }));
            }
        }
        internal RelayCommand AddCommand4
        {
            get
            {
                return addCommand4 ?? (addCommand4 = new RelayCommand((o) =>
                {

                    DialogWindow4 dialogWindow = new DialogWindow4(new Order());

                    if (dialogWindow.ShowDialog() == true)
                    {

                        db.Orders.Add(dialogWindow.Order);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, " Заполни все поля");
                        }
                    }
                }));
            }
        }
        internal RelayCommand EditCommand1
        {
            get
            {
                return editCommand1 ?? (editCommand1 = new RelayCommand((selectedItem) =>
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
                            try
                            {
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, " Заполни все поля");
                            }
                        }
                    }
                }));
            }
        }
        internal RelayCommand EditCommandEmployee
        {
            get
            {
                return editCommand2 ?? (editCommand2 = new RelayCommand((selectedItem) =>
                {
                    if (selectedItem == null) return;

                    Employee employee = selectedItem as Employee;
                    DialogWindow2 dialogWindow = new DialogWindow2(employee);

                    if (dialogWindow.ShowDialog() == true)
                    {
                        employee = db.Employees.Find(dialogWindow.Employee.Id);
                        if (employee != null)
                        {
                            employee = dialogWindow.Employee;
                            db.Entry(employee).State = EntityState.Modified;
                            try
                            {
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, " Заполни все поля");
                            }
                        }
                    }
                }));
            }
        }
        internal RelayCommand EditCommand3
        {
            get
            {
                return editCommand3 ?? (editCommand3 = new RelayCommand((selectedItem) =>
                {
                    if (selectedItem == null) return;

                    Department department = selectedItem as Department;
                    DialogWindow3 dialogWindow = new DialogWindow3(department);

                    if (dialogWindow.ShowDialog() == true)
                    {
                        department = db.Departments.Find(dialogWindow.Department.Id);
                        if (department != null)
                        {
                            department = dialogWindow.Department;
                            db.Entry(department).State = EntityState.Modified;
                            try
                            {
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, " Заполни все поля");
                            }
                        }
                    }
                }));
            }
        }
        internal RelayCommand EditCommand4
        {
            get
            {
                return editCommand4 ?? (editCommand4 = new RelayCommand((selectedItem) =>
                {
                    if (selectedItem == null) return;

                    Order order = selectedItem as Order;
                    DialogWindow4 dialogWindow = new DialogWindow4(order);

                    if (dialogWindow.ShowDialog() == true)
                    {
                        order = db.Orders.Find(dialogWindow.Order.Id);
                        if (order != null)
                        {
                            order = dialogWindow.Order;
                            db.Entry(order).State = EntityState.Modified;
                            try
                            {
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, " Заполни все поля");
                            }
                        }
                    }
                }));
            }
        }
        internal RelayCommand DeleteCommand1
            {
                get => deleteCommand1 ?? (deleteCommand1 = new RelayCommand((selectedItem) =>
                {
            if (selectedItem == null) return;
            Phone phone = selectedItem as Phone;
            if (MessageBox.Show($"Удалить {phone.Title} из базы данных?", "Точно?", MessageBoxButton.OKCancel) != MessageBoxResult.OK) return;

            db.Phones.Remove(phone);
            db.SaveChanges();
        }));
            }
        internal RelayCommand DeleteCommandEmployee
        {
            get => deleteCommand2 ?? (deleteCommand2 = new RelayCommand((selectedItem) =>
            {
                if (selectedItem == null) return;
                Employee employee = selectedItem as Employee;
                if (MessageBox.Show($"Удалить {employee.FirstName} {employee.LastName} из базы данных?", "Точно?", MessageBoxButton.OKCancel) != MessageBoxResult.OK) return;

                db.Employees.Remove(employee);
                db.SaveChanges();
            }));
        }
        internal RelayCommand DeleteCommand3
        {
            get => deleteCommand3 ?? (deleteCommand3 = new RelayCommand((selectedItem) =>
            {
                if (selectedItem == null) return;
                Department department = selectedItem as Department;
                if (MessageBox.Show($"Удалить {department.Name}  из базы данных?", "Точно?", MessageBoxButton.OKCancel) != MessageBoxResult.OK) return;

                db.Departments.Remove(department);
                db.SaveChanges();
            }));
        }
        internal RelayCommand DeleteCommand4
        {
            get => deleteCommand4 ?? (deleteCommand4 = new RelayCommand((selectedItem) =>
            {
                if (selectedItem == null) return;
                Order order = selectedItem as Order;
                if (MessageBox.Show($"Удалить заказ №{order.Id} из базы данных?", "Точно?", MessageBoxButton.OKCancel) != MessageBoxResult.OK) return;

                db.Orders.Remove(order);
                db.SaveChanges();
            }));
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
