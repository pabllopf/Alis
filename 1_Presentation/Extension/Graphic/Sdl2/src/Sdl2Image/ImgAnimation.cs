// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImgAnimation.cs
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

namespace Alis.Extension.Graphic.Sdl2.Sdl2Image
{
    /// <summary>
    ///     The img animation
    /// </summary>
    public struct ImgAnimation
    {
        /// <summary>
        ///     Gets or sets the width
        /// </summary>
        public int W { get; set; }

        /// <summary>
        ///     Gets or sets the height
        /// </summary>
        public int H { get; set; }

        /// <summary>
        ///     Gets or sets the frames
        /// </summary>
        public IntPtr Frames { get; set; }

        /// <summary>
        ///     Gets or sets the delays
        /// </summary>
        public IntPtr Delays { get; set; }
    }
}