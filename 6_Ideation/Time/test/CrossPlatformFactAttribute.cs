using System;
using System.Runtime.InteropServices;
using Xunit;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
public sealed class CrossPlatformFactAttribute : FactAttribute
{
    public CrossPlatformFactAttribute()
    {
        Skip = EvaluateSkip();
    }

    private static string? EvaluateSkip()
    {
        var os = GetOS();

        // 1. Detect runtime framework
        var tfm = GetTargetFramework();

        // 2. Regla crítica: .NET Framework solo en Windows
        if (tfm == TFM.NetFramework && os != OS.Windows)
        {
            return $"Skipped: {tfm} is not supported on {os}";
        }

        // 3. netstandard NO es ejecutable realmente (solo librerías)
        if (tfm == TFM.NetStandard)
        {
            return null; // no skip por OS (lo usa el host)
        }

        // 4. Modern .NET (netcoreapp / net5+ / net6+ / net8+)
        // soporta Windows/Linux/macOS
        return null;
    }

    private static TFM GetTargetFramework()
    {
#if NETFRAMEWORK
        return TFM.NetFramework;

#elif NETSTANDARD2_0 || NETSTANDARD2_1
        return TFM.NetStandard;

#elif NETCOREAPP
        return TFM.NetCore;

#elif NET5_0_OR_GREATER
        return TFM.NetModern;

#else
        return TFM.Unknown;
#endif
    }

    private static OS GetOS()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return OS.Windows;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return OS.Linux;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            return OS.MacOS;

        return OS.Unknown;
    }

    private enum OS
    {
        Windows,
        Linux,
        MacOS,
        Unknown
    }

    private enum TFM
    {
        NetFramework,
        NetStandard,
        NetCore,
        NetModern,
        Unknown
    }
}