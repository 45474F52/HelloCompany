using HelloCompany.Core;
using System.Collections.Generic;

namespace HelloCompany.Model.DataBase.Entities
{
	public class StatusName : ObservableObject
    {
        public StatusName() => Orders = new HashSet<Order>();

		private string _status;
		public string Status
		{
			get => _status;
			set
			{
				_status = value;
				OnPropertyChanged();
			}
		}

		public virtual ICollection<Order> Orders { get; set; }
    }
}