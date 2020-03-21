using Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ViewModel
{
    public class ProductDetailViewModel : INotifyPropertyChanged
    {
        private Product selectedProduct;

        public Product SelectedProduct
        {
            get
            {
                return this.selectedProduct;
            }
            set
            {
                if (this.selectedProduct == value)
                {
                    return;
                }
                this.selectedProduct = value;
                this.OnPropertyChanged(nameof(this.SelectedProduct));
            }
        }

        public ProductDetailViewModel(Product selectedProduct)
        {
            this.SelectedProduct = selectedProduct;
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
