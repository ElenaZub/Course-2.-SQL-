using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ViewModel
{
    public class OrdersListViewModel : INotifyPropertyChanged
    {
        private OrderItemsListViewModel orderItemsListViewModel;

        public OrderItemsListViewModel OrderItemsListViewModel
        {
            get
            {
                return this.orderItemsListViewModel;
            }
            set
            {
                if (this.orderItemsListViewModel == value)
                    return;
                this.orderItemsListViewModel = value;
                this.OnPropertyChanged(nameof(this.OrderItemsListViewModel));
            }
        }

        private OrderDetailViewModel orderDetailViewModel;

        public OrderDetailViewModel OrderDetailViewModel
        {
            get
            {
                return this.orderDetailViewModel;
            }
            set
            {
                if (this.orderDetailViewModel == value)
                    return;
                this.orderDetailViewModel = value;
                this.OnPropertyChanged(nameof(this.OrderDetailViewModel));
            }
        }

        private ObservableCollection<Order> orderList;

        public ObservableCollection<Order> OrdersList
        {
            get
            {
                return this.orderList;
            }
            private set
            {
                if (this.orderList == value)
                    return;
                this.orderList = value;
                this.OnPropertyChanged(nameof(this.OrdersList));
            }
        }

        private Order selectedOrder;

        public Order SelectedOrder
        {
            get
            {
                return this.selectedOrder;
            }
            set
            {
                if (this.selectedOrder == value)
                {
                    return;
                }
                this.selectedOrder = value;
                this.OnPropertyChanged(nameof(this.SelectedOrder));
                this.OrderDetailViewModel = new OrderDetailViewModel(this.SelectedOrder);
                this.OrderItemsListViewModel = new OrderItemsListViewModel(this.SelectedOrder.OrderItems);
            }
        }

        public OrdersListViewModel(ICollection<Order> orders)
        {
            this.OrdersList = new ObservableCollection<Order>(orders);
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
