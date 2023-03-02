using HelloCompany.Core;

namespace HelloCompany.Model.DataBase.Entities.Complex
{
    public class FullName : ObservableObject
    {
        public FullName() { }
        public FullName(string surname, string firstName, string patronymic)
        {
            Surname = surname;
            FirstName = firstName;
            Patronymic = patronymic;
        }

        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _patronymic;
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged();
            }
        }

        public override string ToString() => $"{_surname} {_firstName} {_patronymic}";
    }
}