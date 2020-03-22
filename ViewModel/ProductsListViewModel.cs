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
    public class ProductsListViewModel : INotifyPropertyChanged
    {
        private StocksListViewModel stocksListViewModel;

        public StocksListViewModel StocksListViewModel
        {
            get
            {
                return this.stocksListViewModel;
            }
            set
            {
                if (this.stocksListViewModel == value)
                    return;
                this.stocksListViewModel = value;
                this.OnPropertyChanged(nameof(this.StocksListViewModel));
            }
        }

        private ProductDetailViewModel productDetailViewModel;

        public ProductDetailViewModel ProductDetailViewModel
        {
            get
            {
                return this.productDetailViewModel;
            }
            set
            {
                if (this.productDetailViewModel == value)
                    return;
                this.productDetailViewModel = value;
                this.OnPropertyChanged(nameof(this.ProductDetailViewModel));
            }
        }

        public ObservableCollection<Product> ProductsList { get; set; }

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
                this.StocksListViewModel = new StocksListViewModel(this.selectedProduct.Stocks);
                this.ProductDetailViewModel = new ProductDetailViewModel(this.selectedProduct);
            }
        }

        public ProductsListViewModel()
        {
            using (var modelDBContext = new ModelDBContext())
            {
                var tmpList = modelDBContext.Products
                    .Include(pr => pr.Brand)
                    .Include(pr => pr.Category)
                    .Include(pr => pr.Stocks)
                    .ThenInclude(stocks => stocks.Store)
                    .ToList();

                this.ProductsList = new ObservableCollection<Product>(tmpList);
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
