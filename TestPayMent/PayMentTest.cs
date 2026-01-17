using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using PayMentAPI.Models;
using PayMentAPI.PayMentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OrderAPI.Tests;

public class PayMentServiceTests : IDisposable
{
    private readonly PayMentAppContext _context;
    private readonly PayMentService _paymentService;

    public PayMentServiceTests()
    {
        var options = new DbContextOptionsBuilder<PayMentAppContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var configurationMock = new Mock<IConfiguration>();

        _context = new PayMentAppContext(options, configurationMock.Object);

        _context.Payments.AddRange(new List<Payment>
        {
            new Payment { Id = 1, OrderId = 101, Status = "confirmed", ProcessedAt = DateTime.Now },
            new Payment { Id = 2, OrderId = 102, Status = "cancelled", ProcessedAt = DateTime.Now },
            new Payment { Id = 3, OrderId = 103, Status = "cancelled", ProcessedAt = DateTime.Now }
        });
        _context.SaveChanges();

        _paymentService = new PayMentService(_context);
    }

    [Fact]
    public async Task IsOrderConfirmedAsync_ExistingConfirmedOrder_ReturnsTrue()
    {
        bool result = await _paymentService.IsOrderConfirmedAsync(101);
        Assert.True(result);
    }

    [Fact]
    public async Task IsOrderConfirmedAsync_ExistingCancelledOrder_ReturnsFalse()
    {
        bool result = await _paymentService.IsOrderConfirmedAsync(102);
        Assert.False(result);
    }

    [Fact]
    public async Task IsOrderConfirmedAsync_NonExistingOrder_ReturnsFalse()
    {
        bool result = await _paymentService.IsOrderConfirmedAsync(999);
        Assert.False(result);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}