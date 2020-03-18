using Shop.Model;
using Shop.Model.Constant;
using Shop.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shop.ViewModel
{
    public class CarListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Car> carList;

        public ObservableCollection<Car> CarList
        {
            get
            {
                return this.carList;
            }
            set
            {
                if (this.carList == value)
                {
                    return;
                }
                this.carList = value;
                this.OnPropertyChanged(nameof(this.CarList));
            }
        }

        private Car selectedCar;

        public Car SelectedCar
        {
            get
            {
                return this.selectedCar;
            }
            set
            {
                if (this.selectedCar == value)
                {
                    return;
                }
                this.selectedCar = value;
                this.OnPropertyChanged(nameof(this.SelectedCar));
            }
        }

        public ICommand DeleteCommand { get; set; }

        public ICommand DefaultValueCommand { get; set; }

        public CarListViewModel()
        {
            this.CarList = new ObservableCollection<Car>();
            this.CarList = Helper.GetCollection();

            this.DeleteCommand = new RelayCommand(DeleteExecute, CanExecute);
            this.DefaultValueCommand = new RelayCommand(DefaultValueCommandExecute, CanExecute);
        }

        private void DefaultValueCommandExecute(object obj)
        {
            this.SelectedCar.Model = DefaultValues.Model;
            this.SelectedCar.Make = DefaultValues.Make;
            this.SelectedCar.Image = DefaultValues.Image;
            this.SelectedCar.Cost = DefaultValues.Cost;
            this.SelectedCar.Country = DefaultValues.Country;
            this.SelectedCar.Size = DefaultValues.Size;
            this.SelectedCar.Type = DefaultValues.Type;
            this.SelectedCar.Color = DefaultValues.Color;
        }

        private bool CanExecute(object obj)
        {
            if (this.SelectedCar == null)
                return false;
            else
                return true;
        }

        private void DeleteExecute(object obj)
        {
            this.CarList.Remove(this.SelectedCar);
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
