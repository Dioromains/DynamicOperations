namespace DynamicOperations.Core.Services;

/// <summary>
/// Provides IL bytes for different operations
/// </summary>
internal static class ILByteProvider
{
    public static byte[] GetAdditionILBytes()
    {
        var ilBytes = new byte[11];
        Buffer.BlockCopy(BitConverter.GetBytes(8194), 0, ilBytes, 0, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(526319871), 0, ilBytes, 4, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(2778128), 0, ilBytes, 8, 3);
        return ilBytes;
    }

    public static byte[] GetSubtractionILBytes()
    {
        var ilBytes = new byte[11];
        Buffer.BlockCopy(BitConverter.GetBytes(8194), 0, ilBytes, 0, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(526384896), 0, ilBytes, 4, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(2778136), 0, ilBytes, 8, 3);
        return ilBytes;
    }

    public static byte[] GetMultiplicationILBytes()
    {
        var ilBytes = new byte[11];
        Buffer.BlockCopy(BitConverter.GetBytes(4278198274U), 0, ilBytes, 0, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(526319616), 0, ilBytes, 4, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(2778120), 0, ilBytes, 8, 3);
        return ilBytes;
    }

    public static byte[] GetDivisionILBytes()
    {
        var ilBytes = new byte[8];
        Buffer.BlockCopy(BitConverter.GetBytes(16719874), 0, ilBytes, 0, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(710868992), 0, ilBytes, 4, 4);
        return ilBytes;
    }

    public static byte[] GetModuloILBytes()
    {
        var ilBytes = new byte[4];
        Buffer.BlockCopy(BitConverter.GetBytes(711000834), 0, ilBytes, 0, 4);
        return ilBytes;
    }

    public static byte[] GetXorILBytes()
    {
        var ilBytes = new byte[7];
        Buffer.BlockCopy(BitConverter.GetBytes(525998082), 0, ilBytes, 0, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(2776703), 0, ilBytes, 4, 3);
        return ilBytes;
    }
}