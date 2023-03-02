using HelloCompany.Core;

namespace HelloCompany.Model.DataBase.Entities.Complex
{
    public class Contact : ObservableObject
    {
        public FullName FullName { get; set; }

		private string _phone;
		public string Phone
		{
			get => _phone;
			set
			{
				_phone = value;
				OnPropertyChanged();
			}
		}
	}
}