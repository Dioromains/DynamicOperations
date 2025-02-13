using DynamicOperations.Core.Models;

namespace DynamicOperations.Core.Interfaces;

/// <summary>
/// Defines the contract for creating dynamic IL operations
/// </summary>
public interface IOperationBuilder
{
    /// <summary>
    /// Builds a dynamic operation based on the specified operation type
    /// </summary>
    /// <param name="operationType">Type of operation to build</param>
    /// <returns>A delegate representing the operation</returns>
    Operation BuildOperation(OperationType operationType);
}