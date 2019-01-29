using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using static NavExample.Core.ViewModels.SecondViewModel;

namespace NavExample.Core.ViewModels
{
    // Complex navigation target ViewModel.
    public class SecondViewModel : MvxViewModel<MyParameter, MyResult>
    {
        private readonly IMvxNavigationService _navigationService;
        private MyParameter _navigationParameter;
        private MyResult _returningResult;
        private string _closeButtonText;

        public SecondViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            CloseCommandHandler = new MvxAsyncCommand(CloseViewModel);

            _closeButtonText = "Close this ViewModel!";
        }

        public IMvxAsyncCommand CloseCommandHandler { get; }

        public override void Prepare(MyParameter parameter)
        {
            _navigationParameter = parameter;
        }

        public string CloseButtonText
        {
            get => _closeButtonText;
            set => SetProperty(ref _closeButtonText, value);
        }

        public override Task Initialize()
        {
            DoSomethingPrivately();

            return base.Initialize();
        }

        private void DoSomethingPrivately()
        {
            _returningResult = new MyResult("Calculated value: ", 15, _navigationParameter);
            _returningResult.DoSomeTransmutation();
        }

        private async Task CloseViewModel()
        {
            await _navigationService.Close(this, _returningResult);
        }

        // A nested class exemplifying the custom object used as a parameter passed during the navigation.
        public class MyParameter
        {
            private readonly int _firstValue;
            private readonly int _secondValue;

            public MyParameter()
            {
                _firstValue = 1;
                _secondValue = 1;
            }

            public MyParameter(int FirstValue, int SecondValue)
            {
                _firstValue = FirstValue;
                _secondValue = SecondValue;
            }

            public int DoCalculation()
            {
                return 10 * (_firstValue + _secondValue);
            }

            public override string ToString()
            {
                return _firstValue.ToString() + ", " + _secondValue.ToString();
            }
        }

        // A nested class exemplifying the custom object used as a return type during the navigation.
        public class MyResult
        {
            private string _internalTextField;
            private int _internalValue;
            private readonly MyParameter _internalParameter;

            public MyResult()
            {
                _internalTextField = "This is a test string.";
                _internalValue = 1;
                _internalParameter = new MyParameter(1, 1);
            }

            public MyResult(string InputString, int InputValue, MyParameter InputParemeter)
            {
                _internalTextField = InputString;
                _internalValue = InputValue;
                _internalParameter = InputParemeter;
            }

            public MyResult DoSomeTransmutation()
            {
                _internalValue = _internalValue + _internalParameter.DoCalculation();
                _internalTextField = _internalTextField + _internalValue.ToString();

                return this;
            }

            public override string ToString()
            {
                return _internalTextField;
            }
        }
    }
}
