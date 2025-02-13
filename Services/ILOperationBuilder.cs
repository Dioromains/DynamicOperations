//using System.Reflection.Emit;
//using DynamicOperations.Core.Interfaces;
//using DynamicOperations.Core.Models;

//namespace DynamicOperations.Core.Services;

///// <summary>
///// Implements the creation of IL operations
///// </summary>
//public class ILOperationBuilder : IOperationBuilder
//{
//    private static readonly Type[] ParameterTypes = { typeof(int), typeof(int) };

//    public Operation BuildOperation(OperationType operationType)
//    {
//        var config = GetOperationConfig(operationType);
//        var method = new DynamicMethod(config.MethodName, typeof(int), ParameterTypes, false);
//        var dynamicIlInfo = method.GetDynamicILInfo();

//        var localVarSigHelper = SignatureHelper.GetLocalVarSigHelper();
//        dynamicIlInfo.SetLocalSignature(localVarSigHelper.GetSignature());
//        dynamicIlInfo.SetCode(config.ILBytes, config.CodeSize);

//        return (Operation)method.CreateDelegate(typeof(Operation));
//    }

//    private static ILOperationConfig GetOperationConfig(OperationType operationType) => operationType switch
//    {
//        OperationType.Addition => new ILOperationConfig(
//            ILByteProvider.GetAdditionILBytes(),
//            2,
//            "Addition"),
//        OperationType.Subtraction => new ILOperationConfig(
//            ILByteProvider.GetSubtractionILBytes(),
//            2,
//            "Subtraction"),
//        OperationType.Multiplication => new ILOperationConfig(
//            ILByteProvider.GetMultiplicationILBytes(),
//            2,
//            "Multiplication"),
//        OperationType.Division => new ILOperationConfig(
//            ILByteProvider.GetDivisionILBytes(),
//            2,
//            "Division"),
//        OperationType.Modulo => new ILOperationConfig(
//            ILByteProvider.GetModuloILBytes(),
//            2,
//            "Modulo"),
//        OperationType.Xor => new ILOperationConfig(
//            ILByteProvider.GetXorILBytes(),
//            2,
//            "Xor"),
//        _ => throw new ArgumentException($"Operation type {operationType} not supported.")
//    };
//}

using System.Reflection.Emit;
using DynamicOperations.Core.Interfaces;
using DynamicOperations.Core.Models;

namespace DynamicOperations.Core.Services;

/// <summary>
/// Implements the creation of IL operations
/// </summary>
public class ILOperationBuilder : IOperationBuilder
{
    private static readonly Type[] ParameterTypes = { typeof(int), typeof(int) };

    public Operation BuildOperation(OperationType operationType)
    {
        var method = new DynamicMethod(
            operationType.ToString(),
            typeof(int),
            ParameterTypes,
            typeof(ILOperationBuilder).Module);

        var generator = method.GetILGenerator();

        // Load both parameters onto the stack
        generator.Emit(OpCodes.Ldarg_0);
        generator.Emit(OpCodes.Ldarg_1);

        // Emit the appropriate operation
        switch (operationType)
        {
            case OperationType.Addition:
                generator.Emit(OpCodes.Add);
                break;
            case OperationType.Subtraction:
                generator.Emit(OpCodes.Sub);
                break;
            case OperationType.Multiplication:
                generator.Emit(OpCodes.Mul);
                break;
            case OperationType.Division:
                generator.Emit(OpCodes.Div);
                break;
            case OperationType.Modulo:
                generator.Emit(OpCodes.Rem);
                break;
            case OperationType.Xor:
                generator.Emit(OpCodes.Xor);
                break;
            default:
                throw new ArgumentException($"Operation type {operationType} not supported.");
        }

        // Return the result
        generator.Emit(OpCodes.Ret);

        return (Operation)method.CreateDelegate(typeof(Operation));
    }
}