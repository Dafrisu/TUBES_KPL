using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;

namespace APITesting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FareCalculatorController : ControllerBase
    {
        private static List<FareCalculator> _fareCalculations = new List<FareCalculator>();

        [HttpGet]
        public IActionResult CalculateFare(string Dari, string Ke, double JarakDalamKM)
        {
            if (JarakDalamKM <= 0)
            {
                return BadRequest("Silakan masukkan jarak yang valid dalam kilometer.");
            }

            double HargaPerKM = 2000;
            double total = JarakDalamKM * HargaPerKM;

            int discountCount = (int)(JarakDalamKM / 10);
            total -= discountCount * 5000;

            var calculation = new FareCalculator
            {
                Dari = Dari,
                Ke = Ke,
                JarakDalamKM = JarakDalamKM,
                HargaPerKM = HargaPerKM,
                TotalHarga = total,
                CalculatedAt = DateTime.Now
            };
            _fareCalculations.Add(calculation);

            return Ok(new
            {
                Dari = Dari,
                Ke = Ke,
                JarakDalamKM = JarakDalamKM,
                HargaPerKM = HargaPerKM.ToString("N0", CultureInfo.InvariantCulture) + " IDR",
                TotalHarga = total.ToString("N0", CultureInfo.InvariantCulture) + " IDR"
            });
        }

        [HttpPost]
        public IActionResult SaveFareCalculation([FromBody] FareCalculator calculation)
        {
            _fareCalculations.Add(calculation);
            return CreatedAtAction(nameof(GetFareCalculations), new { }, calculation);
        }

        [HttpGet("all")]
        public IActionResult GetFareCalculations()
        {
            return Ok(_fareCalculations);
        }
    }
}