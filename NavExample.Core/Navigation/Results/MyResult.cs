using NavExample.Core.Navigation.Parameters;

namespace NavExample.Core.Navigation.Results
{
    // A random class exemplifying the custom object used as a return type during the navigation.
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
