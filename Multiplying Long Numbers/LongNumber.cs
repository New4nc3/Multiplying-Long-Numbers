using System.Text;

namespace Multiplying_Long_Numbers
{
    internal class LongNumber
    {
        public string Raw { get; }
        public Stack<int> Digits { get; } = new Stack<int>();

        private string _cachedStringRepresentation = string.Empty;
        private StringBuilder _toStringStringBuilder = new StringBuilder();

        public LongNumber(string rawNumber)
        {
            Raw = rawNumber;

            InitStack();
            InitReadableStringRepresentation();
        }

        private void InitStack()
        {
            int i, tempDigit, count = Raw.Length;

            for (i = 0; i < count; ++i)
            {
                tempDigit = int.Parse(Raw[i].ToString());
                Digits.Push(tempDigit);
            }
        }

        private void InitReadableStringRepresentation()
        {
            int temp = 1;
            _toStringStringBuilder.Clear();

            for (int i = Raw.Length - 1; i >= 0; --i)
            {
                _toStringStringBuilder.Insert(0, Raw[i]);

                if (++temp % 4 == 0 && i != 0)
                {
                    _toStringStringBuilder.Insert(0, " ");
                    temp = 1;
                }
            }

            _cachedStringRepresentation = _toStringStringBuilder.ToString();
        }

        public override string ToString()
        {
            return _cachedStringRepresentation;
        }
    }
}