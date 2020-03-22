using Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ViewModel
{
    public class StocksListViewModel
    {
        public ObservableCollection<Stock> StocksList { get; set; }

        public StocksListViewModel(ICollection<Stock> stocks)
        {
            this.StocksList = new ObservableCollection<Stock>(stocks);
        }
    }
}