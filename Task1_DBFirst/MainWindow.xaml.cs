using System;
using System.Collections.Generic;
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
using Task1_DBFirst.Models;

namespace Task1_DBFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Customer Customer { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            using (var context = new zzaContext())
            {
                Customer = new Customer()
                {
                    City = "Kharkiv", 
                    Email = "ZubLena@hmail.com",
                    FirstName = "Elena", 
                    LastName = "Zub" 
                };

                context.Customer.Update(Customer);
                context.SaveChanges();
            }           
        }
    }
}
