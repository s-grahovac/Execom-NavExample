﻿using System;
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
            // Sample logic of some parameter/result interaction.
            var value = 10 * (_navigationParameter.FirstValue + _navigationParameter.SecondValue);
            var label = "Calculated value is: ";

            _returningResult = new MyResult(label, value);
        }

        private async Task CloseViewModel()
        {
            await _navigationService.Close(this, _returningResult);
        }

        // A nested class exemplifying the custom object used as a parameter passed during the navigation.
        public class MyParameter
        {
            public MyParameter(int FirstParameterValue, int SecondParameterValue)
            {
                FirstValue = FirstParameterValue;
                SecondValue = SecondParameterValue;
            }

            public int FirstValue { get; }

            public int SecondValue { get; }

            public override string ToString()
            {
                return $"{FirstValue}, {SecondValue}";
            }
        }

        // A nested class exemplifying the custom object used as a return type during the navigation.
        public class MyResult
        {
            private readonly string _internalTextField;
            private readonly int _internalValue;

            public MyResult(string InputString, int InputValue)
            {
                _internalTextField = InputString;
                _internalValue = InputValue;
            }

            public override string ToString()
            {
                return $"{_internalTextField} {_internalValue, 10}";
            }
        }
    }
}
