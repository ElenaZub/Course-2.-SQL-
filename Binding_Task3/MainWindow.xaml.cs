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

namespace Binding_Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var tasks = new List<Task>
            {
                 new Task { Name = "Grocery", Description = "Pick up grocery", Priority = 2},
                 new Task { Name = "Email", Description = "Check mail and reply on urgent", Priority = 3},
                 new Task { Name = "Laundry", Description = "Do my laundry", Priority = 1},

            };

            this.DataContext = tasks;
        }
    }
}
