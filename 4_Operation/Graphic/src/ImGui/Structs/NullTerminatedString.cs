// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NullTerminatedString.cs
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

namespace Alis.Core.Graphic.ImGui.Structs
{
    /// <summary>
    ///     The null terminated string
    /// </summary>
    public unsafe struct NullTerminatedString
    {
        /// <summary>
        ///     The data
        /// </summary>
        public readonly byte* Data;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NullTerminatedString" /> class
        /// </summary>
        /// <param name="data">The data</param>
        public NullTerminatedString(byte* data) => Data = data;

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            int length = 0;
            byte* ptr = Data;
            while (*ptr != 0)
            {
                length += 1;
                ptr += 1;
            }

            return Encoding.ASCII.GetString(Data, length);
        }

        /// <summary>
        /// </summary>
        /// <param name="nts"></param>
        /// <returns></returns>
        public static implicit operator string(NullTerminatedString nts) => nts.ToString();
    }
}