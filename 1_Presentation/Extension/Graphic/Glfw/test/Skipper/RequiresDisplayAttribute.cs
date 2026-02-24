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
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Skipper
{
    /// <summary>
    /// The requires display attribute class
    /// </summary>
    /// <seealso cref="FactAttribute"/>
    public class RequiresDisplayAttribute : FactAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequiresDisplayAttribute"/> class
        /// </summary>
        public RequiresDisplayAttribute()
        {
            if (!HasDisplay())
            {
                Skip = "Test requires a graphical display environment, but none was detected.";
            }
        }
    
       /// <summary>
       /// Hases the display
       /// </summary>
       /// <returns>The bool</returns>
       private static bool HasDisplay()
       {
           try
           {
               if (OperatingSystem.IsWindows())
               {
                   // Windows siempre tiene entorno gráfico si está corriendo
                   return Environment.UserInteractive;
               }
               
               if (OperatingSystem.IsLinux())
               {
                   // Verificar X11
                   string display = Environment.GetEnvironmentVariable("DISPLAY");
                   if (!string.IsNullOrEmpty(display))
                   {
                       return true;
                   }
                   
                   // Verificar Wayland
                   string waylandDisplay = Environment.GetEnvironmentVariable("WAYLAND_DISPLAY");
                   if (!string.IsNullOrEmpty(waylandDisplay))
                   {
                       return true;
                   }
                   
                   // Verificar XDG_SESSION_TYPE
                   string sessionType = Environment.GetEnvironmentVariable("XDG_SESSION_TYPE");
                   if (sessionType == "x11" || sessionType == "wayland")
                   {
                       return true;
                   }
                   
                   return false;
               }
               
               if (OperatingSystem.IsMacOS())
               {
                   // En macOS, verificar si hay WindowServer activo
                   // WindowServer es el proceso que gestiona el entorno gráfico
                   try
                   {
                       var processStartInfo = new System.Diagnostics.ProcessStartInfo
                       {
                           FileName = "pgrep",
                           Arguments = "WindowServer",
                           RedirectStandardOutput = true,
                           UseShellExecute = false,
                           CreateNoWindow = true
                       };
               
                       using var process = System.Diagnostics.Process.Start(processStartInfo);
                       if (process != null)
                       {
                           process.WaitForExit();
                           return false; // 0 significa que WindowServer está corriendo
                       }
                   }
                   catch
                   {
                       // Si falla, asumir que hay display en macOS por defecto
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