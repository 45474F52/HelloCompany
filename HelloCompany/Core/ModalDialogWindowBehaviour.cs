using System.Windows;

namespace HelloCompany.Core
{
    public static class ModalDialogWindowBehaviour
    {
        public static readonly DependencyProperty ModalDialogWindowProperty =
            DependencyProperty.RegisterAttached("ModalDialogWindow", typeof(object), typeof(ModalDialogWindowBehaviour), new PropertyMetadata(null, OnModalDialogWindowChange));

        public static void SetModalDialogWindow(DependencyObject d, object value) => d.SetValue(ModalDialogWindowProperty, value);
        public static object GetModalDialogWindow(DependencyObject d) => d.GetValue(ModalDialogWindowProperty);

        private static void OnModalDialogWindowChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window)
            {
                if (e.NewValue != null)
                {
                    object resource = Application.Current.TryFindResource(e.NewValue.GetType());
                    if (resource != null && resource is Window)
                    {
                        (resource as Window).DataContext = e.NewValue;
                        (resource as Window).ShowDialog();
                    }
                }
            }
        }
    }
}