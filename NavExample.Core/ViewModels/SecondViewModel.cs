using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NavExample.Core.Navigation.Parameters;
using NavExample.Core.Navigation.Results;

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

            CloseCommand = new MvxAsyncCommand(CloseViewModel);

            _closeButtonText = "Close this ViewModel!";
        }

        public IMvxAsyncCommand CloseCommand { get; }

        public override void Prepare(MyParameter parameter)
        {
            _navigationParameter = parameter;
            DoSomethingPrivately();
        }


        public string CloseButtonText
        {
            get { return _closeButtonText; }
            set { SetProperty(ref _closeButtonText, value); }
        }

        public override Task Initialize()
        {
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
    }
}
