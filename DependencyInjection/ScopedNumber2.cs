namespace DipendencyInjection
{
    public class ScopedNumber2 : IScopedNumber2
    {
        private readonly IScopedNumber _scopedNumber;

        public ScopedNumber2(IScopedNumber scopedNumber)
        {
            _scopedNumber = scopedNumber;
        }

        public int GetNumber()
        {
            return _scopedNumber.Number;
        }
    }
    public interface IScopedNumber2
    {
        int GetNumber();
    }
}
