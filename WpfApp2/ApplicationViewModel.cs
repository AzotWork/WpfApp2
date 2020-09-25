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

        //internal RelayCommand AddCommand
        //{
        //    get
        //    {
        //        return addCommand ?? (addCommand = new RelayCommand((o) =>
        //        {
        //            DialogWindow dialogWindow = new DialogWindow(new Phone());
        //            if (dialogWindow.ShowDialog() ==true)
        //            {
        //                Object obj = dialogWindow.Entity;
        //                db.Phones.Add(obj as Phone);
        //                db.SaveChanges();
        //            }
        //        }));
        //    }
        //}

        //internal RelayCommand EditCommand
        // {
        //     get
        //     {
        //         return editCommand ?? (editCommand = new RelayCommand((selectedItem) => 
        //         {
        //             if (selectedItem == null) return;

        //             Entity entity = selectedItem as Entity;
        //             DialogWindow dialogWindow = new DialogWindow(entity);

        //             if(dialogWindow.ShowDialog()==true)
        //             {
        //                 entity = db.Phones.Find(dialogWindow.Entity.Id);
        //                 if(entity!=null)
        //                 {
        //                     entity = dialogWindow.Entity;
        //                     db.Entry(entity).State = EntityState.Modified;
        //                     db.SaveChanges();
        //                 }
        //             }
        //         }));
        //     }
        // }
        //    //internal RelayCommand DeleteCommand
        //    {
        //        get => deleteCommand ?? (deleteCommand = new RelayCommand((selectedItem) =>
        //        {
        //            if (selectedItem == null) return;             
        //            Entity entity = selectedItem as Entity;
        //            if (MessageBox.Show($"Delete {entity.ToString()} from DataBase?","Deleting?",MessageBoxButton.OKCancel) != MessageBoxResult.OK) return;

        //            db.Phones.Remove(entity as Phone);
        //            db.SaveChanges();
        //        }));
        //    }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
