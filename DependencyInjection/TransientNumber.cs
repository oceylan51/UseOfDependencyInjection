namespace DipendencyInjection
{
    public class TransientNumber : ITransientNumber
    {
        public int Number { get; }
        public TransientNumber()
        {
            Number = new Random().Next(1000);
        }
    }
    public interface ITransientNumber
    {
        int Number { get; }
    }
}
