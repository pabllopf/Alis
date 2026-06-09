// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RequiresDisplayAttribute.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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

        /// <summary>
        /// Ises the windows
        /// </summary>
        /// <returns>The bool</returns>
        private static bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        /// <summary>
        /// Ises the linux
        /// </summary>
        /// <returns>The bool</returns>
        private static bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        /// <summary>
        /// Ises the mac os
        /// </summary>
        /// <returns>The bool</returns>
        private static bool IsMacOS() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

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