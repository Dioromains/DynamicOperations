using DynamicOperations.Core.Models;
using DynamicOperations.Core.Services;

namespace DynamicOperations.Tests;

public class ILOperationTests
{
    private readonly DynamicOperationManager _operationManager;

    public ILOperationTests()
    {
        var operationBuilder = new ILOperationBuilder();
        _operationManager = new DynamicOperationManager(operationBuilder);
    }

    [Theory]
    [InlineData(0, 0, 0)]           // Zero case
    [InlineData(5, 3, 8)]           // Basic addition
    [InlineData(-5, 3, -2)]         // Negative numbers
    [InlineData(int.MaxValue - 1, 1, int.MaxValue)]  // Edge case
    public void Addition_ShouldReturnCorrectResult(int a, int b, int expected)
    {
        var result = _operationManager.ExecuteOperation(OperationType.Addition, a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 0)]           // Zero case
    [InlineData(5, 3, 2)]           // Basic subtraction
    [InlineData(-5, 3, -8)]         // Negative numbers
    [InlineData(int.MinValue + 1, 1, int.MinValue)]  // Edge case
    public void Subtraction_ShouldReturnCorrectResult(int a, int b, int expected)
    {
        var result = _operationManager.ExecuteOperation(OperationType.Subtraction, a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 0)]           // Zero case
    [InlineData(5, 3, 15)]          // Basic multiplication
    [InlineData(-5, 3, -15)]        // Negative numbers
    [InlineData(2, 3, 6)]           // Small numbers
    public void Multiplication_ShouldReturnCorrectResult(int a, int b, int expected)
    {
        var result = _operationManager.ExecuteOperation(OperationType.Multiplication, a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 1, 0)]           // Zero numerator
    [InlineData(15, 3, 5)]          // Basic division
    [InlineData(-15, 3, -5)]        // Negative numbers
    [InlineData(7, 2, 3)]           // Integer division
    public void Division_ShouldReturnCorrectResult(int a, int b, int expected)
    {
        var result = _operationManager.ExecuteOperation(OperationType.Division, a, b);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Division_ByZero_ShouldThrowDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() =>
            _operationManager.ExecuteOperation(OperationType.Division, 5, 0));
    }

    [Theory]
    [InlineData(0, 1, 0)]           // Zero case
    [InlineData(7, 3, 1)]           // Basic modulo
    [InlineData(-5, 3, -2)]         // Negative numbers
    [InlineData(15, 4, 3)]          // Larger numbers
    public void Modulo_ShouldReturnCorrectResult(int a, int b, int expected)
    {
        var result = _operationManager.ExecuteOperation(OperationType.Modulo, a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 0)]           // Zero case
    [InlineData(5, 3, 6)]           // 101 XOR 011 = 110 (6)
    [InlineData(15, 3, 12)]         // 1111 XOR 0011 = 1100 (12)
    [InlineData(0xFF, 0x0F, 0xF0)]  // Byte boundary case
    public void Xor_ShouldReturnCorrectResult(int a, int b, int expected)
    {
        var result = _operationManager.ExecuteOperation(OperationType.Xor, a, b);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void InvalidOperationType_ShouldThrowArgumentException()
    {
        var invalidOperation = (OperationType)999;
        var exception = Assert.Throws<ArgumentException>(() =>
            _operationManager.ExecuteOperation(invalidOperation, 1, 1));
        Assert.Contains("not supported", exception.Message);
    }
}