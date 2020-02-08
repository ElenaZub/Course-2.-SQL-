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
using Task2_CodeFirst.Models;

namespace Task2_CodeFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Product CurrentProduct { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            using (var context = new ShopContext())
            {
                CurrentProduct = new Product()
                {
                    Type = "Pizza",
                    Name = "My pizza",
                    Description = "Fine pizza",
                    Image = "Good-good pizza"
                };

                context.Products.Add(CurrentProduct);
                context.SaveChanges();
            }
        }
    }
}
