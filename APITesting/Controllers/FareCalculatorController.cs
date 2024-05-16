using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace APITesting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FareCalculatorController : ControllerBase
    {
        public static List<FareCalculator> _fareCalculations = new List<FareCalculator>();
        public static List<FareCalculator> FareCalculations { get; } = new List<FareCalculator>();

        [HttpGet("calculate")]
        public IActionResult CalculateFare(string dari, string ke, double jarakDalamKM)
        {
            if (jarakDalamKM <= 0)
            {
                return BadRequest("Silakan masukkan jarak yang valid dalam kilometer.");
            }

            int hargaPerKM = 2000;
            int total = (int)(jarakDalamKM * hargaPerKM);

            int discountCount = (int)(jarakDalamKM / 10);
            total -= discountCount * 5000;

            var calculation = new FareCalculator
            {
                Dari = dari,
                Ke = ke,
                JarakDalamKM = jarakDalamKM,
                HargaPerKM = hargaPerKM,
                TotalHarga = total,
            };
            _fareCalculations.Add(calculation);

            return Ok(new
            {
                dari = calculation.Dari,
                ke = calculation.Ke,
                jarakDalamKM = calculation.JarakDalamKM,
                hargaPerKM = calculation.HargaPerKM.ToString("N0", CultureInfo.InvariantCulture) + " IDR",
                totalHarga = calculation.TotalHarga.ToString("N0", CultureInfo.InvariantCulture) + " IDR"
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
            var fareCalculationResults = _fareCalculations.Select((calculation, index) => new
            {
                Id = index + 1,
                Dari = calculation.Dari,
                Ke = calculation.Ke,
                JarakDalamKM = calculation.JarakDalamKM,
                HargaPerKM = calculation.HargaPerKM.ToString("N0", CultureInfo.InvariantCulture) + " IDR",
                TotalHarga = calculation.TotalHarga.ToString("N0", CultureInfo.InvariantCulture) + " IDR"
            });

            return Ok(fareCalculationResults);
        }
    }
}