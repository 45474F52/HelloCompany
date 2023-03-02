using System.Windows;

namespace HelloCompany.View
{
    public partial class AddNaturalPerson
    {
        public AddNaturalPerson() => InitializeComponent();
        private void Button_Click(object sender, RoutedEventArgs e) => DialogResult = true;
    }
}