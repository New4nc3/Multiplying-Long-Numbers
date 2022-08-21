using System.Text;

namespace Multiplying_Long_Numbers
{
    internal class Processor
    {
        public LongNumber FirstNumber { get; private set; }
        public LongNumber SecondNumber { get; private set; }
        public string Result { get; private set; }

        private int[] _resultArr;
        private StringBuilder _resultStringBuilder = new StringBuilder();
        private StringBuilder _toStringStringBuilder = new StringBuilder();

        public Processor()
        {
            Initialize("1", "1");
            Multiply();
        }

        public Processor(string number1, string number2)
        {
            Initialize(number1, number2);
        }

        private void Initialize(string num1, string num2)
        {
            FirstNumber = new LongNumber(num1);
            SecondNumber = new LongNumber(num2);
            _resultArr = new int[FirstNumber.Digits.Count + SecondNumber.Digits.Count];
            Result = string.Empty;
        }

        public void MultiplyResultBy(string newNumber)
        {
            Initialize(Result, newNumber);
            Multiply();
        }

        public void Multiply()
        {
            RawMultiply();
            Normalize();
            GenerateResult();
        }

        #region Multiplying process
        private void RawMultiply()
        {
            int tempRes, tempShift, constShift = 0;
            int lastIdx = _resultArr.Length - 1;

            foreach (int token1 in FirstNumber.Digits)
            {
                tempShift = 0;

                foreach (int token2 in SecondNumber.Digits)
                {
                    tempRes = token1 * token2;
                    _resultArr[lastIdx - tempShift - constShift] += tempRes;

                    ++tempShift;
                }

                ++constShift;
            }
        }

        private void Normalize()
        {
            int currentNumber, lastDigit, restNumber;

            for (int i = _resultArr.Length - 1; i > 0; --i)
            {
                currentNumber = _resultArr[i];

                if (currentNumber > 9)
                {
                    lastDigit = currentNumber % 10;
                    restNumber = currentNumber / 10;

                    _resultArr[i] = lastDigit;
                    _resultArr[i - 1] += restNumber;
                }
            }
        }

        private void GenerateResult()
        {
            int i = 0;
            int length = _resultArr.Length;
            int lastIdx = length - 1;

            while (_resultArr[i] == 0)
            {
                ++i;

                if (i == lastIdx)
                {
                    break;
                }
            }

            _resultStringBuilder.Clear();

            while (i < length)
            {
                _resultStringBuilder.Append(_resultArr[i]);
                ++i;
            }

            Result = _resultStringBuilder.ToString();
        }
        #endregion

        public override string ToString()
        {
            int temp = 1;
            _toStringStringBuilder.Clear();

            for (int i = Result.Length - 1; i >= 0; --i)
            {
                _toStringStringBuilder.Insert(0, Result[i]);

                if (++temp % 4 == 0 && i != 0)
                {
                    _toStringStringBuilder.Insert(0, " ");
                    temp = 1;
                }
            }

            return _toStringStringBuilder.ToString();
        }
    }
}