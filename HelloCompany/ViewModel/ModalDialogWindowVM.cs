using HelloCompany.Core;

namespace HelloCompany.ViewModel
{
    internal sealed class ModalDialogWindowVM : ObservableObject
    {
        public ModalDialogWindowVM() : this("CAPTURE", "MESSAGE") { }

        public ModalDialogWindowVM(in string capture, in string message)
        {
            Capture = capture;
            Message = message;
        }

        public string Capture { get; private set; }
        public string Message { get; private set; }
    }
}