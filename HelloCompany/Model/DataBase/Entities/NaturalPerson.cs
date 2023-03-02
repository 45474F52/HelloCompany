using HelloCompany.Model.DataBase.Entities.Complex;
using System;

namespace HelloCompany.Model.DataBase.Entities
{
    public class NaturalPerson : Client
    {
        public int ID { get; set; }

        public FullName FullName { get; set; }

        public PasportData PasportData { get; set; }

        private DateTime _birthDate = DateTime.Now;
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }
    }
}