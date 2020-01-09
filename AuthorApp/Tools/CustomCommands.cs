using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AuthorApp.Tools
{
    public static class CustomCommands
    {
        public static RoutedUICommand Change { get; set; }

        static CustomCommands()
        { 
            CustomCommands.Change = new RoutedUICommand(nameof(Change), nameof(Change), typeof(MainWindow));
        }
    }
}
