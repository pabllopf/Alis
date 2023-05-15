// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RangeAccessorExtensions.cs
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

using System.Text;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The range accessor extensions class
    /// </summary>
    public static class RangeAccessorExtensions
    {
        /// <summary>
        /// Gets the string ascii using the specified string accessor
        /// </summary>
        /// <param name="stringAccessor">The string accessor</param>
        /// <returns>The string</returns>
        public static unsafe string GetStringASCII(this RangeAccessor<byte> stringAccessor)
        {
            return Encoding.ASCII.GetString((byte*)stringAccessor.Data, stringAccessor.Count);
        }
    }
}