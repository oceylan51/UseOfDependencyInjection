namespace DipendencyInjection
{
    public class ScopedNumber : IScopedNumber
    {
        public int Number { get; }

        public ScopedNumber()
        {
            Number = new Random().Next(1000);
        }

    }
    public interface IScopedNumber
    {
        int Number { get; }
    }
}
