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
        MainWindow mainWindow;
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
        
        public ApplicationViewModel()
        {
            db = new ApplicationContext();
            db.Phones.Load();
            Phones = db.Phones.Local.ToBindingList();
            db.Employees.Load();
            Employees = db.Employees.Local.ToBindingList();
            


        }

        internal RelayCommand AddCommand1
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand((o) =>
                {

                    DialogWindow1 dialogWindow =  new DialogWindow1(new Phone());                           
                    
                    if (dialogWindow.ShowDialog() == true)
                    {
                        
                        db.Phones.Add( dialogWindow.Phone);
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
