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

        public ICommand DefaultValueCommand { get; set; }

        public ICommand SaveCommand { get; set; }  

        public MainWindowViewModel()
        {
            this.unitOfWork = new UnitOfWork();
            this.CarList = new ObservableCollection<Car>();
            this.CarList = Helper.GetCollection();

            //foreach (var item in CarList)
            //{
            //    this.unitOfWork.CarRepository.Add(item);
            //}
            //this.unitOfWork.CarRepository.Save();

            this.DeleteCommand = new RelayCommand(DeleteExecute, CanExecute);
            this.DefaultValueCommand = new RelayCommand(DefaultValueCommandExecute, CanExecute);
            this.SaveCommand = new RelayCommand(SaveCommandExecute, SaveCanExecute);
        }

        private bool SaveCanExecute(object obj)
        {
            return true;
        }

        private void SaveCommandExecute(object obj)
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
            this.carList.Add(car);
            this.unitOfWork.CarRepository.Add(car);
            this.unitOfWork.CarRepository.Save();
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
