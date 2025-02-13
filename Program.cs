using DynamicOperations.Core.Models;
using DynamicOperations.Core.Services;

namespace DynamicOperations.Core;

public class Program
{
    public static void Main()
    {
        var operationBuilder = new ILOperationBuilder();
        var operationManager = new DynamicOperationManager(operationBuilder);

        // Perform addition
        int result = operationManager.ExecuteOperation(
            OperationType.Addition,
            35435344,
            156789
        );

        Console.WriteLine($"Result: {result}");

        var subtractionResult = operationManager.ExecuteOperation(
            OperationType.Subtraction,
            1000,
            200
        );

        Console.WriteLine($"Subtraction Result: {subtractionResult}");
        Console.ReadKey();
    }
}