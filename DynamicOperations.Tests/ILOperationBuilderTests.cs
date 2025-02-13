using DynamicOperations.Core.Models;
using DynamicOperations.Core.Services;
using Xunit;
using System;

namespace DynamicOperations.Tests;

public class ILOperationBuilderTests
{
    private readonly ILOperationBuilder _builder;

    public ILOperationBuilderTests()
    {
        _builder = new ILOperationBuilder();
    }

    [Theory]
    [InlineData(OperationType.Addition)]
    [InlineData(OperationType.Subtraction)]
    [InlineData(OperationType.Multiplication)]
    [InlineData(OperationType.Division)]
    [InlineData(OperationType.Modulo)]
    [InlineData(OperationType.Xor)]
    public void BuildOperation_ShouldCreateValidDelegate(OperationType operationType)
    {
        // Act
        var operation = _builder.BuildOperation(operationType);

        // Assert
        Assert.NotNull(operation);
    }

    [Fact]
    public void BuildOperation_CreatedDelegate_ShouldBeReusable()
    {
        // Arrange
        var operation = _builder.BuildOperation(OperationType.Addition);

        // Act
        var firstResult = operation(5, 3);
        var secondResult = operation(10, 7);

        // Assert
        Assert.Equal(8, firstResult);
        Assert.Equal(17, secondResult);
    }

    [Fact]
    public void BuildOperation_WithInvalidOperationType_ShouldThrowArgumentException()
    {
        // Arrange
        var invalidOperation = (OperationType)999;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            _builder.BuildOperation(invalidOperation));
        Assert.Contains("not supported", exception.Message);
    }

    [Theory]
    [InlineData(int.MaxValue - 1, 1)]  // Testing edge cases
    [InlineData(int.MinValue, -1)]
    [InlineData(0, 0)]
    public void BuildOperation_ShouldHandleEdgeCases(int a, int b)
    {
        // Arrange
        var operation = _builder.BuildOperation(OperationType.Addition);

        // Act
        var result = operation(a, b);

        // Assert
        Assert.Equal(unchecked(a + b), result);
    }
}