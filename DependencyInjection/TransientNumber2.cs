namespace DipendencyInjection
{
    public class TransientNumber2 : ITransientNumber2
    {
        private readonly ITransientNumber _transientNumber;

        public TransientNumber2(ITransientNumber transientNumber)
        {
            _transientNumber = transientNumber;
        }

        public int GetNumber()
        {
            return _transientNumber.Number;
        }
    }
    public interface ITransientNumber2
    {
        int GetNumber();
    }
}
