using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APITesting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PushNotificationController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendPushNotification([FromBody] PushNotificationRequest request)
        {
            // In a real-world scenario, you would use a push notification service to send the data
            // to the client's device. For this example, we'll just log the data to the console.
            Console.WriteLine($"Push Notification: {request.Message}");
            await Task.Delay(2000); // Simulate a 2-second delay
            return Ok();
        }

        public class PushNotificationRequest
        {
            public string Message { get; set; }
        }
    }
}