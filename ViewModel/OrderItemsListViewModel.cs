using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ViewModel
{
    public class OrderItemsListViewModel
    {
        public ObservableCollection<OrderItem> OrdersItemList { get; set; }

        public OrderItemsListViewModel(ICollection<OrderItem> orderItems)
        {
            this.OrdersItemList = new ObservableCollection<OrderItem>(orderItems);
        }
    }
}
