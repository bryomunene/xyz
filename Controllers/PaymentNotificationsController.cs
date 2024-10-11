using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using xyz.Data;
using xyz.Models;
using xyz.Data;

[ApiController]
[Route("api/payment/notifications")]
public class PaymentNotificationsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PaymentNotificationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> ReceiveNotification([FromBody] PaymentNotification notification)
    {
        if (notification == null || string.IsNullOrEmpty(notification.TransactionId) || notification.Amount <= 0)
        {
            return BadRequest(new { error = "Invalid notification data" });
        }

        // Process the payment notification
        await UpdatePaymentStatus(notification);

        // Log the notification (optional)
        Console.WriteLine($"Payment Notification Received: {System.Text.Json.JsonSerializer.Serialize(notification)}");

        return Ok(new { message = "Notification processed successfully" });
    }

    private async Task UpdatePaymentStatus(PaymentNotification notification)
    {
        var payment = await _context.Payments
            .FirstOrDefaultAsync(p => p.TransactionId == notification.TransactionId);

        if (payment != null)
        {
            payment.Status = "Processed"; // or any relevant status
            payment.Amount = notification.Amount; // Update amount if necessary

            await _context.SaveChangesAsync();
        }
        else
        {
            // Optionally, you could log that the payment was not found
            Console.WriteLine($"Payment not found for TransactionId: {notification.TransactionId}");
        }
    }
}
