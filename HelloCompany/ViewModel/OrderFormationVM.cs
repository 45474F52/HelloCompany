using HelloCompany.Core;
using HelloCompany.Model.DataBase.Entities;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HelloCompany.ViewModel
{
    internal sealed class OrderFormationVM : ObservableObject
    {
        internal sealed class ServiceModel
        {
            public ServiceModel(Service service, bool isSelected = false) { Service = service; IsSelected = isSelected; }
            public Service Service { get; set; }
            public bool IsSelected { get; set; }
        }

        public OrderFormationVM()
        {
            ServiceCollection = new List<ServiceModel>();

            foreach (Service item in App.DBContext.Services)
                ServiceCollection = ServiceCollection.Append(new ServiceModel(item));
        }

        private string _orderCode;
        public string OrderCode
        {
            get => _orderCode;
            set
            {
                _orderCode = value;
                OnPropertyChanged();
            }
        }

        private string _nameOrCompany = string.Empty;
        public string NameOrCompany
        {
            get => _nameOrCompany;
            set
            {
                _nameOrCompany = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<ServiceModel> ServiceCollection { get; private set; }

        private object _modalDialog;
        public object ModalDialog
        {
            get => _modalDialog;
            set
            {
                if (_modalDialog != value)
                {
                    _modalDialog = value;
                    OnPropertyChanged();
                }
            }
        }

        private RelayCommand _addOrder;
        public RelayCommand AddOrder => _addOrder ?? (_addOrder = new RelayCommand(
            obj => AddOrderMethod(),
            obj => !string.IsNullOrWhiteSpace(_nameOrCompany) && ServiceCollection.Where(s => s.IsSelected).Count() > 0));

        private void AddOrderMethod()
        {
            JuridicalPerson jPerson = App.DBContext.JuridicalPeople.SingleOrDefault(j => j.CompanyName.ToLower() == _nameOrCompany.Trim().ToLower());

            short runtime = default;
            try
            {
                checked
                {
                    runtime = (short)ServiceCollection.Where(s => s.IsSelected).Select(s => Convert.ToInt32(s.Service.PerformanceTime)).Sum();
                }
            }
            catch (OverflowException) { }

            string clientCode = string.Empty;

            if (jPerson == null)
            {
                NaturalPerson nPerson = App.DBContext.NaturalPeople.ToList().SingleOrDefault(p => p.FullName.ToString().ToLower() == _nameOrCompany.Trim().ToLower());

                if (nPerson == null)
                {
                    nPerson = ShowAddClientWindow(App.DBContext.NaturalPeople.Count());
                    if (nPerson == null)
                        return;
                    else
                        clientCode = nPerson.Code;
                }
                else
                    clientCode = nPerson.Code;
            }
            else
                clientCode = jPerson.Code;

            CreateOrder(clientCode, DateTime.Now, runtime);
        }

        private void CreateOrder(string clientCode, DateTime date, short runtime)
        {
            Order order = new Order()
            {
                Number = $"{clientCode}/{date:dd.MM.yyyy}",
                CreationDate = date,
                ClientCode = clientCode,
                Status = "Новая",
                ClosingDate = null,
                EmployeeCode = "ID 107",//начальник ОТК
                Runtime = runtime
            };
            App.DBContext.Orders.Add(order);
            App.DBContext.SaveChanges();

            ModalDialog = new ModalDialogWindowVM($"Заказ под номером {order.Number} успешно создан!", order.ToMessageString);
        }

        private NaturalPerson ShowAddClientWindow(int oldNaturalPeopleCount)
        {
            string[] fullName = _nameOrCompany.Trim().Split(' ');
            AddNaturalPersonVM vm = fullName.Length == 3 ? new AddNaturalPersonVM(fullName) : new AddNaturalPersonVM();

            vm.OnAdd += (in AddNaturalPersonVM sender) =>
            {
                App.DBContext.NaturalPeople.Add(sender.Person);
                App.DBContext.SaveChanges();
            };

            ModalDialog = vm;

            if (App.DBContext.NaturalPeople.Count() > oldNaturalPeopleCount)
                return vm.Person;
            else
                return null;
        }
    }
}