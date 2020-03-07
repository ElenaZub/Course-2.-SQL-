using ShopDAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Models
{
    public class Helper
    {
        public static ObservableCollection<Car> GetCollection()
        {
            return new ObservableCollection<Car>()
            {
                new Car {Id = 11, Model = "Audi", Make = "2020", Image = "Images/Audi.jpg", Cost = 14, Country = "USA", Size = 3, Type = "Sport", Color = "White" },
                new Car {Id = 12, Model = "BMW", Make = "2019", Cost = 15, Image = "Images/BMW.jpg", Country = "UK", Size = 4, Type = "Sport", Color = "Green" },
                new Car {Id = 13, Model = "Porsche", Make = "2018", Image = "Images/Porsche.jpg", Cost = 16, Country = "Ukraine", Size = 5, Type = "Sport", Color = "Blue" }
            };
        }
    }
}