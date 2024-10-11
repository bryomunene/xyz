using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using xyz.Models;

[ApiController]
[Route("api/payment/notifications")]
public class PaymentNotificationsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ReceiveNotification([FromBody] PaymentNotification notification)
    {
        if (notification == null || string.IsNullOrEmpty(notification.TransactionId) || notification.Amount <= 0)
        {
            return BadRequest(new { error = "Invalid notification data" });
        }

        // Process the payment notification (e.g., update the database)
        // Example: await UpdatePaymentStatus(notification);

        // Log the notification (optional)
        Console.WriteLine($"Payment Notification Received: {System.Text.Json.JsonSerializer.Serialize(notification)}");

        return Ok(new { message = "Notification processed successfully" });
    }
}
