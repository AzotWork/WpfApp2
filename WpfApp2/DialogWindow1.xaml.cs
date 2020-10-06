﻿using System;
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
    public partial class DialogWindow1 : Window
    {
        public Phone Phone { get; private set; } 
        
        
        public DialogWindow1(Phone phone)
        {
            InitializeComponent();
            Phone = phone;

            DataContext = Phone;
            
            
        }
      
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
