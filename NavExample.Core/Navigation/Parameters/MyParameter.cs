namespace NavExample.Core.Navigation.Parameters
{
    // A random class exemplifying the custom object used as a parameter passed during the navigation.
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
}
