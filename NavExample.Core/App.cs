using MvvmCross.IoC;
using MvvmCross.ViewModels;
using NavExample.Core.ViewModels;

namespace NavExample.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
