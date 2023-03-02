using HelloCompany.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloCompany.Model.DataBase.Entities
{
    public class Service : ObservableObject
    {
        public Service()
        {
            Employees = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }

        private int _id;
        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _code;
        public string Code
        {
            get => _code;
            set
            {
                _code = value;
                OnPropertyChanged();
            }
        }

        private byte _performanceTime;
        public byte PerformanceTime
        {
            get => _performanceTime;
            set
            {
                _performanceTime = value;
                OnPropertyChanged();
            }
        }

        private decimal _meanDeviation;
        public decimal MeanDeviation
        {
            get => _meanDeviation;
            set
            {
                _meanDeviation = value;
                OnPropertyChanged();
            }
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        private decimal _priceRuCosmetics;
        public decimal PriceRuCosmetics
        {
            get => _priceRuCosmetics;
            set
            {
                _priceRuCosmetics = value;
                OnPropertyChanged();
            }
        }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        [NotMapped]
        public string ToolTip =>
            $"Выполнится за {_performanceTime} ч. (±{_meanDeviation} ч.)\nСтоимость:\n{_price:C2}\nДля ЗАО \"Русская косметика\": {_priceRuCosmetics:C2}";
    }
}