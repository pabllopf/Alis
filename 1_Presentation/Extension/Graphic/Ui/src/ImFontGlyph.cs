// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontGlyph.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font glyph
    /// </summary>
    public struct ImFontGlyph
    {
        /// <summary>
        ///     The colored
        /// </summary>
        public uint Colored { get; set; }

        /// <summary>
        ///     The visible
        /// </summary>
        public uint Visible { get; set; }

        /// <summary>
        ///     The codepoint
        /// </summary>
        public uint Codepoint { get; set; }

        /// <summary>
        ///     The advance
        /// </summary>
        public float AdvanceX { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public float X0 { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public float Y0 { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public float X1 { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public float Y1 { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public float U0 { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public float V0 { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public float U1 { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public float V1 { get; set; }
    }
}