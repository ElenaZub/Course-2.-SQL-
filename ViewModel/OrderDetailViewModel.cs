using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ViewModel
{
    public class OrderDetailViewModel : INotifyPropertyChanged
    {
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
            }
        }

        public OrderDetailViewModel(Order selectedOrder)
        {
            this.SelectedOrder = selectedOrder;
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