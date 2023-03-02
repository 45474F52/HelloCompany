using HelloCompany.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloCompany.Model.DataBase.Entities.Complex
{
    public class PasportData : ObservableObject
    {
        protected PasportData() { }
		public PasportData(string pasportData) => Update(pasportData);

        public void Update(string pasportData)
        {
            try
            {
                Series = pasportData.Substring(6, 4);
                Number = pasportData.Substring(17, 6);
            }
            catch (ArgumentOutOfRangeException)
            {
                Series = "xxxx";
                Number = "xxxxxx";
            }
        }

		public string FullData
		{
			get => $"Серия {_series} Номер {_number}";
            set => Update(value);
		}

		private string _series = "xxxx";
		[NotMapped]
		public string Series
		{
			get => _series;
			set
			{
				_series = value;
				OnPropertyChanged();
			}
		}

		private string _number = "xxxxxx";
		[NotMapped]
		public string Number
		{
			get => _number;
			set
			{
				_number = value;
				OnPropertyChanged();
			}
		}

		public override string ToString() => FullData;
    }
}