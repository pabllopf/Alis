// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTextFilter.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui text filter
    /// </summary>
    public struct ImGuiTextFilter
    {
        /// <summary>
        ///     The input buf
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        private byte[] inputBuf;

        /// <summary>
        ///     Gets or sets the input buf
        /// </summary>
        public byte[] InputBuf
        {
            get => inputBuf;
            set => inputBuf = value;
        }

        /// <summary>
        ///     Gets or sets the filters
        /// </summary>
        public ImVector Filters { get; set; }

        /// <summary>
        ///     Gets or sets the count grep
        /// </summary>
        public int CountGrep { get; set; }
    }
}