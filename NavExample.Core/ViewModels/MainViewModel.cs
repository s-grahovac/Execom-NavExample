using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NavExample.Core.Navigation.Parameters;
using NavExample.Core.Navigation.Results;

namespace NavExample.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private MyParameter _navigationParameter;
        private IMvxBundle _presentationBundle;
        private string _firstButtonText, _secondButtonText, _valuesPassedText, _valueReturnedText;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            FirstNavigateCommand = new MvxAsyncCommand(FirstViewModelNavigateMethod);
            SecondNavigateCommand = new MvxAsyncCommand(SecondViewModelNavigateMethod);

            _firstButtonText = "Navigate to first fragment!";
            _secondButtonText = "Navigate to second fragment!";
        }

        public IMvxAsyncCommand FirstNavigateCommand { get; }
        public IMvxAsyncCommand SecondNavigateCommand { get; }

        public string FirstButtonText
        {
            get { return _firstButtonText; }
            set { SetProperty(ref _firstButtonText, value); }
        }

        public string SecondButtonText
        {
            get { return _secondButtonText; }
            set { SetProperty(ref _secondButtonText, value); }
        }

        public string ValuesPassed
        {
            get { return _valuesPassedText; }
            set { SetProperty(ref _valuesPassedText, value); }
        }

        public string ValueReturned
        {
            get { return _valueReturnedText; }
            set { SetProperty(ref _valueReturnedText, value); }
        }

        private async Task FirstViewModelNavigateMethod()
        {
            await _navigationService.Navigate<FirstViewModel>();
        }

        private async Task<MyResult> SecondViewModelNavigateMethod()
        {
            NavigationParameterGeneration();
            NavigationBundleGeneration();
            
            var result = await _navigationService.Navigate<SecondViewModel, MyParameter, MyResult>(_navigationParameter, _presentationBundle);

            _valueReturnedText = result.ToString();
            await RaisePropertyChanged(nameof(ValueReturned));

            return result;
        }

        private void NavigationParameterGeneration()
        {
            // An example of logic working with a parameter, later used in navigation to SecondViewModel.
            int FirstParameterArgument = new Random().Next(2, 10);
            int SecondParameterArgument = new Random().Next(3);

            _navigationParameter = new MyParameter(FirstParameterArgument, SecondParameterArgument);

            _valuesPassedText = _navigationParameter.ToString();
            RaisePropertyChanged(nameof(ValuesPassed));
        }

        private void NavigationBundleGeneration()
        {
            // This is the example of a place where you can put your logic for working with a MvxBundle.
            // But, this is an outdated way of passing data through navigation service, so it is largely obsolete and unnecessary.

            _presentationBundle = new MvxBundle();
        }

    }
}
