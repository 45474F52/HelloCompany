using HelloCompany.Core;
using HelloCompany.Model.DataBase.Entities;
using HelloCompany.Model.DataBase.Entities.Complex;

namespace HelloCompany.ViewModel
{
    internal sealed class AddNaturalPersonVM : ObservableObject
    {
        public delegate void Return(in AddNaturalPersonVM sender);

        public event Return OnAdd;

        public AddNaturalPersonVM()
        {
            Person = new NaturalPerson() { FullName = new FullName(), PasportData = new PasportData(string.Empty) };
        }

        /// <summary>
        /// Автоматически заполняет поля ФИО, если они были ранее введены
        /// </summary>
        /// <param name="fullName"></param>
        public AddNaturalPersonVM(in string[] fullName)
        {
            Person = new NaturalPerson()
            {
                FullName = new FullName(fullName[0], fullName[1], fullName[2]),
                PasportData = new PasportData(string.Empty)
            };
        }

        public NaturalPerson Person { get; private set; }

        private RelayCommand _addNaturalPersonCommand;
        public RelayCommand AddNaturalPersonCommand => _addNaturalPersonCommand ?? (_addNaturalPersonCommand = new RelayCommand(
            ex => OnAdd?.Invoke(this),
            canEx =>
            {
                return true;/*Person.PropsIsNotNull("Item", nameof(Person.Error), nameof(Person.HasErrors)) &&
                !Person.HasErrors && Person.PasportData.FullData.Length == 23;*/
            }));
    }
}