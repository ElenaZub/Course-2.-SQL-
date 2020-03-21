using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ViewModel
{
    public class CustomersListViewModel : INotifyPropertyChanged
    {
        private OrdersListViewModel ordersListViewModel;

        public OrdersListViewModel OrdersListViewModel
        {
            get
            {
                return this.ordersListViewModel;
            }
            set
            {
                if (this.ordersListViewModel == value)
                    return;
                this.ordersListViewModel = value;
                this.OnPropertyChanged(nameof(this.OrdersListViewModel));
            }
        }

        private ObservableCollection<Customer> customersList;

        public ObservableCollection<Customer> CustomersList
        {
            get
            {
                return this.customersList;
            }
            set
            {
                if (this.customersList == value)
                {
                    return;
                }
                this.customersList = value;
                this.OnPropertyChanged(nameof(this.CustomersList));
            }
        }

        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get
            {
                return this.selectedCustomer;
            }
            set
            {
                if (this.selectedCustomer == value)
                {
                    return;
                }
                this.selectedCustomer = value;
                this.OnPropertyChanged(nameof(this.SelectedCustomer));
                this.OrdersListViewModel = new OrdersListViewModel(this.SelectedCustomer.Orders);
            }
        }

        public CustomersListViewModel()
        {
            using (var modelDBContext = new ModelDBContext())
            {
                var tmpList = modelDBContext.Customers
                    .Include(c => c.Orders)
                    .ThenInclude(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                    .Include(c => c.Orders)
                    .ThenInclude(o => o.Store)
                    .Include(c => c.Orders)
                    .ThenInclude(o => o.Staff)
                    .ToList();

                this.CustomersList = new ObservableCollection<Customer>(tmpList);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
            {
                return;
            }
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}