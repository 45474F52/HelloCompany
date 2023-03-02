using HelloCompany.Core;
using System;
using System.Collections.Generic;

namespace HelloCompany.Model.DataBase.Entities
{
    public class Order : ObservableObject
    {
        public Order() => Services = new HashSet<Service>();

        public int ID { get; set; }

        private string _number;
        public string Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        private DateTime _creationDate;
        public DateTime CreationDate
        {
            get => _creationDate;
            set
            {
                _creationDate = value;
                OnPropertyChanged();
            }
        }

        public string ClientCode { get; set; }
        public string EmployeeCode { get; set; }

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

        private DateTime? _closingDate;
        public DateTime? ClosingDate
        {
            get => _closingDate;
            set
            {
                _closingDate = value;
                OnPropertyChanged();
            }
        }

        private short _runtime;
        public short Runtime
        {
            get => _runtime;
            set
            {
                _runtime = value;
                OnPropertyChanged();
            }
        }

        public virtual Client Client{ get; set; }
        public virtual Employee Employee { get; set; }
        public virtual StatusName StatusName { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public string ToMessageString =>
            $"Дата создания: {CreationDate}\nСтатус: {Status}\nВремя выполнения заказа (в часах): {Runtime}\n" +
            $"\nКод сотрудника: {EmployeeCode}\tКод клиента: {ClientCode}";
    }
}