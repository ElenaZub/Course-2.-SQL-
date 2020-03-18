using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Models
{
    public class Car : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string model;
        private string make;
        private string image;
        private decimal cost;
        private string country;
        private string color;
        private int size;
        private string type;

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (this.model == value)
                {
                    return;
                }
                this.model = value;
                this.OnPropertyChanged(nameof(this.Model));
            }
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            set
            {
                if (this.make == value)
                {
                    return;
                }
                this.make = value;
                this.OnPropertyChanged(nameof(this.Make));
            }
        }

        public string Image
        {
            get
            {
                return this.image;
            }
            set
            {
                if (this.image == value)
                {
                    return;
                }
                this.image = value;
                this.OnPropertyChanged(nameof(this.Image));
            }
        }

        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                if (this.cost == value)
                {
                    return;
                }
                this.cost = value;
                this.OnPropertyChanged(nameof(this.Cost));
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                if (this.country == value)
                {
                    return;
                }
                this.country = value;
                this.OnPropertyChanged(nameof(this.Country));
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                if (this.color == value)
                {
                    return;
                }
                this.color = value;
                this.OnPropertyChanged(nameof(this.Color));
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (this.size == value)
                {
                    return;
                }
                this.size = value;
                this.OnPropertyChanged(nameof(this.Size));
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (this.type == value)
                {
                    return;
                }
                this.type = value;
                this.OnPropertyChanged(nameof(this.Type));
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
