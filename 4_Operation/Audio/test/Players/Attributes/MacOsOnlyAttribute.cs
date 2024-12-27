// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacOsOnlyAttribute.cs
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

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Core.Audio.Test.Players.Attributes
{
    /// <summary>
    ///     The mac os only attribute class
    /// </summary>
    /// <seealso cref="FactAttribute" />
    [ExcludeFromCodeCoverage]
    public class MacOsOnlyAttribute : FactAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MacOsOnlyAttribute" /> class
        /// </summary>
        public MacOsOnlyAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Skip = "Only running in macos mode";
            }
        }
    }
}