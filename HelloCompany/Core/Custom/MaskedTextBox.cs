using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace HelloCompany.Core.Custom
{
    public class MaskedTextBox : TextBox
    {
        private StringBuilder
            _seria = new StringBuilder(0, 4),
            _number = new StringBuilder(0, 6),
            _xS = new StringBuilder("xxxx"),
            _xN = new StringBuilder("xxxxxx");

        private bool _delete;
        private int _currentIndex = 6;
        private int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                if (_seria.Length < 4)
                {
                    _currentIndex = 6 + _seria.Length;
                }
                else if (_number.Length <= 6 && _number.Length > 0)
                {
                    _currentIndex = 6 + _seria.Length + 7 + _number.Length;
                }
                else
                {
                    _currentIndex = _delete ? 6 + _seria.Length : 6 + _seria.Length + 7;
                }
            }
        }

        public MaskedTextBox()
        {
            switch (Mask)
            {
                case Mask.Pasport:
                    Text = "Серия xxxx Номер xxxxxx";
                    CaretIndex = CurrentIndex;
                    break;
                case Mask.OrderCode:
                    break;
                case Mask.Phone:
                    break;
                case Mask.None:
                default:
                    break;
            }
            Focus();
        }

        public static DependencyProperty MaskProperty =
            DependencyProperty.Register("Mask", typeof(Mask), typeof(MaskedTextBox), new PropertyMetadata(Mask.None));

        public Mask Mask
        {
            get => (Mask)GetValue(MaskProperty);
            set => SetValue(MaskProperty, value);
        }

        private void SetValues(char value)
        {
            if (_seria.Length < 4)
                AppendChar(_seria, ref _xS, value);
            else if (_number.Length < 6)
                AppendChar(_number, ref _xN, value);
        }

        private void AppendChar(in StringBuilder strBuilder, ref StringBuilder xBuilder, in char value)
        {
            strBuilder.Append(value);
            string old = xBuilder.ToString();
            xBuilder = new StringBuilder(old.Length - 1);
            foreach (char symbol in old.Skip(1))
                xBuilder.Append(symbol);
            ++CurrentIndex;
        }

        private void DeleteValuesFromBACKSPACE()
        {
            if (_number.Length > 0)
                RemoveChar(ref _number, _xN);
            else if (_seria.Length > 0)
                RemoveChar(ref _seria, _xS);
        }

        private void RemoveChar(ref StringBuilder strBuilder, in StringBuilder xbuilder)
        {
            strBuilder = strBuilder.Remove(strBuilder.Length - 1, 1);
            xbuilder.Append('x');
            --CurrentIndex;
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text[0]))
            {
                _delete = false;
                switch (Mask)
                {
                    case Mask.Pasport:
                        SetValues(e.Text[0]);
                        UpdateText();
                        break;
                    case Mask.Phone:
                        break;
                    case Mask.None:
                    default:
                        break;
                }
            }

            e.Handled = true;
        }

        private void UpdateText()
        {
            Text = $"Серия {_seria}{_xS} Номер {_number}{_xN}";
            CaretIndex = _currentIndex;
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                _delete = true;
                DeleteValuesFromBACKSPACE();
                UpdateText();
                e.Handled = true;
            }
            else if (e.Key == Key.Space || e.Key == Key.Delete || e.Key == Key.Left || e.Key == Key.Right)
                e.Handled = true;
        }
    }

    public enum Mask
    {
        None,
        Pasport,
        Phone
    }
}