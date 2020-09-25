using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp2
{
    public class Entity : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Phone : Entity
    {
        string title;
        string company;
        int price;
        
       
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Company
        {
            get => company;
            set
            {
                company = value;
                OnPropertyChanged(nameof(Company));
            }
        }
        public int Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        

        
    }
    public class Employee : Entity
    {
        string firstName;
        string lastName;
        string middleName;
        int birthDate;
        int sex;
        int department;

      
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string MiddleName
        {
            get => middleName;
            set
            {
                middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }
        public int BirthDate
        {
            get => birthDate;
            set
            {
                birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }
        public int Sex
        {
            get => sex;
            set
            {
                sex = value;
                OnPropertyChanged(nameof(Sex));
            }
        }
        public int Department
        {
            get => department;
            set
            {
                department = value;
                OnPropertyChanged(nameof(Department));
            }
        }        
    }
    public class Department : Entity
    {
        string name;
        int director;
        
       
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int Director
        {
            get => director;
            set
            {
                director = value;
                OnPropertyChanged(nameof(Director));
            }
        }
        
    }
    public class Order: Entity
    {
        string itemName;
        new public int Id { get; set; }
             
    }
}

