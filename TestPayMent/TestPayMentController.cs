using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PayMentAPI.Controllers;
using PayMentAPI.Models;
using PayMentAPI.PayMentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PayMentAPI.Tests.Controllers;

public class PaymentControllerTests
{
    private readonly Mock<IPayMentService> _mockPaymentService;
    private readonly Mock<ILogger<PaymentController>> _mockLogger;
    private readonly PaymentController _controller;

    public PaymentControllerTests()
    {
        _mockPaymentService = new Mock<IPayMentService>();
        _mockLogger = new Mock<ILogger<PaymentController>>();
        _controller = new PaymentController(_mockPaymentService.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task GetPayments_ReturnsOkResult_WithPayments()
    {
        // Arrange
        var expectedPayments = new List<Payment>
        {
            new Payment { Id = 1,  OrderId= 101, Status = "Completed", ProcessedAt = DateTime.Now.AddDays(-1) },
            new Payment { Id = 2, OrderId = 102, Status = "Pending", ProcessedAt = null }
        };

        _mockPaymentService.Setup(service => service.GetPayMentAsync())
            .ReturnsAsync(expectedPayments);

        // Act
        var result = await _controller.GetPayments();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedPayments = Assert.IsAssignableFrom<IEnumerable<Payment>>(okResult.Value);
        Assert.Equal(expectedPayments, returnedPayments);

        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, t) => o.ToString().Contains("Bắt đầu lấy danh sách thanh toán")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);

        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, t) => o.ToString().Contains("Đã lấy thành công")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task GetPayments_ReturnsOkResult_WithEmptyList_WhenNoPaymentsExist()
    {
        var emptyPayments = new List<Payment>();

        _mockPaymentService.Setup(service => service.GetPayMentAsync())
            .ReturnsAsync(emptyPayments);

        // Act
        var result = await _controller.GetPayments();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedPayments = Assert.IsAssignableFrom<IEnumerable<Payment>>(okResult.Value);
        Assert.Empty(returnedPayments);
    }

    [Fact]
    public async Task GetPayments_ReturnsStatusCode500_WhenExceptionOccurs()
    {
        // Arrange
        _mockPaymentService.Setup(service => service.GetPayMentAsync())
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await _controller.GetPayments();

        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
        Assert.Equal("Có lỗi xảy ra khi xử lý yêu cầu của bạn", statusCodeResult.Value);

        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, t) => o.ToString().Contains("Lỗi xảy ra khi lấy danh sách thanh toán")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task IsOrderConfirmed_ReturnsOkResult_WithTrue_WhenOrderIsConfirmed()
    {
        // Arrange
        int orderId = 1;
        bool isConfirmed = true;

        _mockPaymentService.Setup(service => service.IsOrderConfirmedAsync(orderId))
            .ReturnsAsync(isConfirmed);

        // Act
        var result = await _controller.IsOrderConfirmed(orderId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.True((bool)okResult.Value);

        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, t) => o.ToString().Contains($"Kiểm tra trạng thái xác nhận cho đơn hàng {orderId}")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task IsOrderConfirmed_ReturnsOkResult_WithFalse_WhenOrderIsNotConfirmed()
    {
        // Arrange
        int orderId = 2;
        bool isConfirmed = false;

        _mockPaymentService.Setup(service => service.IsOrderConfirmedAsync(orderId))
            .ReturnsAsync(isConfirmed);

        // Act
        var result = await _controller.IsOrderConfirmed(orderId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.False((bool)okResult.Value);
    }

    [Fact]
    public async Task IsOrderConfirmed_ReturnsStatusCode500_WhenExceptionOccurs()
    {
        // Arrange
        int orderId = 3;

        _mockPaymentService.Setup(service => service.IsOrderConfirmedAsync(orderId))
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await _controller.IsOrderConfirmed(orderId);

        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
        Assert.Equal("Có lỗi xảy ra khi xử lý yêu cầu của bạn", statusCodeResult.Value);

        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, t) => o.ToString().Contains($"Lỗi khi kiểm tra trạng thái xác nhận đơn hàng {orderId}")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }
}

