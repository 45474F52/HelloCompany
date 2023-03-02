using System.Collections.Generic;
using System;
using HelloCompany.Core;
using HelloCompany.Model.DataBase.Entities.Complex;

namespace HelloCompany.Model.DataBase.Entities
{
    public class Employee : ObservableObject
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
            Services = new HashSet<Service>();
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

        public string Position { get; set; }

        public FullName FullName { get; set; }

        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private DateTime _lastEntry;
        public DateTime LastEntry
        {
            get => _lastEntry;
            set
            {
                _lastEntry = value;
                OnPropertyChanged();
            }
        }

        public virtual PositionName PositionName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}