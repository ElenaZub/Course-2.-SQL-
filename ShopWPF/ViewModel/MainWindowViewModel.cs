using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using ShopDAL.Models;
using System.Windows.Input;
using ShopWPF.ViewModel.Commands;
using ShopDAL.Models.Constant;
using ShopDAL;

namespace ShopWPF.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Car> carList;

        private UnitOfWork unitOfWork;

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

        public ICommand AddDefaultValueCommand { get; set; } 

        public ICommand UpdateCommand { get; set; }  

        public MainWindowViewModel()
        {
            this.unitOfWork = new UnitOfWork();
            this.CarList = new ObservableCollection<Car>(this.unitOfWork.CarRepository.Get());

            this.DeleteCommand = new RelayCommand(this.DeleteExecute, this.CanExecute);
            this.AddDefaultValueCommand = new RelayCommand(this.AddDefaultValueCommandExecute, this.AddDefaultCanExecute);
            this.UpdateCommand = new RelayCommand(this.UpdateCommandExecute, this.UpdateCanExecute);
        }

        private bool AddDefaultCanExecute(object obj)
        {
            return true;
        }

        private bool UpdateCanExecute(object obj)
        {
            if (this.SelectedCar == null)
                return false;
            else
                return true;
        }

        private void UpdateCommandExecute(object obj)
        {
            this.unitOfWork.CarRepository.Update(this.SelectedCar);
            this.unitOfWork.Save();
        }

        private void AddDefaultValueCommandExecute(object obj)
        {
            var car = new Car
            {
                Model = DefaultValues.Model,
                Make = DefaultValues.Make,
                Image = DefaultValues.Image,
                Cost = DefaultValues.Cost,
                Country = DefaultValues.Country,
                Size = DefaultValues.Size,
                Type = DefaultValues.Type,
                Color = DefaultValues.Color
            };

            this.unitOfWork.CarRepository.Add(car);
            this.carList.Add(car);
            this.unitOfWork.Save();
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
            this.unitOfWork.CarRepository.Delete(this.SelectedCar);
            this.CarList.Remove(this.SelectedCar);
            this.unitOfWork.CarRepository.Save();          
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
