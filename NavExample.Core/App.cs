using MvvmCross.ViewModels;
using NavExample.Core.ViewModels;

namespace NavExample.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MainViewModel>();
        }
    }
}
