using Microsoft.AspNetCore.Mvc;

namespace RESTfullAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input data.");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult GetSubtraction(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(subtraction.ToString());
            }
            return BadRequest("Invalid input data.");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiplication(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid input data.");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult GetDivision(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(division.ToString());
            }
            return BadRequest("Invalid input data.");
        }

        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult GetAverage(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var average = ((ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2);

                return Ok(average.ToString());
            }
            return BadRequest("Invalid input data.");
        }

        [HttpGet("squareRoot/{number}")]
        public IActionResult GetSquareRoot(string number)
        {
            if (isNumeric(number))
            {
                var sqrt = Math.Sqrt(ConvertToDouble(number));

                return Ok(sqrt.ToString());
            }
            return BadRequest("Invalid input data.");
        }

        private double ConvertToDouble(string strNumber)
        {
            double convertedNumber;
            if (double.TryParse(strNumber, out convertedNumber))
            {
                return convertedNumber;
            }
            return 0;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal convertedNumber;
            if (decimal.TryParse(strNumber, out convertedNumber))
            {
                return convertedNumber;
            }
            return 0;
        }

        private bool isNumeric(string strNumber)
        {
            double convertedNumber;
            bool isNumber = double.TryParse(strNumber,System.Globalization.NumberStyles.Any,System.Globalization.NumberFormatInfo.InvariantInfo, out convertedNumber);
            return isNumber;
        }
    }
}