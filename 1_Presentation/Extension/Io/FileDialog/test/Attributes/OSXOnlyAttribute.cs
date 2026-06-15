// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:OSXOnlyAttribute.cs
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

#if NET8_0_OR_GREATER
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test.Attributes
{
    /// <summary>
    ///     Skips the test when not running on macOS.
    /// </summary>
    /// <seealso cref="FactAttribute" />
    
    public class OSXOnlyAttribute : FactAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OSXOnlyAttribute" /> class.
        /// </summary>
        public OSXOnlyAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Skip = "Only running in macos mode";
            }
        }
    }
}
#else
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test.Attributes
{
    /// <summary>
    ///     Skips the test when not running on macOS.
    /// </summary>
    /// <seealso cref="FactAttribute" />
    
    public class OSXOnlyAttribute : FactAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OSXOnlyAttribute" /> class.
        /// </summary>
        public OSXOnlyAttribute()
        {
            Skip = "Platform attributes not supported on this framework";
        }
    }
}
#endif
