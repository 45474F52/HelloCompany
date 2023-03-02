using HelloCompany.Model.DataBase.Entities.Complex;

namespace HelloCompany.Model.DataBase.Entities
{
    public class JuridicalPerson : Client
    {
        public int ID { get; set; }

        private string _companyName;
        public string CompanyName

        {
            get => _companyName;
            set
            {
                _companyName = value;
                OnPropertyChanged();
            }
        }

        private long _inn;
        public long INN
        {
            get => _inn;
            set
            {
                _inn = value;
                OnPropertyChanged();
            }
        }

        private long _account;
        public long Account
        {
            get => _account;
            set
            {
                _account = value;
                OnPropertyChanged();
            }
        }

        private long _bic;
        public long BIC
        {
            get => _bic;
            set
            {
                _bic = value;
                OnPropertyChanged();
            }
        }

        public Supervisor Supervisor { get; set; }

        public Contact Contact { get; set; }
    }
}