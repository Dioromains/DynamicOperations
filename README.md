# DynamicOperations

A .NET library component designed for dynamic IL code generation, primarily serving as a module within a larger code obfuscation toolkit. This project demonstrates the possibility to replace standard arithmetic operations with dynamically generated IL instructions at runtime, making the code harder to reverse engineer while maintaining full functionality.

## 🔒 Role in Code Obfuscation

This component serves as one piece of a larger code obfuscation solution by:
- Replacing standard arithmetic operations with dynamically generated equivalents
- Obscuring the actual operations by using IL emission
- Making decompilation more challenging through runtime code generation
- Providing a foundation for more complex obfuscation techniques

## 🚀 Features

- Dynamic generation of arithmetic operations at runtime
- Supported operations:
  - Addition
  - Subtraction
  - Multiplication
  - Division
  - Modulo
  - XOR
- Type-safe operation execution
- Extensible design for adding new operations

## 📋 Prerequisites

- .NET Core 6.0 or higher
- Visual Studio 2022 or Visual Studio Code

## 🛠️ Installation

1. Clone the repository:
```bash
git clone https://github.com/Dioromains/DynamicOperations.git
```

2. Navigate to the project directory:
```bash
cd DynamicOperations
```

3. Build the project:
```bash
dotnet build
```

## 💻 Usage

Here's a basic example of how to use the library:

```csharp
var operationBuilder = new ILOperationBuilder();
var operationManager = new DynamicOperationManager(operationBuilder);

// Perform addition
int result = operationManager.ExecuteOperation(
    OperationType.Addition,
    35435344,
    156789
);

Console.WriteLine($"Result: {result}");
```

## 🏗️ Project Structure

```
DynamicOperations.Core/
├── Interfaces/
│   └── IOperationBuilder.cs
├── Models/
│   ├── Operation.cs
│   ├── OperationType.cs
│   └── ILOperationConfig.cs
├── Services/
│   ├── DynamicOperationManager.cs
│   └── ILOperationBuilder.cs
└── Program.cs
```

## 📖 Technical Details

This project demonstrates:
- Dynamic method generation using `DynamicMethod`
- IL code emission
- Runtime delegate creation

## ⚠️ Important Notes

- This is a proof-of-concept project demonstrating IL code generation
- The IL byte arrays are hardcoded for demonstration purposes
- Not recommended for production use without proper testing and validation

## 📄 License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## 🙏 Acknowledgments

- Inspired by the capabilities of .NET's Reflection.Emit namespace
- Special thanks to the .NET community for documentation and resources on IL code generation
