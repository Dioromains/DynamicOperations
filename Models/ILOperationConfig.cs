namespace DynamicOperations.Core.Models;

/// <summary>
/// Configuration for IL operation building
/// </summary>
public class ILOperationConfig
{
    /// <summary>
    /// The IL bytes representing the operation
    /// </summary>
    public byte[] ILBytes { get; init; }

    /// <summary>
    /// The size of the code in bytes
    /// </summary>
    public int CodeSize { get; init; }

    /// <summary>
    /// Creates a new instance of ILOperationConfig
    /// </summary>
    /// <param name="ilBytes">The IL bytes representing the operation</param>
    /// <param name="codeSize">The size of the code in bytes</param>
    /// <param name="methodName">Optional name for the dynamic method</param>
    public ILOperationConfig(byte[] ilBytes, int codeSize, string methodName = "DynamicOperation")
    {
        ILBytes = ilBytes ?? throw new ArgumentNullException(nameof(ilBytes));
        CodeSize = codeSize;
        MethodName = methodName;
    }

    /// <summary>
    /// The name of the dynamic method
    /// </summary>
    public string MethodName { get; init; } = "DynamicOperation";
}