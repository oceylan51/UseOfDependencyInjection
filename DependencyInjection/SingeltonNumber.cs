using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Security.Cryptography;

namespace DipendencyInjection
{
    public class SingeltonNumber : ISingeltonNumber
    {
        public int Number { get; }
        public SingeltonNumber()
        {
            Number = new Random().Next(1000);
        }
    }
    public interface ISingeltonNumber
    {
        public int Number { get; }
    }
}
