using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace NavExample.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private SecondViewModel.MyParameter _navigationParameter;
        private string _firstButtonText;
        private string _secondButtonText;
        private string _valuesPassedText;
        private string _valueReturnedText;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            FirstNavigateCommandHandler = new MvxAsyncCommand(FirstViewModelNavigateMethod);
            SecondNavigateCommandHandler = new MvxAsyncCommand(SecondViewModelNavigateMethod);

            FirstButtonText = "Navigate to first fragment!";
            SecondButtonText = "Navigate to second fragment!";
        }

        public IMvxAsyncCommand FirstNavigateCommandHandler { get; }
        public IMvxAsyncCommand SecondNavigateCommandHandler { get; }

        public string FirstButtonText
        {
            get => _firstButtonText; 
            set => SetProperty(ref _firstButtonText, value);
        }

        public string SecondButtonText
        {
            get =>_secondButtonText; 
            set => SetProperty(ref _secondButtonText, value);
        }

        public string ValuesPassed
        {
            get => _valuesPassedText;
            set => SetProperty(ref _valuesPassedText, value);
        }

        public string ValueReturned
        {
            get => _valueReturnedText;
            set => SetProperty(ref _valueReturnedText, value);
        }

        private async Task FirstViewModelNavigateMethod()
        {
            await _navigationService.Navigate<FirstViewModel>();
        }

        private async Task<SecondViewModel.MyResult> SecondViewModelNavigateMethod()
        {
            NavigationParameterGeneration();

            // You can use MvxBundle to pass data as well, but this is an outdated way of passing data through navigation service, and as such, it is largely obsolete and unnecessary.
            var result = await _navigationService.Navigate<SecondViewModel, SecondViewModel.MyParameter, SecondViewModel.MyResult>(_navigationParameter);

            ValueReturned = result.ToString();
            
            return result;
        }

        private void NavigationParameterGeneration()
        {
            // An example of logic working with a parameter, later used in navigation to SecondViewModel.
            int FirstParameterArgument = new Random().Next(2, 10);
            int SecondParameterArgument = new Random().Next(3);

            _navigationParameter = new SecondViewModel.MyParameter(FirstParameterArgument, SecondParameterArgument);

            ValuesPassed = _navigationParameter.ToString();
        }
    }
}
