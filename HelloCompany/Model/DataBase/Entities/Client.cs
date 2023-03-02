using HelloCompany.Core;
using System.Collections.Generic;

namespace HelloCompany.Model.DataBase.Entities
{
    public class Client : ObservableObject
    {
        public Client() => Orders = new HashSet<Order>();

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

        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
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

        public virtual ICollection<Order> Orders { get; set; }

        public virtual JuridicalPerson JuridicalPerson { get; set; }
        public virtual NaturalPerson NaturalPerson { get; set; }
    }
}