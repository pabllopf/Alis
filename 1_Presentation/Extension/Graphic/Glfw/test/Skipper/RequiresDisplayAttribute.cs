

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Skipper
{
    /// <summary>
    ///     The requires display attribute class
    /// </summary>
    /// <seealso cref="FactAttribute" />
    public class RequiresDisplayAttribute : FactAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RequiresDisplayAttribute" /> class
        /// </summary>
        public RequiresDisplayAttribute()
        {
            if (!HasDisplay())
            {
                Skip = "Test requires a graphical display environment, but none was detected.";
            }
        }
        
        
#if NET5_0_OR_GREATER

        private static bool IsWindows() => OperatingSystem.IsWindows();

        private static bool IsLinux() => OperatingSystem.IsLinux();

        private static bool IsMacOS() => OperatingSystem.IsMacOS();

#else

        private static bool IsWindows()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        }

        private static bool IsLinux()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        }

        private static bool IsMacOS()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        }

#endif

        /// <summary>
        ///     Hases the display
        /// </summary>
        /// <returns>The bool</returns>
        private static bool HasDisplay()
        {
            try
            {
                if (IsWindows())
                {
                    return false;
                }

                if (IsLinux())
                {
                    string display = Environment.GetEnvironmentVariable("DISPLAY");
                    if (!string.IsNullOrEmpty(display))
                    {
                        return true;
                    }

                    string waylandDisplay = Environment.GetEnvironmentVariable("WAYLAND_DISPLAY");
                    if (!string.IsNullOrEmpty(waylandDisplay))
                    {
                        return true;
                    }

                    string sessionType = Environment.GetEnvironmentVariable("XDG_SESSION_TYPE");
                    if (sessionType == "x11" || sessionType == "wayland")
                    {
                        return true;
                    }

                    return false;
                }

                if (IsMacOS())
                {
                    try
                    {
                        ProcessStartInfo processStartInfo = new ProcessStartInfo
                        {
                            FileName = "pgrep",
                            Arguments = "WindowServer",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        using Process process = Process.Start(processStartInfo);
                        if (process != null)
                        {
                            process.WaitForExit();
                            return false; // 0 significa que WindowServer está corriendo
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}