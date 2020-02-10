using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Binding_Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<Employee> employees = new ObservableCollection<Employee>()
            {
                new Employee{Name = "Anna Petrova", Department = "GIS", HiredDate = new DateTime(2010/11/04), IsManager = true},
                new Employee{Name = "Anton Ivanov", Department = "HR", HiredDate = new DateTime(2015/02/04), IsManager = true},
                new Employee{Name = "Alex Smith", Department = "GIS", HiredDate = new DateTime(2002/01/01), IsManager = false},
            };

            this.EmployeeDataGrid.ItemsSource = employees;
        }
    }
}
