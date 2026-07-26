using Microsoft.AspNetCore.Mvc;

namespace DipendencyInjection.Controllers;

[ApiController]
[Route("[controller]")]
public class ScopedNumberController : ControllerBase
{
    private readonly IScopedNumber _scopedNumber;
    private readonly IScopedNumber2 _scopedNumber2;

    public ScopedNumberController(IScopedNumber scopedNumber, IScopedNumber2 scopedNumber2)
    {
        _scopedNumber = scopedNumber;
        _scopedNumber2 = scopedNumber2;
    }

    [HttpGet(Name = "GetScopedNumber")]
    public String Get()
    {
        int number1 = _scopedNumber.Number;
        int number2 = _scopedNumber2.GetNumber();
        return $"number1: {number1}, number2:{number2}";

    }
}
