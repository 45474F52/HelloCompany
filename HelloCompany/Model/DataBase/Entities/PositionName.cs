using HelloCompany.Core;
using System.Collections.Generic;

namespace HelloCompany.Model.DataBase.Entities
{
	public class PositionName : ObservableObject
    {
        public PositionName() => Employees = new HashSet<Employee>();

		private string _position;
		public string Position
		{
			get => _position;
			set
			{
				_position = value;
				OnPropertyChanged();
			}
		}

		public virtual ICollection<Employee> Employees { get; set; }
    }
}