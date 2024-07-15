using FizzBuzz.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost("ProcessArray")]
        public ActionResult<List<string>> ProcessArray([FromBody] int[] values)
        {
            var results = new List<string>();
            foreach (var value in values)
            {
                var result = _fizzBuzzService.ProcessValue(value);
                results.Add(result);
            }

            var divisionsPerformed = _fizzBuzzService.GetDivisionsPerformed();
            results.AddRange(divisionsPerformed);

            return results;
        }
    }


}
