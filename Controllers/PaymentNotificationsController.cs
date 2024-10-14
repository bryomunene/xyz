using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using xyz.Data;
using xyz.Models;
using xyz.Data;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/payment/notifications")]
[Authorize]
public class PaymentNotificationsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PaymentNotificationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("receive-notification")]
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

    [HttpPost("update-payment-status")]
    public async Task<IActionResult> UpdatePaymentStatus([FromBody] PaymentNotification notification)
    {
        if (notification == null || string.IsNullOrEmpty(notification.TransactionId))
        {
            return BadRequest("Invalid payment notification.");
        }

        var payment = await _context.PaymentNotifications
            .FirstOrDefaultAsync(p => p.TransactionId == notification.TransactionId);

        if (payment != null)
        {
            payment.Status = "Processed"; // or any relevant status
            payment.Amount = notification.Amount; // Update amount if necessary

            await _context.SaveChangesAsync();
            return Ok("Payment status updated successfully.");
        }
        else
        {
            // Log that the payment was not found
            Console.WriteLine($"Payment not found for TransactionId: {notification.TransactionId}");
            return NotFound("Payment not found.");
        }
    }
}
