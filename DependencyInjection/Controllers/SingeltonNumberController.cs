using Microsoft.AspNetCore.Mvc;

namespace DipendencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SingeltonNumberController : Controller
    {
        private readonly ISingeltonNumber _singeltonNumber;

        public SingeltonNumberController(ISingeltonNumber singeltonNumber)
        {
            _singeltonNumber = singeltonNumber;
        }

        [HttpGet(Name = "GetSingeltonNumber")]
        public String Get()
        {
            int number1 = _singeltonNumber.Number;
            return $"number1: {number1}";

        }
    }
}
