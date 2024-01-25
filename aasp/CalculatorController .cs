using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly CalcService _calcService;

    public CalculatorController(CalcService calcService)
    {
        _calcService = calcService;
    }

    [HttpGet("add")]
    public IActionResult Add(int a, int b)
    {
        var result = _calcService.Add(a, b);
        return Ok(result);
    }

    [HttpGet("subtract")]
    public IActionResult Subtract(int a, int b)
    {
        var result = _calcService.Subtract(a, b);
        return Ok(result);
    }

    [HttpGet("multiply")]
    public IActionResult Multiply(int a, int b)
    {
        var result = _calcService.Multiply(a, b);
        return Ok(result);
    }

    [HttpGet("divide")]
    public IActionResult Divide(int a, int b)
    {
        try
        {
            var result = _calcService.Divide(a, b);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
