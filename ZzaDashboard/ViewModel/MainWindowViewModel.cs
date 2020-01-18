using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        private ICustomersRepository Repository { get; set; }

        public ICommand GetCommand { get; set; }
        public MainWindowViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            this.Repository = new CustomersRepository();
            this.Customers = new ObservableCollection<Customer>();

            this.GetCommand = new RelayCommand(Execute);
        }

        private void Execute(object obj)
        {            
            var tmpList =  this.Repository.GetCustomersAsync().Result;

            foreach (var item in tmpList)
            {
                this.Customers.Add(item);
            }
        }
    }
}
