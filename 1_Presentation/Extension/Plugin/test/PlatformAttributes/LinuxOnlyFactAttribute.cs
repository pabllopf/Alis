// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LinuxOnlyFactAttribute.cs
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

using System.Runtime.InteropServices;
using Alis.Core.Ecs.System.Scope;

using Xunit;

namespace Alis.Extension.Plugin.Test.PlatformAttributes
{
    /// <summary>
    ///     The linux only fact attribute class
    /// </summary>
    /// <seealso cref="FactAttribute" />
    internal class LinuxOnlyFactAttribute : FactAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LinuxOnlyFactAttribute" /> class
        /// </summary>
        public LinuxOnlyFactAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && !new PluginManager(new Context()).IsRunningOnAndroid())
            {
                Skip = "This test is only applicable on Linux";
            }
        }
    }
}