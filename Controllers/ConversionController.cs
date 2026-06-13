using Microsoft.AspNetCore.Mvc;
using UnitConversion.Application.DTO;
using UnitConversion.Application.Interfaces;

namespace UnitConversion.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/conversion")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;
        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpPost("convert")]
        public IActionResult Convert([FromBody] ConversionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            try
            {
                var result = _conversionService.Convert(request);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid conversion request",
                    Detail = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid input",
                    Detail = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
        }
    }
}
