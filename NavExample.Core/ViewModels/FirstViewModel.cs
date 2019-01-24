using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace NavExample.Core.ViewModels
{
    // Simple navigation target ViewModel
    public class FirstViewModel : MvxViewModel, IMvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private string _closeButtonText;

        public FirstViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            CloseCommand = new MvxAsyncCommand(CloseViewModel);

            _closeButtonText = "Close this ViewModel!";
        }

        public string CloseButtonText
        {
            get { return _closeButtonText; }
            set { SetProperty(ref _closeButtonText, value); }
        }

        public IMvxAsyncCommand CloseCommand { get; }
        private async Task CloseViewModel()
        {
            await _navigationService.Close(this);
        }
    }
}
