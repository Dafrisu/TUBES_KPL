using APITesting.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Xunit;

namespace APITesting.Tests
{
    public class FareCalculatorControllerTests
    {
        [Theory]
        [InlineData("LocationA", "LocationB", 10.0)] // Example test data
        [InlineData("LocationC", "LocationD", 5.0)]  // Another example test data
        public void CalculateFare_ValidInput_ReturnsOk(string dari, string ke, double jarakDalamKM)
        {
            // Arrange
            var controller = new FareCalculatorController();

            // Act
            IActionResult result = controller.CalculateFare(dari, ke, jarakDalamKM);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            dynamic value = okResult.Value;
            string resultDari = value.GetType().GetProperty("dari")?.GetValue(value, null)?.ToString();
            string resultKe = value.GetType().GetProperty("ke")?.GetValue(value, null)?.ToString();
            double resultJarakDalamKM = Convert.ToDouble(value.GetType().GetProperty("jarakDalamKM")?.GetValue(value, null));
            string resultTotalHarga = value.GetType().GetProperty("totalHarga")?.GetValue(value, null)?.ToString();

            Assert.Equal(dari, resultDari);
            Assert.Equal(ke, resultKe);
            Assert.Equal(jarakDalamKM, resultJarakDalamKM);
            double hargaPerKM = 2000;
            int total = (int)(jarakDalamKM * hargaPerKM - (5000 * Math.Floor(jarakDalamKM / 10)));
            Assert.Equal(total.ToString("N0", CultureInfo.InvariantCulture) + " IDR", resultTotalHarga);
        }



        [Theory]
        [InlineData("LocationA", "LocationB", -10.0)] // Negative distance
        [InlineData("LocationC", "LocationD", 0.0)]   // Zero distance
        public void CalculateFare_InvalidInput_ReturnsBadRequest(string dari, string ke, double jarakDalamKM)
        {
            // Arrange
            var controller = new FareCalculatorController();

            // Act
            IActionResult result = controller.CalculateFare(dari, ke, jarakDalamKM);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.Equal("Silakan masukkan jarak yang valid dalam kilometer.", badRequestResult.Value);
        }
    }
}