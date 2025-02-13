using DynamicOperations.Core.Interfaces;
using DynamicOperations.Core.Models;

namespace DynamicOperations.Core.Services;

/// <summary>
/// Manages the creation and execution of dynamic IL operations
/// </summary>
public sealed class DynamicOperationManager
{
    private readonly IOperationBuilder _operationBuilder;
    private readonly Dictionary<OperationType, Operation> _operations;

    public DynamicOperationManager(IOperationBuilder operationBuilder)
    {
        _operationBuilder = operationBuilder ?? throw new ArgumentNullException(nameof(operationBuilder));
        _operations = new Dictionary<OperationType, Operation>();
        InitializeOperations();
    }

    private void InitializeOperations()
    {
        foreach (OperationType operationType in Enum.GetValues(typeof(OperationType)))
        {
            _operations[operationType] = _operationBuilder.BuildOperation(operationType);
        }
    }

    /// <summary>
    /// Executes the specified operation with the given operands
    /// </summary>
    public int ExecuteOperation(OperationType operationType, int first, int second)
    {
        if (!_operations.TryGetValue(operationType, out var operation))
        {
            throw new ArgumentException($"Operation type {operationType} not supported.");
        }

        return operation(first, second);
    }
}