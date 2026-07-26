using Microsoft.AspNetCore.Mvc;

namespace DipendencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransientNumberController : Controller
    {
        private readonly ITransientNumber _transientNumber;
        private readonly ITransientNumber2 _transientNumber2;

        public TransientNumberController(ITransientNumber transientNumber, ITransientNumber2 transientNumber2)
        {
            _transientNumber = transientNumber;
            _transientNumber2 = transientNumber2;
        }

        [HttpGet(Name = "GetTransientNumber")]
        public String Get()
        {
            int number1 = _transientNumber.Number;
            int number2 = _transientNumber2.GetNumber();
            return $"number1: {number1}, number2:{number2}";

        }
    }
}
